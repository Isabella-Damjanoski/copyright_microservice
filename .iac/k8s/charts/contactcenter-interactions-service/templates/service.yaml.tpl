---
apiVersion: v1
kind: Service
metadata:
  name: {{ .Values.service.name }}
  namespace: {{ .Values.serviceGroup.name }}
  labels:
    app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/component: {{ .Values.service.name }}
  annotations:
    dev.okteto.com/auto-ingress: "true"
spec:
  type: ClusterIP
  ports:
    - port: {{ .Values.service.port }}
      targetPort: {{ .Values.service.port }}
      name: http
  selector:
    app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/component: {{ .Values.service.name }}
