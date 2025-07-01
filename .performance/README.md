# K6 Performance Testing
K6 is load testing tool that allows you to write performance tests in Javascript.

Note: Important! Try to rely on the built-in functions and modules as much as possible, as they are optimized for performance.
https://grafana.com/docs/k6/latest/using-k6/modules/


# Install K6
https://grafana.com/docs/k6/latest/set-up/install-k6/

# Main k6 concepts

### Init function - initialize the test
https://grafana.com/docs/k6/latest/javascript-api/init-context/

### Scenarios
https://grafana.com/docs/k6/latest/using-k6/scenarios/

### Automated performance testing best practices
https://grafana.com/docs/k6/latest/testing-guides/automated-performance-testing/


### Writing a Browser test
https://grafana.com/docs/k6/latest/k6-studio/ to record a test from user actions
K6 uses playwright API to interact with the browser.

### BROWSER ENV variables 
Full list
https://grafana.com/docs/k6/latest/javascript-api/k6-browser/#browser-module-options

#### Important ones:
`K6_BROWSER_HEADLESS` - set to false to open a visible browser window. Default is true.
`K6_PROMETHEUS_RW_SERVER_URL`=http://your_ip:9090/api/v1/write 

If you need to set Chrome flags, you can use the K6_BROWSER_ARGS environment variable. For example, to disable the sandbox, you can set K6_BROWSER_ARGS="no-sandbox". note that flags don't have the -- prefix.

```
K6_BROWSER_ARGS="no-sandbox=true disable-gpu=true allow-file-access-from-files=true  use-fake-ui-for-media-stream=true use-fake-device-for-media-stream=true auto-accept-camera-and-microphone-capture=true use-file-for-fake-audio-capture=./ui/voice1_16.wav autoplay-policy=no-user-gesture-required allow-file-access=true"
```

### K6 CLI
https://grafana.com/docs/k6/latest/get-started/running-k6/


### K6 metrics
You can stream results into Grafana Cloud, Prometheus, InfluxDB.
For prometheus, you can use the following env variable:
`K6_PROMETHEUS_RW_SERVER_URL`=http://your_ip:9090/api/v1/write
`k6 run  -o experimental-prometheus-rw st-api/crm-get-customers.js`
Note that the prometheus server should be configured to accept writes from k6.
with flag `--web.enable-remote-write-receiver`
https://grafana.com/docs/k6/latest/results-output/real-time/prometheus-remote-write/
see all the options
https://grafana.com/docs/k6/latest/results-output/real-time/prometheus-remote-write/#options

### Handle k6 results in file
https://grafana.com/docs/k6/latest/get-started/results-output/

### K6 Telemetry setup
https://grafana.com/docs/k6/latest/results-output/real-time/opentelemetry/

# Load Testing Interactions

## Setup and Run
In .performance folder, copy the `k6.env.json.template` file and fill the values in from 1Password `contactcenter interactions qa k6.env.json`

Install packages
`npm install`

Lint with eslint
`npm run lint`

Format with Prettier
`npm run format`

Build typescript for type checking
`npm run build`

Run Tests:
`k6 run tests/v2Api.ts`

By default, the above command will use the `local` environment and the `smoke` workload. 
- to point to QA `export ENVIRONMENT=qa`
- to increase concurrency/users `export USERS=10`
- to increase iterations `export ITERATIONS=100`
- to increase the max duration `export DURATION=60s`
- to change the workload `export WORKFLOW=average`

Always be aware of what you are running in QA or Stage. QA should not be heavily load tested. Stage should have prior approval and agreement so that teams know what is going on.

## CI/CD

`k6-verify-check`
- run on pull requests. Checks build, format, lint, and then verifies the k6 scripts

`k6-api-load-test`
- can be run manually at anytime for various pre-defined workloads, or by specifying a custom concurrency/duration/iteration.

`deploy-qa`
- will run the `smoke` workload after deployment to ensure tests complete successfully

`deploy-release` (to be implemented)
- will run the `smoke` workflow after deployment to `stage`
- will run the `smoke` workflow after deployment to `prod`

`k6-reusable`
- the template used by all the above pipelines

## PCS Graybox
To run these tests using the PCS Graybox the main thing needed is the tenant must have the feature flag `testing-use-pcs-gray-box` returning true. [Feature Flag](https://app.launchdarkly.com/projects/contact-center/flags/testing-use-pcs-gray-box/targeting?env=qa&env=stage&env=production&selected-env=qa)
For example, in qa, the E4 Test Network for Load Testing, is setup to use the graybox. 

### Run PCS Graybox Locally
To run locally against the graybox:
1. Clone the `contactcenter-pcs-graybox` git repository.
1. Run the ContactCenter.Pcs.GrayBox.csproj project to start it up. 
1. Open the Interactions Service project
1. Configure `appsettings.local.config` with the `Pcs:GrayboxAddress` to point to `http://localhost:5001`
1. Start the docker-compose from interactions so it can connect to mongodb/kafka
1. Start the Interactions Service
1. Set the environment variable for `export ENVIRONMENT=local` so that k6 pulls settings from local config.
1. Continue to the below section to run k6 tests
