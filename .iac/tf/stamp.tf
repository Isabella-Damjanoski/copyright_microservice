# Kubernetes Provider
provider "kubernetes" {
  host                   = data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.host
  client_certificate     = base64decode(data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.client_certificate)
  client_key             = base64decode(data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.client_key)
  cluster_ca_certificate = base64decode(data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.cluster_ca_certificate)
}

provider "helm" {
  kubernetes {
    host                   = data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.host
    client_certificate     = base64decode(data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.client_certificate)
    client_key             = base64decode(data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.client_key)
    cluster_ca_certificate = base64decode(data.azurerm_kubernetes_cluster.aks.kube_admin_config.0.cluster_ca_certificate)
  }
}

locals {
  service_group_details_name     = "contactcenter"
  service_details_repository_uri = "git@github.com:servicetitan/contactcenter-interactions-service.git"
  service_details_name           = "contactcenter-interactions-service"
  subscription_details_outer     = data.terraform_remote_state.outer_subscription[0].outputs.details
  environment_details_outer      = data.terraform_remote_state.outer_environment[0].outputs.details
  # environment_details_inner      = data.terraform_remote_state.inner_environment[0].outputs.details
  stamp_details_outer           = data.terraform_remote_state.outer_stamp[0].outputs.details
  resource_group_name           = data.terraform_remote_state.outer_stamp[0].outputs.details.infra.resource_group.name
  resource_group_location       = data.terraform_remote_state.outer_stamp[0].outputs.details.infra.resource_group.location
  resource_group_inner_name     = local.resource_group_to_deploy.name
  resource_group_inner_location = local.resource_group_to_deploy.location
}

locals {
  # Whether this is an okteto deployment
  is_okteto = local.subscription_details_outer.key == "okteto"

  # Whether AKS is deployed in the deployment
  deploy_aks  = !local.is_okteto && can(local.stamp_details_outer.aks.deploy) ? local.stamp_details_outer.aks.deploy : false
  flux_branch = try(local.environment_details_outer.customData.fluxBranch, "master")
}

data "azurerm_key_vault" "environment_kv" {
  name                = "contactcenter-${local.environment_details_outer.name}-kv"
  resource_group_name = local.environment_details_outer.resource_group_name
}

# Get stamp's existing AKS cluster (deployed as part of stamp's outer deployment)
# TODO: should we do this only if local.deploy_aks == true?
data "azurerm_kubernetes_cluster" "aks" {
  name                = local.stamp_details_outer.infra.aks.name
  resource_group_name = local.stamp_details_outer.infra.resource_group.name
}

data "azurerm_subscription" "current" {
}

variable "chart_version" {
  type = string
}

module "k8s_service" {
  source = "github.com/servicetitan/contactcenter-shared-iac//modules/stamp/service"

  service             = local.service_details_name
  service_group       = local.service_group_details_name
  chart_version       = local.environment_details_outer.name == "qa" ? "0.0.1-${var.chart_version}" : var.chart_version
  aks_name            = local.stamp_details_outer.infra.aks.name
  aks_resource_group  = local.stamp_details_outer.infra.resource_group.name
  resource_group      = local.resource_group_inner_name
  location            = local.resource_group_inner_location
  namespace           = local.service_group_details_name
  environment_name    = local.environment_details_outer.name
  environment_kv_name = data.azurerm_key_vault.environment_kv.name
  acr_repo_name       = local.environment_details_outer.acr.name
  subscription_key    = local.subscription_details_outer.key
  subscription_id     = data.azurerm_subscription.current.subscription_id
  stamp_name          = local.stamp_details_outer.name
  stamp_dns_zone      = local.stamp_details_outer.infra.dns.name
  mongo_roles         = { "contactcenter-interactions-service" = "readWrite" }
  is_okteto           = local.is_okteto
  oidc_issuer_url     = local.stamp_details_outer.infra.aks.properties.oidc_issuer_url

  deploy_ingress      = local.environment_details_outer.name == "qa"
  subdomain           = "interactions"
}

data "azurerm_servicebus_namespace" "contactcenter" {
  name                = "${local.service_group_details_name}-${local.environment_details_outer.name}-${local.stamp_details_outer.name}"
  resource_group_name = local.stamp_details_outer.infra.resource_group.name
}

resource "azurerm_servicebus_topic" "topics" {
  for_each = {
    "callclassified_topic" = {}
    "conversation_event_topic" = {}
    "interaction_change_event_topic" = {}
  }
  name         = each.key
  namespace_id = data.azurerm_servicebus_namespace.contactcenter.id

  enable_partitioning          = true
  requires_duplicate_detection = true
}

resource "azurerm_servicebus_queue" "queues" {
  for_each = {
    "callchanged_queue"                             = {}
    "postcalltranscriptcreated_queue"               = {}
    "summarygensentimentevalrequested_queue"        = {}
    "postcalltranscriptsummarized_queue"            = {}
    "postcallsentimentassessed_queue"               = {}
    "interactionprocesschannelclassification_queue" = {}
    "interactionjobidupdated_queue" = {}
    "debezium_interaction_change_event_queue" = {}
  }

  name         = each.key
  namespace_id = data.azurerm_servicebus_namespace.contactcenter.id

  enable_partitioning                  = true
  requires_duplicate_detection         = true
  dead_lettering_on_message_expiration = true
  max_delivery_count                   = 10
}

resource "azurerm_servicebus_subscription" "subscriptions" {
  for_each = {
    "processtonotabandoned_sub" = {
      topic = "callclassified_topic"
    }
    "processtoabandoned_sub" = {
      topic = "callclassified_topic"
    }
    "processtobooked_sub" = {
      topic = "callclassified_topic"
    }
    "conversation_created_sub" = {
      topic = "conversation_event_topic"
    }
    "conversation_updated_sub" = {
      topic = "conversation_event_topic"
    }
    "conversation_ended_sub" = {
      topic = "conversation_event_topic"
    }
    "va_session_answered_sub" = {
      topic = "conversation_event_topic"
    }
    "user_session_answered_sub" = {
      topic = "conversation_event_topic"
    }
    "process_fill_session_user_name_sub" = {
      topic = "interaction_change_event_topic"
    },
    "process_fill_primary_user_name_sub" = {
      topic = "interaction_change_event_topic"
    },
    "process_fill_tenant_name_sub" = {
      topic = "interaction_change_event_topic"
    },
    "process_set_primary_user_sub" = {
      topic = "interaction_change_event_topic"
    },
    "user_session_created_sub" = {
      topic = "conversation_event_topic"
    }
    "external_bridge_session_created_sub" = {
      topic = "conversation_event_topic"
    }
    "process_update_call_classification_in_monolith_sub" = {
      topic = "interaction_change_event_topic"
    }
    "process_update_call_job_in_monolith_sub" = {
      topic = "interaction_change_event_topic"
    }
    "process_complete_va_call_sub" = {
      topic = "interaction_change_event_topic"
    }
    "process_set_campaign_sub" = {
      topic = "interaction_change_event_topic"
    }
    "process_set_customer_sub" = {
      topic = "interaction_change_event_topic"
    }
    "recording_ended_sub" = {
      topic = "conversation_event_topic"
    }
    "voicemail_created_sub" = {
      topic = "conversation_event_topic"
    }
    "process_fill_org_node_id_sub" = {
      topic = "interaction_change_event_topic"
    }
  }

  name     = each.key
  topic_id = azurerm_servicebus_topic.topics[each.value.topic].id

  max_delivery_count = 10

  dead_lettering_on_message_expiration      = true
  dead_lettering_on_filter_evaluation_error = true
}

# Outputs
output "details" {
  sensitive = true
  value = {
    # ami = merge(
    #   azurerm_user_assigned_identity.ami,
    # { clientid = azurerm_user_assigned_identity.ami.client_id }) # we ref it as $OKTETO_EXTERNAL_AMI_CLIENTID
    # kv          = local.environment_details_inner.kv
    # db          = local.environment_details_inner.db
    flux_config = null
    dns         = local.stamp_details_outer.infra.dns
  }
}
