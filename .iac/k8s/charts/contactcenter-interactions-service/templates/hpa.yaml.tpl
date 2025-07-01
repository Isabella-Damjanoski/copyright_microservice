---
apiVersion: autoscaling/v2
kind: HorizontalPodAutoscaler
metadata:
  labels:
    app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/component: {{ .Values.service.name }}
    app.kubernetes.io/project: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/instance: {{ .Values.environment.name }}-{{ .Values.stamp.name }}
  name: {{ .Values.service.name }}
  namespace: {{ .Values.serviceGroup.name }}
spec:
  behavior:
    scaleDown:
      policies:
        - periodSeconds: {{ .Values.hpa.scaleDown.periodSeconds }}
          type: {{ .Values.hpa.scaleDown.type }}
          value: {{ .Values.hpa.scaleDown.amount }}
      stabilizationWindowSeconds: {{ .Values.hpa.scaleDown.stabilizationWindowSeconds }}
    scaleUp:
      policies:
        - periodSeconds: {{ .Values.hpa.scaleUp.periodSeconds }}
          type: {{ .Values.hpa.scaleUp.type }}
          value: {{ .Values.hpa.scaleUp.amount }}
      stabilizationWindowSeconds: {{ .Values.hpa.scaleUp.stabilizationWindowSeconds }}
  maxReplicas: {{ .Values.hpa.maxReplicas }}
  metrics:
    - resource:
        name: memory
        target:
          averageUtilization: {{ .Values.hpa.targetMemoryUtilizationPercentage }}
          type: Utilization
      type: Resource
    - resource:
        name: cpu
        target:
          averageUtilization: {{ .Values.hpa.targetCpuUtilizationPercentage }}
          type: Utilization
      type: Resource
  minReplicas: {{ .Values.hpa.minReplicas }}
  scaleTargetRef:
    apiVersion: apps/v1
    kind: Deployment
    name: {{ .Values.service.name }}
