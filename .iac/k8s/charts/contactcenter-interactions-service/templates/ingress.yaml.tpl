{{- $domain := ternary "servicetitan.com" "st.dev" (eq .Values.subscription.key "prod") }}
{{- $envZone := printf "%s.%s.%s.srv.%s" .Values.environment.name .Values.subscription.key .Values.serviceGroup.name $domain }}
{{- $envHost := printf "%s.%s" .Values.ingress.subdomain $envZone }}
{{- $stampHost := printf "%s.%s.%s" .Values.ingress.subdomain .Values.stamp.name $envZone }}

{{- if eq .Values.environment.name "qa" }}
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: {{ .Values.service.name }}
  namespace: {{ .Values.serviceGroup.name }}
  labels:
    app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/component: {{ .Values.service.name }}
  annotations:
    nginx.ingress.kubernetes.io/ssl-redirect: "false"
    nginx.ingress.kubernetes.io/use-regex: "true"
    nginx.ingress.kubernetes.io/rewrite-target: /$1
    nginx.ingress.kubernetes.io/enable-cors: "true"
    nginx.ingress.kubernetes.io/cors-allow-origin: "*"
    nginx.ingress.kubernetes.io/cors-allow-methods: "*"
    nginx.ingress.kubernetes.io/cors-allow-headers: "DNT,Keep-Alive,User-Agent,X-Requested-With,If-Modified-Since,Cache-Control,Content-Type,Range,Authorization,X-ContactCenter-Id,graphql-preflight"
    nginx.ingress.kubernetes.io/proxy-body-size: 10m
    cert-manager.io/cluster-issuer: {{ .Values.serviceGroup.name }}
spec:
  ingressClassName: nginx
  tls:
    - hosts:
        - {{ $envHost }}
        - {{ $stampHost }}
      secretName: {{ .Values.service.name }}-ssl-stamp
  rules:
    - host: {{ $envHost }}
      http:
        paths:
        - path: /(.*)
          pathType: ImplementationSpecific
          backend:
            service:
              name: {{ .Values.service.name }}
              port:
                name: http
    - host: {{ $stampHost }}
      http:
        paths:
        - path: /(.*)
          pathType: ImplementationSpecific
          backend:
            service:
              name: {{ .Values.service.name }}
              port:
                name: http
{{- end }}
