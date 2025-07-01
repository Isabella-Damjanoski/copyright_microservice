---
apiVersion: apps/v1
kind: Deployment
metadata:
  name: {{ .Values.service.name }}
  namespace: {{ .Values.serviceGroup.name }}
  labels:
    app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/component: {{ .Values.service.name }}
    app.kubernetes.io/project: {{ .Values.serviceGroup.name }}
    app.kubernetes.io/instance: {{ .Values.environment.name }}-{{ .Values.stamp.name }}
spec:
  selector:
    matchLabels:
      app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
      app.kubernetes.io/component: {{ .Values.service.name }}
  template:
    metadata:
      labels:
        azure.workload.identity/use: "true"
        app.kubernetes.io/app: {{ .Values.serviceGroup.name }}
        app.kubernetes.io/component: {{ .Values.service.name }}
        app.kubernetes.io/project: {{ .Values.serviceGroup.name }}
        app.kubernetes.io/instance: {{ .Values.environment.name }}-{{ .Values.stamp.name }}
    spec:
      serviceAccountName: {{ .Values.service.name }}
      terminationGracePeriodSeconds: 40
      topologySpreadConstraints:
        - maxSkew: 1
          topologyKey: kubernetes.io/hostname
          whenUnsatisfiable: ScheduleAnyway
      containers:
        - name: {{ .Values.service.name }}
          image: {{ .Values.service.image.repo }}/{{ .Values.service.image.name }}:{{ .Values.service.image.version }}
          resources:
            limits:
              cpu: 1500m
              memory: 2Gi
            requests:
              cpu: 500m
              memory: 2Gi
          ports:
            - containerPort: {{ .Values.service.port }}
          readinessProbe:
            httpGet:
              path: /
              port: 8080
            initialDelaySeconds: 5
            periodSeconds: 10
            failureThreshold: 2
          livenessProbe:
            httpGet:
              path: /
              port: 8080
            initialDelaySeconds: 3
            periodSeconds: 12
          env:
            - name: ASPNETCORE_ENVIRONMENT
            {{- if eq .Values.environment.name "prod" }}
              value: Production
            {{- else if eq .Values.environment.name "stage" }}
              value: Staging
            {{- else }}
              value: Development
            {{- end }}
            - name: "MONOLITH_ENV"
            {{- if eq .Values.environment.name "prod" }}
              value: "go"
            {{- else if eq .Values.environment.name "stage" }}
              value: "stage"
            {{- else }}
              value: "telecom"
            {{- end }}
            - name: PCSCLIENT__GRAYBOXADDRESS
              value: "http://contactcenter-pcs-graybox:8080"
            - name: VASERVICECLIENT__BASEURL
              value: "http://contactcenter-va-service:8080"
            - name: USERSERVICECLIENT__BASEURL
              value: "http://contactcenter-users-service:8080"
            - name: OPENTELEMETRY__SERVICENAME
              value: {{ .Values.service.name }}_{{ .Values.environment.name }}
          envFrom:
            - secretRef:
                name: {{ .Values.service.name }}-secrets
