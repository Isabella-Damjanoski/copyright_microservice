---
apiVersion: policy/v1
kind: PodDisruptionBudget
metadata:
  labels:
    app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/component: {{ .Values.service.name }}
  name: {{ .Values.service.name }}
  namespace: {{ .Values.serviceGroup.name }}
spec:
  maxUnavailable: {{ .Values.pdb.maxUnavailable }}
  selector:
    matchLabels:
      app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
      app.kubernetes.io/component: {{ .Values.service.name }}
