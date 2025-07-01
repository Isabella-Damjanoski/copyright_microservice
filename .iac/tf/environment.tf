locals {
  subscription_details = data.terraform_remote_state.outer_subscription[0].outputs.details
  environment_details  = data.terraform_remote_state.outer_environment[0].outputs.details
  mongodb_project_id   = local.subscription_details.key == "devtest" ? "65f8823a25c45d313b94c995" : "66286d803bf223406c62546c"
  mongodb_cluster_name = "contactcenter-${lower(local.environment_details.name)}"
}

module "interactions_index_v2" {
  source = "github.com/servicetitan/contactcenter-shared-iac/modules/environment/mongodb.index"

  project_id   = local.mongodb_project_id
  cluster_name = local.mongodb_cluster_name
  database     = "contactcenter-interactions-service"

  collection = "Interactions"
  name       = "interactions-search-index-v2"

  mappings = {
    "Customer" = {
      "fields" = {
        "CustomerName" = {
          "analyzer"     = "lucene.whitespace"
          "minGrams"     = 3
          "maxGrams"     = 15
          "tokenization" = "nGram"
          "type"         = "autocomplete"
        }
      }
      "type" = "document"
    }
    "DisplayId" = {
      "analyzer"       = "keyword_lowercase"
      "searchAnalyzer" = "keyword_lowercase"
      "type"           = "string"
    }
    "ChannelDetails" = {
      "fields" = {
        "From" = {
          "analyzer"     = "keyword_phone"
          "minGrams"     = 3
          "maxGrams"     = 15
          "tokenization" = "nGram"
          "type"         = "autocomplete"
        }
        "To" = {
          "analyzer"     = "keyword_phone"
          "minGrams"     = 3
          "maxGrams"     = 15
          "tokenization" = "nGram"
          "type"         = "autocomplete"
        }
      }
      "type" = "document"
    }
    "OrgNode" = {
      "fields" = {
        "TenantName" = {
          "analyzer"     = "lucene.standard"
          "minGrams"     = 3
          "maxGrams"     = 15
          "tokenization" = "nGram"
          "type"         = "autocomplete"
        }
      }
      "type" = "document"
    }
  }

  custom_analyzers = [
    {
      "charFilters"  = []
      "name"         = "keyword_lowercase"
      "tokenFilters" = [
        {
          "type" = "lowercase"
        }
      ]
      "tokenizer" = {
        "type" = "keyword"
      }
    },
    {
      "charFilters" = [
        {
          "mappings" = {
            " " = ""
            "(" = ""
            ")" = ""
            "+" = ""
            "-" = ""
            "." = ""
          },
          "type": "mapping"
        }
      ]
      "name"         = "keyword_phone"
      "tokenFilters" = []
      "tokenizer"    = {
        "group"   = 0
        "pattern" = "^\\b\\d+\\b$"
        "type"    = "regexCaptureGroup"
      }
    }
  ]
}