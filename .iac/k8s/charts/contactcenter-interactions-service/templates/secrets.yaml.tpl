---
apiVersion: external-secrets.io/v1beta1
kind: ExternalSecret
metadata:
  name: {{ .Values.service.name }}-secrets
spec:
  refreshInterval: 1h
  secretStoreRef:
    kind: SecretStore
    name: environment-kv

  target:
    name: {{ .Values.service.name }}-secrets

  data:
  - secretKey: "MongoDbConnectionString"
    remoteRef:
      key: {{ .Values.service.name }}-{{ .Values.stamp.name }}-contactcenter-interactions-service-mongo-connection-string
  - secretKey: "Kafka__Server"
    remoteRef:
      key: interactions-service-kafka-corecluster-server
  - secretKey: "Kafka__UserName"
    remoteRef:
      key: interactions-service-kafka-corecluster-username
  - secretKey: "Kafka__Password"
    remoteRef:
      key: interactions-service-kafka-corecluster-password
  - secretKey: "KafkaK8__Server"
    remoteRef:
      key: interactions-service-kafkak8-corecluster-server
  - secretKey: "KafkaK8__UserName"
    remoteRef:
      key: interactions-service-kafkak8-corecluster-username
  - secretKey: "KafkaK8__Password"
    remoteRef:
      key: interactions-service-kafkak8-corecluster-password     
  - secretKey: "DebeziumTopicName"
    remoteRef:
      key: interactions-service-kafkak8-debezium-topic          
  - secretKey: "AzureServiceBus__ConnectionString"
    remoteRef:
      key: servicebus-connection-string-{{ .Values.stamp.name }}
  - secretKey: "STV2ApiClient__ClientId"
    remoteRef:
      key: st-api-client-id
  - secretKey: "STV2ApiClient__ClientSecret"
    remoteRef:
      key: st-api-client-secret
  - secretKey: "STV2ApiClient__AppKey"
    remoteRef:
      key: st-api-key
  - secretKey: "STV2ApiClient__InternalNextGenApiKey"
    remoteRef:
      key: st-api-nextgen-apikey
  - secretKey: "PcsClient__ApiKey"
    remoteRef:
      key: pcs-apikey
  - secretKey: TOKENSERVER__CONTACTCENTER_INTERACTIONSSERVICE_WORKER__CLIENTSECRET
    remoteRef:
      key: contactcenter-interactions-service-tokenserver-contactcenter-interactions-service-worker-clientsecret
  - secretKey: LAUNCHDARKLY__SDKKEY
    remoteRef:
      key: launchdarkly-sdkkey

