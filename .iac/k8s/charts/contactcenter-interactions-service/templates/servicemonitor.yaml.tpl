---
apiVersion: monitoring.coreos.com/v1
kind: ServiceMonitor
metadata:
  name: {{ .Values.service.name }}-servicemonitor
  namespace: {{ .Values.serviceGroup.name }}
spec:
  selector:
    matchLabels:
      app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
      app.kubernetes.io/component: {{ .Values.service.name }}
  endpoints:
    - port: http
      path: /metrics
      interval: 30s
      metricRelabelings:
      - targetLabel: metadata_instance
        replacement: {{ .Values.environment.name }}-{{ .Values.stamp.name }}
      - targetLabel: metadata_component
        replacement: {{ .Values.service.name }}
      - targetLabel: metadata_team
        replacement: {{ .Values.serviceGroup.name }}
      - targetLabel: metadata_environment
        replacement: {{ .Values.environment.name }}
      - targetLabel: metadata_stamp
        replacement: {{ .Values.stamp.name }}
      - targetLabel: metadata_serviceGroup
        replacement: {{ .Values.serviceGroup.name }}
      - targetLabel: metadata_project
        replacement: {{ .Values.serviceGroup.name }}
