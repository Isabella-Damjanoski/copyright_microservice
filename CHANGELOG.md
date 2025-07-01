# Changelog

## [1.26.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.25.1...v1.26.0) (2025-06-23)


### Features

* **CCP-6548:** Add Ids as option to filter Interactions ([#524](https://github.com/servicetitan/contactcenter-interactions-service/issues/524)) ([ae03ee9](https://github.com/servicetitan/contactcenter-interactions-service/commit/ae03ee9fd9ec0e9ed8477b9e1d9217406312be6c))

## [1.25.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.25.0...v1.25.1) (2025-06-13)


### Bug Fixes

* **CCP-6341:** Fix exception thrown when abandoning message past lock expiration ([#522](https://github.com/servicetitan/contactcenter-interactions-service/issues/522)) ([597c361](https://github.com/servicetitan/contactcenter-interactions-service/commit/597c361ca6b4e714d37d98cc4b2cc19842760eb2))

## [1.25.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.24.1...v1.25.0) (2025-06-05)


### Features

* **CCP-3554:** Implement clearing call reason and additional detail for reclassification ([#426](https://github.com/servicetitan/contactcenter-interactions-service/issues/426)) ([d04e38a](https://github.com/servicetitan/contactcenter-interactions-service/commit/d04e38ab3658e61f59ed9d71d9434564032460bd))
* **CCP-5576:** BE - Interactions service, update nswag clients to use safe enum converter ([#518](https://github.com/servicetitan/contactcenter-interactions-service/issues/518)) ([e9522cb](https://github.com/servicetitan/contactcenter-interactions-service/commit/e9522cb935b4430dcf3d635c6c6315b49a4a254b))
* **CCP-5786:** Add version field on session task collection ([#512](https://github.com/servicetitan/contactcenter-interactions-service/issues/512)) ([0d6ad8c](https://github.com/servicetitan/contactcenter-interactions-service/commit/0d6ad8cb3e3eb8967a6047190dc995b09a19a40b))
* **CCP-5878:** Create/Drop indexes for Interactions collection ([#504](https://github.com/servicetitan/contactcenter-interactions-service/issues/504)) ([aa0cd2e](https://github.com/servicetitan/contactcenter-interactions-service/commit/aa0cd2e22d6a85b8bca3bd060fc306bc6ed1acaf))
* **CCP-5894:** Created conversation events collection and repository ([#505](https://github.com/servicetitan/contactcenter-interactions-service/issues/505)) ([01a55b3](https://github.com/servicetitan/contactcenter-interactions-service/commit/01a55b3b486b114dfe303a32938cb20538beac17))
* **CCP-5941:** Create a new partial index ([#503](https://github.com/servicetitan/contactcenter-interactions-service/issues/503)) ([62982f7](https://github.com/servicetitan/contactcenter-interactions-service/commit/62982f77fd51b8cab058ead504e80db7cf49a118))
* **CCP-5944:** [and CCP-6133] BE - Add SID and Tenant Name to conversation history query and downloaded XLS/spreadsheet (and remove interaction ID) ([#514](https://github.com/servicetitan/contactcenter-interactions-service/issues/514)) ([7e77282](https://github.com/servicetitan/contactcenter-interactions-service/commit/7e77282959f0bc6bd09196ce0b426a4ce6438f57))
* **CCP-6082:** Drop ArchivedAt from indexes, Remove unnecessary filter ArchivedAt   ([#513](https://github.com/servicetitan/contactcenter-interactions-service/issues/513)) ([cadcec3](https://github.com/servicetitan/contactcenter-interactions-service/commit/cadcec39c85527d30cd014d88974cec381bc4bff))
* **CCP-6084:** Create composite index IX_Status_TenantId_ContactCenterId  ([#509](https://github.com/servicetitan/contactcenter-interactions-service/issues/509)) ([5abd5f7](https://github.com/servicetitan/contactcenter-interactions-service/commit/5abd5f7ade50eac5909762a861638ee90ccb08bf))
* **CCP-6162:** regenerate pcs client ([#515](https://github.com/servicetitan/contactcenter-interactions-service/issues/515)) ([a6bc5e0](https://github.com/servicetitan/contactcenter-interactions-service/commit/a6bc5e0aed49fd917ba607c0cd8138314af788b1))


### Bug Fixes

* **CCP-4948:** Improved handling of cancellation events ([#471](https://github.com/servicetitan/contactcenter-interactions-service/issues/471)) ([5286573](https://github.com/servicetitan/contactcenter-interactions-service/commit/5286573f2ce3da6b49a7ea9f5c55dcf0985fc22b))
* **CCP-5877:** Improve query filters to utilize indexes better ([#499](https://github.com/servicetitan/contactcenter-interactions-service/issues/499)) ([902f508](https://github.com/servicetitan/contactcenter-interactions-service/commit/902f508dbe51e8e193353836ea0778df7187f4bf))
* **CCP-6055:** Fix using CallId as a filter param on v2 get interactions endpoint ([#510](https://github.com/servicetitan/contactcenter-interactions-service/issues/510)) ([130ed6b](https://github.com/servicetitan/contactcenter-interactions-service/commit/130ed6b88d3675a9994995a52885a241285af11e))
* **CCP-6093:** Add linear backoff to ASB retries for better recovery ([#516](https://github.com/servicetitan/contactcenter-interactions-service/issues/516)) ([65d4d19](https://github.com/servicetitan/contactcenter-interactions-service/commit/65d4d192b948ce37f658bc3862d56ad2412c655b))
* **CCP-6094:** Ensures that we get CallId set even if call created message is missed. ([#517](https://github.com/servicetitan/contactcenter-interactions-service/issues/517)) ([532ba04](https://github.com/servicetitan/contactcenter-interactions-service/commit/532ba0401d37da5ff6b5db54c11e1e8337ff29d7))
* **CCP-6121:** Fix unit test failure ([#511](https://github.com/servicetitan/contactcenter-interactions-service/issues/511)) ([ae8fb18](https://github.com/servicetitan/contactcenter-interactions-service/commit/ae8fb188a9ca3895da955603d82aae63bfc5eb14))


### Chores

* **CCPH-1147:** Update default Kafka AutoOffsetReset strategy ([#519](https://github.com/servicetitan/contactcenter-interactions-service/issues/519)) ([ff5dcf1](https://github.com/servicetitan/contactcenter-interactions-service/commit/ff5dcf195e81d5e6f09f4b1d54d06c13e6461afb))

## [1.24.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.24.0...v1.24.1) (2025-05-13)


### Bug Fixes

* **CCP-5576:** REVERT - BE - Interactions service, update nswag clients to use safe enum converter ([#506](https://github.com/servicetitan/contactcenter-interactions-service/issues/506)) ([2560fe9](https://github.com/servicetitan/contactcenter-interactions-service/commit/2560fe9b92042f0aca0824cd1303e077204addce))

## [1.24.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.23.0...v1.24.0) (2025-05-13)


### Features

* **CCP-5492:** be enforce tenant access ([#493](https://github.com/servicetitan/contactcenter-interactions-service/issues/493)) ([809e665](https://github.com/servicetitan/contactcenter-interactions-service/commit/809e665793c4a8e02aca52483fe96ef8fd8e1083))
* **CCP-5576:** BE - Interactions service, update nswag clients to use safe enum converter ([#501](https://github.com/servicetitan/contactcenter-interactions-service/issues/501)) ([9c0c1c3](https://github.com/servicetitan/contactcenter-interactions-service/commit/9c0c1c3158ee375160767602fd382037c9a948e9))
* **CCP-5603:** BE - Filter out conversation topic messages by message header ([#495](https://github.com/servicetitan/contactcenter-interactions-service/issues/495)) ([c8ed0ed](https://github.com/servicetitan/contactcenter-interactions-service/commit/c8ed0eda02a4ac09db6720ab1270bc224894880d))


### Bug Fixes

* **CCP-5577:** Update Kafka messages to safely deserialize enums ([#500](https://github.com/servicetitan/contactcenter-interactions-service/issues/500)) ([b7947c9](https://github.com/servicetitan/contactcenter-interactions-service/commit/b7947c90ccab27b6dacca396f58d2ece4a519a53))
* **CCP-5887:** Fix existing partial index  ([#497](https://github.com/servicetitan/contactcenter-interactions-service/issues/497)) ([4f8dd49](https://github.com/servicetitan/contactcenter-interactions-service/commit/4f8dd4996701e12f2442dfd205ad126b026dc005))


### Chores

* **CCP-5885:** Update interaction alerts ([#502](https://github.com/servicetitan/contactcenter-interactions-service/issues/502)) ([870a61a](https://github.com/servicetitan/contactcenter-interactions-service/commit/870a61a0467fe537958672df768ff1e3d4308318))

## [1.23.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.22.0...v1.23.0) (2025-04-29)


### Features

* **CCP-5245:** Sync the ExcuseMemo from monolith ([#491](https://github.com/servicetitan/contactcenter-interactions-service/issues/491)) ([c571748](https://github.com/servicetitan/contactcenter-interactions-service/commit/c5717488363ca57010e66b7f6117e57c52b71480))
* **CCP-5490:** Update appsettings auth url ([#494](https://github.com/servicetitan/contactcenter-interactions-service/issues/494)) ([823402f](https://github.com/servicetitan/contactcenter-interactions-service/commit/823402f0915cc31c3ea627f7ada492ef6e86dac9))

## [1.22.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.21.0...v1.22.0) (2025-04-22)


### Features

* **CCP-4556:** Add initial disposition note ([#481](https://github.com/servicetitan/contactcenter-interactions-service/issues/481)) ([c3a213b](https://github.com/servicetitan/contactcenter-interactions-service/commit/c3a213bb6787aaab900ae6773d8afe4c7b3c24ac))
* **CCP-5160:** Update max concurrency of Azure Service Bus message processing ([#478](https://github.com/servicetitan/contactcenter-interactions-service/issues/478)) ([58ad550](https://github.com/servicetitan/contactcenter-interactions-service/commit/58ad5502b6eea49d51090e6130dff5433be8827e))
* **CCP-5232:** BE: Set AdditianalDetail of InteractionChangedEvent the latest note ([#489](https://github.com/servicetitan/contactcenter-interactions-service/issues/489)) ([24910e6](https://github.com/servicetitan/contactcenter-interactions-service/commit/24910e678e17f8c527e385182756c4a5da2454e5))
* **CCP-5245:** BE: Sync latest note with monolith ([#490](https://github.com/servicetitan/contactcenter-interactions-service/issues/490)) ([11ac9cb](https://github.com/servicetitan/contactcenter-interactions-service/commit/11ac9cb2b20982d1caf158ae534dfeb7ac45bcd8))


### Bug Fixes

* **CCP-5109:** Made Interaction indexes partial. ([#475](https://github.com/servicetitan/contactcenter-interactions-service/issues/475)) ([62fe205](https://github.com/servicetitan/contactcenter-interactions-service/commit/62fe2056ac8757b71cf72a435157132da0ed8863))
* **CCP-5299:** Fixes Interactions where Status is Completed but CompletedAt is null ([#476](https://github.com/servicetitan/contactcenter-interactions-service/issues/476)) ([8ed2adb](https://github.com/servicetitan/contactcenter-interactions-service/commit/8ed2adb469bc071cc11e1a7c9543b12a288e9d11))
* **CCP-5360:** Set customer for abandoned calls based on interaction change event ([#482](https://github.com/servicetitan/contactcenter-interactions-service/issues/482)) ([5c124cc](https://github.com/servicetitan/contactcenter-interactions-service/commit/5c124cca5045be60f70869174579c64f98439609))
* **CCP-5378:** Make conversation optional when deserializing from kafka ([#485](https://github.com/servicetitan/contactcenter-interactions-service/issues/485)) ([e9b3fed](https://github.com/servicetitan/contactcenter-interactions-service/commit/e9b3fed53a25f1e96dba374aeac27fdabbeb26e9))
* **CCP-5385:** regenerate pcs client ([#488](https://github.com/servicetitan/contactcenter-interactions-service/issues/488)) ([0a069e7](https://github.com/servicetitan/contactcenter-interactions-service/commit/0a069e7a71bf415d9d102b8cea93df16748c93e6))


### Chores

* **CCP-5009:** minor refactors ([#484](https://github.com/servicetitan/contactcenter-interactions-service/issues/484)) ([b5ff581](https://github.com/servicetitan/contactcenter-interactions-service/commit/b5ff5810120446afa69bd104332838c8f11c6562))
* **CCP-5364:** Update ASB metrics ([#483](https://github.com/servicetitan/contactcenter-interactions-service/issues/483)) ([f77ff86](https://github.com/servicetitan/contactcenter-interactions-service/commit/f77ff867a2efe6065f3e9a5c2ac14f1894b74c03))
* **CCPH-676:** add mongodb team to codeowners ([#473](https://github.com/servicetitan/contactcenter-interactions-service/issues/473)) ([65de8a1](https://github.com/servicetitan/contactcenter-interactions-service/commit/65de8a191c7f850b0a8497dc4ac36077bc21f523))

## [1.21.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.20.0...v1.21.0) (2025-04-14)


### Features

* **CCP-3221:** Campaign Information ([#434](https://github.com/servicetitan/contactcenter-interactions-service/issues/434)) ([fe038b5](https://github.com/servicetitan/contactcenter-interactions-service/commit/fe038b5a0c9a050c4283947fb7ae84a8724862f2))
* **CCP-3654:** background job populate org node id to interactions ([#435](https://github.com/servicetitan/contactcenter-interactions-service/issues/435)) ([d34773c](https://github.com/servicetitan/contactcenter-interactions-service/commit/d34773cbfef324fdc33c0c95ae9bf2f053eae6fa))
* **CCP-4369:** Add a "ChannelCompleted" filter that lets the caller see only ended calls ([#452](https://github.com/servicetitan/contactcenter-interactions-service/issues/452)) ([78d6d21](https://github.com/servicetitan/contactcenter-interactions-service/commit/78d6d21942c3369aab72cb45a40fa83db400569e))
* **CCP-4369:** Add ChannelCompleted filter to GET /v2/interactions endpoint ([#462](https://github.com/servicetitan/contactcenter-interactions-service/issues/462)) ([a68b401](https://github.com/servicetitan/contactcenter-interactions-service/commit/a68b401b742597dac1f2bfa4e33256e5088bdfeb))
* **CCP-4568:** Set Customer Id and Name from call changed events ([#437](https://github.com/servicetitan/contactcenter-interactions-service/issues/437)) ([c114c98](https://github.com/servicetitan/contactcenter-interactions-service/commit/c114c98292956868c8a7cacea5028879459ad4e5))
* **CCP-4569:** Complete the interaction of abandoned call  ([#443](https://github.com/servicetitan/contactcenter-interactions-service/issues/443)) ([6345e6f](https://github.com/servicetitan/contactcenter-interactions-service/commit/6345e6ffc113f91d2819c58d628d546bf8a4545f))
* **CCP-4656:** Implement toggle between V1 and V2 classification via FF ([#430](https://github.com/servicetitan/contactcenter-interactions-service/issues/430)) ([5c213eb](https://github.com/servicetitan/contactcenter-interactions-service/commit/5c213ebc73c0ecca7f5c1c455a5b998bf41d2662))
* **CCP-4810:** BE - Create a new Index on interaction service ([#441](https://github.com/servicetitan/contactcenter-interactions-service/issues/441)) ([64c7a36](https://github.com/servicetitan/contactcenter-interactions-service/commit/64c7a36560d7bb1fd52f5b30c094c4ff378d8d36))
* **CCP-4945:** allow outbounds to create post call ([#466](https://github.com/servicetitan/contactcenter-interactions-service/issues/466)) ([82ea2f1](https://github.com/servicetitan/contactcenter-interactions-service/commit/82ea2f1372f135039ee930f0b0919724aebec3fc))
* **CCP-4948:** Implement graceful shutdown ([#467](https://github.com/servicetitan/contactcenter-interactions-service/issues/467)) ([aa53b6f](https://github.com/servicetitan/contactcenter-interactions-service/commit/aa53b6ffb1d70e8c0283c912095c0562b3824797))
* **CCPH-630:** Update Resolution to Voicemail from events ([#449](https://github.com/servicetitan/contactcenter-interactions-service/issues/449)) ([8fd97b9](https://github.com/servicetitan/contactcenter-interactions-service/commit/8fd97b9747eb88fc585dc1c86efe52e98abc49aa))
* **CCPH-631:** Update Resolution to ForwardedOut from events ([#459](https://github.com/servicetitan/contactcenter-interactions-service/issues/459)) ([96caaf9](https://github.com/servicetitan/contactcenter-interactions-service/commit/96caaf99f363c84eaaaba492845d8ff474e088b2))
* **CCPH-632:** Update IsRecorded field for Completed Abandoned Calls ([#460](https://github.com/servicetitan/contactcenter-interactions-service/issues/460)) ([a7d5f9f](https://github.com/servicetitan/contactcenter-interactions-service/commit/a7d5f9f824d564a8c47258881e1feaa0b3720c78))
* **CCPH-633:** Update IsRecorded field from Kafka events ([#463](https://github.com/servicetitan/contactcenter-interactions-service/issues/463)) ([f789df1](https://github.com/servicetitan/contactcenter-interactions-service/commit/f789df1872e32dd4b95a2228f681bcd937aed3f8))
* **CCPH-639:** Add `IsRecorded` field to Interaction ([#446](https://github.com/servicetitan/contactcenter-interactions-service/issues/446)) ([5b58bfc](https://github.com/servicetitan/contactcenter-interactions-service/commit/5b58bfc8db326fa19f9f3fd21d90735588ad96a5))
* **CCPH-669:** Use feature flag for true abandoned calls ([#464](https://github.com/servicetitan/contactcenter-interactions-service/issues/464)) ([16f4e91](https://github.com/servicetitan/contactcenter-interactions-service/commit/16f4e9173df0e1a39c04e69b40faa983b859e7e9))


### Bug Fixes

* **CCP-4369:** Update channel completed filter to yes/no/any input type ([#468](https://github.com/servicetitan/contactcenter-interactions-service/issues/468)) ([9afac31](https://github.com/servicetitan/contactcenter-interactions-service/commit/9afac319fbd12ea897d8fbd70a31620e966cacca))
* **CCP-4912:** Hide abandoned calls if feature flag is turned off. ([#453](https://github.com/servicetitan/contactcenter-interactions-service/issues/453)) ([9755a3b](https://github.com/servicetitan/contactcenter-interactions-service/commit/9755a3b39f364e14a652039ccdecd51bb87c4b70))
* **CCP-4926:** Set new Interactions with Version = 2 ([#456](https://github.com/servicetitan/contactcenter-interactions-service/issues/456)) ([ec2131c](https://github.com/servicetitan/contactcenter-interactions-service/commit/ec2131ce763a7ab4b18a5778f4c1ec4e7194c15e))
* **CCP-5167:** Nullify nested properties if unchanged ([#474](https://github.com/servicetitan/contactcenter-interactions-service/issues/474)) ([8a409fb](https://github.com/servicetitan/contactcenter-interactions-service/commit/8a409fba13f7d849f9ab5bcc0462a02ffdf841a5))
* **CCP-5167:** Remove redundant 'return'. ([#477](https://github.com/servicetitan/contactcenter-interactions-service/issues/477)) ([9328d45](https://github.com/servicetitan/contactcenter-interactions-service/commit/9328d458ad9b9c9afc45e7399aafdb89de36c4e7))
* **CCPH-634:** Store enums as string in DB with new update ([#469](https://github.com/servicetitan/contactcenter-interactions-service/issues/469)) ([8834c3f](https://github.com/servicetitan/contactcenter-interactions-service/commit/8834c3feb633fd776d3c7cc71f795d59b9ab8e79))
* **CCPH-766:** Remove ProcessFromAbandoned sub ([#472](https://github.com/servicetitan/contactcenter-interactions-service/issues/472)) ([7b10c9c](https://github.com/servicetitan/contactcenter-interactions-service/commit/7b10c9ca9610e968f0f6c0ecb82103e5249fac19))
* **OC-31615:** ingress path type ([#458](https://github.com/servicetitan/contactcenter-interactions-service/issues/458)) ([e917cc3](https://github.com/servicetitan/contactcenter-interactions-service/commit/e917cc377fad8def43af7a6e787c97ec9730e34d))


### Chores

* **CCP-3221:** additional logging ([#451](https://github.com/servicetitan/contactcenter-interactions-service/issues/451)) ([6e612e6](https://github.com/servicetitan/contactcenter-interactions-service/commit/6e612e6f2a4f1d5ad074ffcce4f27cc4b30c26d6))
* **CCP-3221:** logging level tweak ([#448](https://github.com/servicetitan/contactcenter-interactions-service/issues/448)) ([37f4ac3](https://github.com/servicetitan/contactcenter-interactions-service/commit/37f4ac37d68660e0b9911e5e335b1c5b24cb3126))
* **CCP-4175:** Rename load test folder and update tags ([#442](https://github.com/servicetitan/contactcenter-interactions-service/issues/442)) ([700b1d8](https://github.com/servicetitan/contactcenter-interactions-service/commit/700b1d8daf2205e64abf3656f4dce71892d41d89))
* **CCP-4692:** Create github actions for running performance/load tests ([#433](https://github.com/servicetitan/contactcenter-interactions-service/issues/433)) ([84e8100](https://github.com/servicetitan/contactcenter-interactions-service/commit/84e810088f65fbc2e5f974b3a7d12c524e0047c1))
* **CCP-4715:** Add load test for common v2 api endpoints ([#431](https://github.com/servicetitan/contactcenter-interactions-service/issues/431)) ([86cc243](https://github.com/servicetitan/contactcenter-interactions-service/commit/86cc243128df6ac3d75fde2d9e8e5fd38b5e9d3d))
* **CCP-4718:** Add event based load tests ([#450](https://github.com/servicetitan/contactcenter-interactions-service/issues/450)) ([811b9f4](https://github.com/servicetitan/contactcenter-interactions-service/commit/811b9f41938de8a3401bc88b511f522cc382dc31))
* **CCP-4879:** Move GetCampaignAsync() from DataService to TenantRepository ([#444](https://github.com/servicetitan/contactcenter-interactions-service/issues/444)) ([14f3023](https://github.com/servicetitan/contactcenter-interactions-service/commit/14f302348e19bfcb8a4f30513630b26db529dd51))
* **CCP-4891:** Add ingress yaml and specify subdomain ([#454](https://github.com/servicetitan/contactcenter-interactions-service/issues/454)) ([0c3d7dd](https://github.com/servicetitan/contactcenter-interactions-service/commit/0c3d7dd0890bd5bdf414d9a79cad1687f1e811c9))
* **CCP-4891:** Expose interactions via ingress for load testing. ([#447](https://github.com/servicetitan/contactcenter-interactions-service/issues/447)) ([3fe7379](https://github.com/servicetitan/contactcenter-interactions-service/commit/3fe737984712f84595e1ada245851e8da0e3ec76))
* **CCP-4891:** Expose interactions via ingress for load testing. ([#457](https://github.com/servicetitan/contactcenter-interactions-service/issues/457)) ([9b479aa](https://github.com/servicetitan/contactcenter-interactions-service/commit/9b479aa9f2137da337529c0a2f0e8c6f39689eb7))
* **CCP-4891:** Reverts expose interactions via ingress for load testing. ([#455](https://github.com/servicetitan/contactcenter-interactions-service/issues/455)) ([5f5f702](https://github.com/servicetitan/contactcenter-interactions-service/commit/5f5f702637bdec7c9714180788a73b24a3f7efd5))
* **CCP-5159:** Update auto-scaling configuration to ensure pods scale when there is load. ([#470](https://github.com/servicetitan/contactcenter-interactions-service/issues/470)) ([0c731ec](https://github.com/servicetitan/contactcenter-interactions-service/commit/0c731ec7538b4b011eeec9eb49107dbf80d7d24d))
* **CCPH-666:** Remove FollowUps related logic ([#465](https://github.com/servicetitan/contactcenter-interactions-service/issues/465)) ([0df3b13](https://github.com/servicetitan/contactcenter-interactions-service/commit/0df3b133438d722722e6d99a32d1c8da068b1e13))

## [1.20.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.19.0...v1.20.0) (2025-03-25)


### Features

* **CCP-3645:** Migration of interactions from v1 to v2 ([#343](https://github.com/servicetitan/contactcenter-interactions-service/issues/343)) ([b4aba76](https://github.com/servicetitan/contactcenter-interactions-service/commit/b4aba76f6d8e8b9a4669fcef60abb435e37c3d6c))
* **CCP-4002:** Test optimization ([#370](https://github.com/servicetitan/contactcenter-interactions-service/issues/370)) ([b9d051a](https://github.com/servicetitan/contactcenter-interactions-service/commit/b9d051a2469daf06bc2c38333da40814da98996b))
* **CCP-4062:** Add end point xlsx report to V2 ([#427](https://github.com/servicetitan/contactcenter-interactions-service/issues/427)) ([999915c](https://github.com/servicetitan/contactcenter-interactions-service/commit/999915c997eac0a880a028195a3f8343fb752977))


### Bug Fixes

* **CCP-4343:** Migration to backfill Unknown To numbers from post call records ([#420](https://github.com/servicetitan/contactcenter-interactions-service/issues/420)) ([859742a](https://github.com/servicetitan/contactcenter-interactions-service/commit/859742a4808e5de197a88c0c10b064dbe6b560e5))
* **CCP-4813:** Strip out Job.Summary to reduce size of messages ([#436](https://github.com/servicetitan/contactcenter-interactions-service/issues/436)) ([c9a258f](https://github.com/servicetitan/contactcenter-interactions-service/commit/c9a258f6c7a852b163f91d8cb98a59d2da2a43ad))


### Chores

* **CCP-4858:** Fix actions failing due to kafka version update ([#438](https://github.com/servicetitan/contactcenter-interactions-service/issues/438)) ([454df26](https://github.com/servicetitan/contactcenter-interactions-service/commit/454df26fdcbbe9d02adea20e2d44951cdd0f27ed))

## [1.19.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.9...v1.19.0) (2025-03-18)


### Features

* **CCP-3424:** Update HangUpBy enum to match PCS ([#421](https://github.com/servicetitan/contactcenter-interactions-service/issues/421)) ([fd76377](https://github.com/servicetitan/contactcenter-interactions-service/commit/fd7637723605bcb7d97fbf5f0a00055c2ec572a2))
* **CCP-4213:** Migration to set PrimaryUser on all historical records. ([#387](https://github.com/servicetitan/contactcenter-interactions-service/issues/387)) ([ca59a83](https://github.com/servicetitan/contactcenter-interactions-service/commit/ca59a832e3b90f2a527bb4d310b0b09d53cb86a3))


### Bug Fixes

* **CCP-4508:** Complete Va interactions based on interaction change event ([#419](https://github.com/servicetitan/contactcenter-interactions-service/issues/419)) ([615e50b](https://github.com/servicetitan/contactcenter-interactions-service/commit/615e50be15a9da20726f8d661fb1964a0c035d1e))


### Chores

* **CCP-4716:** Enable API metrics in Interactions Service ([#429](https://github.com/servicetitan/contactcenter-interactions-service/issues/429)) ([0fbd8c2](https://github.com/servicetitan/contactcenter-interactions-service/commit/0fbd8c2c4d17f75c6bfdd1930893ede64052ff02))
* **PLATZ-640:** create environments.yaml ([#425](https://github.com/servicetitan/contactcenter-interactions-service/issues/425)) ([a7690cd](https://github.com/servicetitan/contactcenter-interactions-service/commit/a7690cde7581bfac82891e9d32394a95eb0fa676))

## [1.18.9](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.8...v1.18.9) (2025-03-06)


### Bug Fixes

* **CCP-4476:** Allow OrgNode to be set via V2 endpoints ([#417](https://github.com/servicetitan/contactcenter-interactions-service/issues/417)) ([2a9f087](https://github.com/servicetitan/contactcenter-interactions-service/commit/2a9f0877fc9e59ce18d1055a12999ece8af89d62))

## [1.18.8](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.7...v1.18.8) (2025-03-05)


### Bug Fixes

* **CCP-4443:** Add more data to logs from ASB for better DLQ tracking. ([#415](https://github.com/servicetitan/contactcenter-interactions-service/issues/415)) ([9a7e527](https://github.com/servicetitan/contactcenter-interactions-service/commit/9a7e527f201c2a39de4da1453aac614c4ebdbbc6))

## [1.18.7](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.6...v1.18.7) (2025-03-04)


### Bug Fixes

* **CCP-4414:** Update hiding internal calls to only do it for completed interactions ([#413](https://github.com/servicetitan/contactcenter-interactions-service/issues/413)) ([71074a8](https://github.com/servicetitan/contactcenter-interactions-service/commit/71074a828e1cf4cb30dbdb50d41db63cc0ff7d6d))

## [1.18.6](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.5...v1.18.6) (2025-03-04)


### Bug Fixes

* **CCP-4230:** Fix search to include searching for outbound To numbers ([#408](https://github.com/servicetitan/contactcenter-interactions-service/issues/408)) ([429a651](https://github.com/servicetitan/contactcenter-interactions-service/commit/429a651d2cbd5f10697e632d584f4aa79bb643fd))
* **CCP-4354:** Fix export to not show agent number for outbound calls. ([#411](https://github.com/servicetitan/contactcenter-interactions-service/issues/411)) ([643d9d3](https://github.com/servicetitan/contactcenter-interactions-service/commit/643d9d3228a069352dc9fdc0f3b54596dab4d2ae))
* **CCP-4359:** completed at timestamp and temp disable v2 classification ([#404](https://github.com/servicetitan/contactcenter-interactions-service/issues/404)) ([e1a57dc](https://github.com/servicetitan/contactcenter-interactions-service/commit/e1a57dcbd46590e11956e6a302aeed7aac152b43))
* **CCP-4360:** reverse to and from in report ([#405](https://github.com/servicetitan/contactcenter-interactions-service/issues/405)) ([48934e3](https://github.com/servicetitan/contactcenter-interactions-service/commit/48934e37f641a7530b9a2f398dcc576fc690677a))
* **CCP-4376:** Fixes conversation created messages failing and being sent to DLQ ([#407](https://github.com/servicetitan/contactcenter-interactions-service/issues/407)) ([01a85df](https://github.com/servicetitan/contactcenter-interactions-service/commit/01a85df4b6eb8ccb651ce6a0a8356c52d909961d))
* **CCP-4389:** Check `enable-v-2-interaction-classifications` FF for V2 classification ([#409](https://github.com/servicetitan/contactcenter-interactions-service/issues/409)) ([d626017](https://github.com/servicetitan/contactcenter-interactions-service/commit/d62601758043cfeb7e218a4675c4c0005efe6ccb))
* **CCP-4392:** Update conversation ended to complete interaction if last participant is a virtual agent. ([#410](https://github.com/servicetitan/contactcenter-interactions-service/issues/410)) ([f72334b](https://github.com/servicetitan/contactcenter-interactions-service/commit/f72334b9edf3538478fce93169f7feadcc149d56))


### Chores

* **CCP-4294:** Update Tenant Name using ASB ([#392](https://github.com/servicetitan/contactcenter-interactions-service/issues/392)) ([75d5cb5](https://github.com/servicetitan/contactcenter-interactions-service/commit/75d5cb5b772ce7bbbfc9a4d3f5dedf15cf4ada62))

## [1.18.5](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.4...v1.18.5) (2025-02-28)


### Bug Fixes

* **CCP-4350:** Add logging for debezium messages ([#402](https://github.com/servicetitan/contactcenter-interactions-service/issues/402)) ([754fe4a](https://github.com/servicetitan/contactcenter-interactions-service/commit/754fe4a7594659d894c7e8e86b5f90d22175bc22))

## [1.18.4](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.3...v1.18.4) (2025-02-28)


### Bug Fixes

* **CCP-4190:** Enable tracing for Azure Service Bus ([#391](https://github.com/servicetitan/contactcenter-interactions-service/issues/391)) ([eb81bcd](https://github.com/servicetitan/contactcenter-interactions-service/commit/eb81bcd79ff785aaac28f2a2256af35e125b22ea))
* **CCP-4309:** Update model so that nulls can be set in database ([#400](https://github.com/servicetitan/contactcenter-interactions-service/issues/400)) ([84d1a50](https://github.com/servicetitan/contactcenter-interactions-service/commit/84d1a50b0f920e903e571c0fd5779b567ac6e625))
* **CCPP-125:** debug log message duration field ([#379](https://github.com/servicetitan/contactcenter-interactions-service/issues/379)) ([8a04b0e](https://github.com/servicetitan/contactcenter-interactions-service/commit/8a04b0ea14f450ae624dea316872fb975a945234))

## [1.18.3](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.2...v1.18.3) (2025-02-27)


### Bug Fixes

* **CCP-4309:** Set ReviewedByUser to default option ([#398](https://github.com/servicetitan/contactcenter-interactions-service/issues/398)) ([a9695bf](https://github.com/servicetitan/contactcenter-interactions-service/commit/a9695bf84ded9ab412b2f4dc01749421bad32295))

## [1.18.2](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.1...v1.18.2) (2025-02-27)


### Bug Fixes

* **CCP-4309:** Fixes ChannelClassification getting set to null. ([#396](https://github.com/servicetitan/contactcenter-interactions-service/issues/396)) ([6c7a969](https://github.com/servicetitan/contactcenter-interactions-service/commit/6c7a969b5aef3d44aea889ce7cec0f6b13e5ef65))

## [1.18.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.18.0...v1.18.1) (2025-02-27)


### Bug Fixes

* **CCP-4309:** Model changes so that rollback is possible. ([#394](https://github.com/servicetitan/contactcenter-interactions-service/issues/394)) ([0cf9c86](https://github.com/servicetitan/contactcenter-interactions-service/commit/0cf9c86e4cda06d2f3b8a7aa37604cab9d91bfd0))

## [1.18.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.17.0...v1.18.0) (2025-02-26)


### Features

* **CCP-3217, CCP-3735:** Update classification processing for V2 ([#354](https://github.com/servicetitan/contactcenter-interactions-service/issues/354)) ([77fe887](https://github.com/servicetitan/contactcenter-interactions-service/commit/77fe88718ba3c6537017cfa458c3faf4d8987ce3))
* **CCP-3294:** correctly populate primary agent as the last session ([#384](https://github.com/servicetitan/contactcenter-interactions-service/issues/384)) ([3446199](https://github.com/servicetitan/contactcenter-interactions-service/commit/344619999d4ece1e6155b1e8832bc39448ed3976))
* **CCP-3473:** Add kafka consumer and send as azure topic ([#338](https://github.com/servicetitan/contactcenter-interactions-service/issues/338)) ([2e54b36](https://github.com/servicetitan/contactcenter-interactions-service/commit/2e54b36777c02493bb629a7ebb90f81ab141ccdf))
* **CCP-3475:** Add conversation created subscriber ([#344](https://github.com/servicetitan/contactcenter-interactions-service/issues/344)) ([0de030b](https://github.com/servicetitan/contactcenter-interactions-service/commit/0de030b6c52c0997bc723789aa875d6a9ae726fa))
* **CCP-3537, CCP-3484:** Background process to fill virtual/CSR agent name ([#357](https://github.com/servicetitan/contactcenter-interactions-service/issues/357)) ([eab1830](https://github.com/servicetitan/contactcenter-interactions-service/commit/eab1830ba5a387bcb86a7bb623e0b09424778702))
* **CCP-3633:** BE: update to save to interaction call id ([#331](https://github.com/servicetitan/contactcenter-interactions-service/issues/331)) ([fd5b913](https://github.com/servicetitan/contactcenter-interactions-service/commit/fd5b913bdf634ce5ae29b2aa4c256a52d7ce6580))
* **CCP-3708:** add and expose account id ([#347](https://github.com/servicetitan/contactcenter-interactions-service/issues/347)) ([a69dff3](https://github.com/servicetitan/contactcenter-interactions-service/commit/a69dff34b09174afdf1c7f0810fe653bab279715))
* **CCP-3790:** Add interactions search index v2 ([#352](https://github.com/servicetitan/contactcenter-interactions-service/issues/352)) ([b1ff0dd](https://github.com/servicetitan/contactcenter-interactions-service/commit/b1ff0dd2938e4d2a0fa286cb64e12148393a5904))
* **CCP-3800:** Incorporate NodaTime for conversions, DateTimeConverter update, Logging instrumentation is added ([#350](https://github.com/servicetitan/contactcenter-interactions-service/issues/350)) ([ccb5ae6](https://github.com/servicetitan/contactcenter-interactions-service/commit/ccb5ae65ed2648b6e8b307793f5c26f52c97d6e9))
* **CCP-3860:** Interaction change events with fixed contract ([#363](https://github.com/servicetitan/contactcenter-interactions-service/issues/363)) ([b92fd47](https://github.com/servicetitan/contactcenter-interactions-service/commit/b92fd47bc0d0c56870d465564a27474992e89ec1))
* **CCP-3901:** Add indexes for Interaction and PostCall collections. ([#362](https://github.com/servicetitan/contactcenter-interactions-service/issues/362)) ([6f32cf6](https://github.com/servicetitan/contactcenter-interactions-service/commit/6f32cf6e57b896ce6593ed98ca54c926476e8295))
* **CCP-3956:** on user session answered event get global user id from pcs ([#364](https://github.com/servicetitan/contactcenter-interactions-service/issues/364)) ([76ff642](https://github.com/servicetitan/contactcenter-interactions-service/commit/76ff642f2d6d077951bc6a3a75c74028a9fc5dad))
* **CCP-4004:** Return 409 from Interaction Creation endpoint when the interaction already exists for the ChannelId. ([#371](https://github.com/servicetitan/contactcenter-interactions-service/issues/371)) ([21d352a](https://github.com/servicetitan/contactcenter-interactions-service/commit/21d352a015f04468cf028b10b864780e212df69b))
* **CCP-4161:** Consuming Session Created Event ([#381](https://github.com/servicetitan/contactcenter-interactions-service/issues/381)) ([d537849](https://github.com/servicetitan/contactcenter-interactions-service/commit/d5378498a5481809486309c92303bb56a4141974))
* **CCP-4170:** Add background process to fill in Primary User's Name ([#382](https://github.com/servicetitan/contactcenter-interactions-service/issues/382)) ([c385d51](https://github.com/servicetitan/contactcenter-interactions-service/commit/c385d513a036be4aab6ef323225b0607e403414b))
* **CCP-4192:** hide internal calls ([#386](https://github.com/servicetitan/contactcenter-interactions-service/issues/386)) ([35004fc](https://github.com/servicetitan/contactcenter-interactions-service/commit/35004fcdc25db1044badb13cf5a1b2775cebdbc6))


### Bug Fixes

* **CCP-3476:** Fix logic to set org node now that it can be nullable. ([#367](https://github.com/servicetitan/contactcenter-interactions-service/issues/367)) ([8fdc24b](https://github.com/servicetitan/contactcenter-interactions-service/commit/8fdc24b1e0eb13f72e74e91c6ffa0e7440e7916e))
* **CCP-3477:** Update outbound calls to be completed automatically ([#366](https://github.com/servicetitan/contactcenter-interactions-service/issues/366)) ([3c9983f](https://github.com/servicetitan/contactcenter-interactions-service/commit/3c9983f9b6e45305d50ff48e8b2d686553a57164))
* **CCP-3484:** Fix calling users client to get username ([#377](https://github.com/servicetitan/contactcenter-interactions-service/issues/377)) ([b730b3e](https://github.com/servicetitan/contactcenter-interactions-service/commit/b730b3eaa8063f9361cac401ce0a010e5ec0169d))
* **CCP-3632:** Reverts to default sentiment and summary assessment status ([#365](https://github.com/servicetitan/contactcenter-interactions-service/issues/365)) ([504e612](https://github.com/servicetitan/contactcenter-interactions-service/commit/504e6127b421a13793292fa0001e752b21f96b67))
* **CCP-3790:** Fixes the search to use new v2 search fields. ([#356](https://github.com/servicetitan/contactcenter-interactions-service/issues/356)) ([51fec58](https://github.com/servicetitan/contactcenter-interactions-service/commit/51fec58236b1633089037066ae0b4d0fd126c045))
* **CCP-3972:** Fix index creation to reference correct iac branch ([#353](https://github.com/servicetitan/contactcenter-interactions-service/issues/353)) ([a6bc80d](https://github.com/servicetitan/contactcenter-interactions-service/commit/a6bc80d9e0e4ff09c1a69f3df2481df235a2ced1))
* **CCP-3996:** Use mapper for interaction change event and simplified comparer ([#369](https://github.com/servicetitan/contactcenter-interactions-service/issues/369)) ([67fb44b](https://github.com/servicetitan/contactcenter-interactions-service/commit/67fb44b18879498ff036f9f52cc972e8e957f3ef))
* **CCP-4097:** call Id on interaction record ([#380](https://github.com/servicetitan/contactcenter-interactions-service/issues/380)) ([8a34b1c](https://github.com/servicetitan/contactcenter-interactions-service/commit/8a34b1cf1c2d11d6e991c54e7bee05091b3d27ba))
* **CCP-4170:** Fix exception causing primary user name updates to go to DLQ ([#383](https://github.com/servicetitan/contactcenter-interactions-service/issues/383)) ([83e330d](https://github.com/servicetitan/contactcenter-interactions-service/commit/83e330d264d95d4f8071d944ff59d6893b6f1d9d))
* **CCP-4238:** Feature Flag to Hide/Show Outbound/Internal Calls from Conversation History ([#388](https://github.com/servicetitan/contactcenter-interactions-service/issues/388)) ([f60e99c](https://github.com/servicetitan/contactcenter-interactions-service/commit/f60e99c11ccd628a9c4c0e05e59bcfdeeb47df2d))
* **CCP-4299:** Regenerate PCS client so that duration is set properly. ([#393](https://github.com/servicetitan/contactcenter-interactions-service/issues/393)) ([1302856](https://github.com/servicetitan/contactcenter-interactions-service/commit/130285657d892e5df334a19247f7889902931354))
* **SEIN-3334:** issues with interaction updates ([#360](https://github.com/servicetitan/contactcenter-interactions-service/issues/360)) ([7f61d73](https://github.com/servicetitan/contactcenter-interactions-service/commit/7f61d73af5d5d2f066f63bbd0d3ead98bf47b58c))
* **SEIN-3334:** Optional fields annotated as required ([#358](https://github.com/servicetitan/contactcenter-interactions-service/issues/358)) ([ef21762](https://github.com/servicetitan/contactcenter-interactions-service/commit/ef2176221cb9c421acac82dd06c9dbb4fdc670ba))


### Chores

* **CCP-3632:** Revisit object definitions, required constraints and nullable types. ([#355](https://github.com/servicetitan/contactcenter-interactions-service/issues/355)) ([a8272ab](https://github.com/servicetitan/contactcenter-interactions-service/commit/a8272ab6085a127af711ed9c6846a8dc0d16af8b))
* **CCP-4022:** cleaning up error handling and logging ([#372](https://github.com/servicetitan/contactcenter-interactions-service/issues/372)) ([31e7d00](https://github.com/servicetitan/contactcenter-interactions-service/commit/31e7d00ba7a4779234ae98e13c147784d2d811aa))
* **CCPP-73:** trigger release-deploy on hotfix tag ([#375](https://github.com/servicetitan/contactcenter-interactions-service/issues/375)) ([13995a7](https://github.com/servicetitan/contactcenter-interactions-service/commit/13995a75978edb987953e1844ff032aea5771338))

## [1.17.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.16.1...v1.17.0) (2025-02-04)


### Features

* **CCP-2536, CCP-3116:** Interactions V2 API and kafka producer ([#321](https://github.com/servicetitan/contactcenter-interactions-service/issues/321)) ([943eed2](https://github.com/servicetitan/contactcenter-interactions-service/commit/943eed2167118954096086350ce5efd4547270b7))
* **CCP-3266:** Add tenant authorization at controller layer ([#318](https://github.com/servicetitan/contactcenter-interactions-service/issues/318)) ([c8ed92f](https://github.com/servicetitan/contactcenter-interactions-service/commit/c8ed92fdf9eeb9629dae4c6fae72e969216b1600))
* **CCP-3423:** Add Did identifier ([#335](https://github.com/servicetitan/contactcenter-interactions-service/issues/335)) ([c01fa5e](https://github.com/servicetitan/contactcenter-interactions-service/commit/c01fa5e19bcd5cb5577d6867bfc94dd77206e973))
* **CCP-3508:** Update call's customer and location to job's when interaction job ID changes ([#313](https://github.com/servicetitan/contactcenter-interactions-service/issues/313)) ([3d7ff02](https://github.com/servicetitan/contactcenter-interactions-service/commit/3d7ff025978a72db10bb2add787af1a4a808789b))
* **CCP-3508:** Update call's customer and location to job's when interaction job ID changes ([#339](https://github.com/servicetitan/contactcenter-interactions-service/issues/339)) ([a294ef9](https://github.com/servicetitan/contactcenter-interactions-service/commit/a294ef9da10d7d04508432aae362bcd7168539fa))
* **CCP-3590:** Add tenant query parameter to ST Web API for correct swimlane routing ([#322](https://github.com/servicetitan/contactcenter-interactions-service/issues/322)) ([ac734f8](https://github.com/servicetitan/contactcenter-interactions-service/commit/ac734f84789adc8279892ab4235ae203f046944c))
* **CCP-3597:** handle long data type in the JSON when converting to interaction object. ([#332](https://github.com/servicetitan/contactcenter-interactions-service/issues/332)) ([9d8f311](https://github.com/servicetitan/contactcenter-interactions-service/commit/9d8f311e7ef6be1b6974d47b0fc62ab97e8455b4))
* **CCP-3620:** Do not update reviewed-by for reclassification to Booked ([#302](https://github.com/servicetitan/contactcenter-interactions-service/issues/302)) ([280a4a1](https://github.com/servicetitan/contactcenter-interactions-service/commit/280a4a13ba86e7c5ad99022404a3411e089786ff))
* **CCP-3635:** Publish interaction change events to  service bus ([#340](https://github.com/servicetitan/contactcenter-interactions-service/issues/340)) ([b0f1ce3](https://github.com/servicetitan/contactcenter-interactions-service/commit/b0f1ce3e15ea37e1915df2b15f76c99d0a4c6564))
* **CCP-3734:** be introduce a feature flag on kafka producer ([#341](https://github.com/servicetitan/contactcenter-interactions-service/issues/341)) ([5d3f63c](https://github.com/servicetitan/contactcenter-interactions-service/commit/5d3f63c866072340310be5b2a00a73c334a172c1))
* **CCP-3734:** be introduce a feature flag on kafka producer ([#342](https://github.com/servicetitan/contactcenter-interactions-service/issues/342)) ([8526c11](https://github.com/servicetitan/contactcenter-interactions-service/commit/8526c1141852521f665518b32111b0b496f28876))
* **SEIN-3312, CCP-3127:** Support for VA fields and refactors ([#317](https://github.com/servicetitan/contactcenter-interactions-service/issues/317)) ([73fbb6c](https://github.com/servicetitan/contactcenter-interactions-service/commit/73fbb6ccbb7b0791c060e649273d1cbbc69654fe))


### Bug Fixes

* **CCP-3472:** Add pagination handling when fetching call reasons from jbce v2 api ([#311](https://github.com/servicetitan/contactcenter-interactions-service/issues/311)) ([3f5065c](https://github.com/servicetitan/contactcenter-interactions-service/commit/3f5065c054f7fd1d5b50992162f239826997b7ce))
* **CCP-3574:** Remove exceptions from ASB background service when gracefully shutdown ([#337](https://github.com/servicetitan/contactcenter-interactions-service/issues/337)) ([c4ff9bf](https://github.com/servicetitan/contactcenter-interactions-service/commit/c4ff9bf7f6519e71ed54f075276b72b45fab65f9))
* **CCP-3644:** Add migration to finish migrating left over v0 interaction to v1 ([#333](https://github.com/servicetitan/contactcenter-interactions-service/issues/333)) ([31a8ae5](https://github.com/servicetitan/contactcenter-interactions-service/commit/31a8ae5ffe440e03ba84f3ab199e78939c17516b))
* **CCP-3653:** Allow machine token to get interactions for all tenants. ([#330](https://github.com/servicetitan/contactcenter-interactions-service/issues/330)) ([3d22efc](https://github.com/servicetitan/contactcenter-interactions-service/commit/3d22efc00d56bb97565e373ac2f8e0dab8d5291b))


### Chores

* **CCP-3727:** Make EscalationMetric Properties Nullable ([#334](https://github.com/servicetitan/contactcenter-interactions-service/issues/334)) ([90063cb](https://github.com/servicetitan/contactcenter-interactions-service/commit/90063cb9899e1ea9b7822f08981874df80095e6d))
* **CCP-3738:** Set EscalationMetric Data Null in Database ([#336](https://github.com/servicetitan/contactcenter-interactions-service/issues/336)) ([9fd7ba8](https://github.com/servicetitan/contactcenter-interactions-service/commit/9fd7ba82b5758b1340e307eb99aae6df0822f001))

## [1.16.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.16.0...v1.16.1) (2025-01-22)


### Bug Fixes

* **CCP-3467:** Fixes flaky test on background service helper ([#308](https://github.com/servicetitan/contactcenter-interactions-service/issues/308)) ([c556e8a](https://github.com/servicetitan/contactcenter-interactions-service/commit/c556e8adda79143e32be4ae5ac7cf044d6509f92))

## [1.16.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.15.1...v1.16.0) (2025-01-22)


### Features

* **CCP-2535:** Interactions V2 Database Schema ([#256](https://github.com/servicetitan/contactcenter-interactions-service/issues/256)) ([8129e7d](https://github.com/servicetitan/contactcenter-interactions-service/commit/8129e7d41827b3e269b4228c689b3baddb01fab2))
* **PLATZ-566:** add autoscaling configuration ([#306](https://github.com/servicetitan/contactcenter-interactions-service/issues/306)) ([a01b468](https://github.com/servicetitan/contactcenter-interactions-service/commit/a01b4686919492bfae33bc32bbe4e6f367146789))


### Bug Fixes

* **CCP-2614:** participant times ([#299](https://github.com/servicetitan/contactcenter-interactions-service/issues/299)) ([ace18b8](https://github.com/servicetitan/contactcenter-interactions-service/commit/ace18b85cfd9084549c1303f771c8ed44392c696))
* **CCP-3448:** Fix the interactions search index on the from field. ([#303](https://github.com/servicetitan/contactcenter-interactions-service/issues/303)) ([9bcc1ee](https://github.com/servicetitan/contactcenter-interactions-service/commit/9bcc1ee9a68da53e8d48cf72081fce15ccdfd938))

## [1.15.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.15.0...v1.15.1) (2025-01-15)


### Bug Fixes

* **CCP-3380:** Adds BsonIgnoreExtraElements to all Interaction records to prepare for V2 migrations ([#286](https://github.com/servicetitan/contactcenter-interactions-service/issues/286)) ([475ffcc](https://github.com/servicetitan/contactcenter-interactions-service/commit/475ffcce927ead01006e066d91dfc67cb0080f48))

## [1.15.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.14.0...v1.15.0) (2025-01-10)


### Features

* **CCP-3170:** Update Interaction V1 API to use reviewed flag ([#273](https://github.com/servicetitan/contactcenter-interactions-service/issues/273)) ([9f0142a](https://github.com/servicetitan/contactcenter-interactions-service/commit/9f0142ad11df6b10886f58f34c4898daf05bb6b4))


### Bug Fixes

* **CCP-3265:** Reverts unauthorized tenant access. ([#278](https://github.com/servicetitan/contactcenter-interactions-service/issues/278)) ([4875f1f](https://github.com/servicetitan/contactcenter-interactions-service/commit/4875f1f60c1037817da0d176808701576b6ad18c))
* **CCP-3267:** Ensures that background tasks/threads log error for exceptions ([#279](https://github.com/servicetitan/contactcenter-interactions-service/issues/279)) ([de2bd90](https://github.com/servicetitan/contactcenter-interactions-service/commit/de2bd9024483ee6da18512dfdea26ee52c086f80))

## [1.14.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.13.1...v1.14.0) (2025-01-03)


### Features

* **CCP-2749:** Update to prevent unauthorized tenant access. ([#267](https://github.com/servicetitan/contactcenter-interactions-service/issues/267)) ([f49bf87](https://github.com/servicetitan/contactcenter-interactions-service/commit/f49bf87b4f7905c5730d1eeb8dfcf32853fbbcb8))
* **CCP-3184:** Update to always use OrgNodeId when calling PCS to get graybox flag ([#272](https://github.com/servicetitan/contactcenter-interactions-service/issues/272)) ([0c392f4](https://github.com/servicetitan/contactcenter-interactions-service/commit/0c392f442c0dff4b0109732c5f5e41825fb499c9))

## [1.13.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.13.0...v1.13.1) (2024-12-18)


### Bug Fixes

* **JBCE-3103:** Remove ST web API for saving reviewer info ([#268](https://github.com/servicetitan/contactcenter-interactions-service/issues/268)) ([bd09396](https://github.com/servicetitan/contactcenter-interactions-service/commit/bd093963fdbb3a971faaefa9ad2e370e2b7f8f71))

## [1.13.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.12.0...v1.13.0) (2024-12-17)


### Features

* **CCP-1534:** BE implement downloading streamed results in xlsx format ([#248](https://github.com/servicetitan/contactcenter-interactions-service/issues/248)) ([ab6dce8](https://github.com/servicetitan/contactcenter-interactions-service/commit/ab6dce8c302c06679d1a34c17891e51d46e54877))
* **CCP-2654:** Default to not return abandoned call interactions ([#249](https://github.com/servicetitan/contactcenter-interactions-service/issues/249)) ([d176e60](https://github.com/servicetitan/contactcenter-interactions-service/commit/d176e60be07ece8a20101a1bfb52ecf220a274bb))
* **CCP-2723:** Added feature flag for testing using PCS graybox api. ([#251](https://github.com/servicetitan/contactcenter-interactions-service/issues/251)) ([50ffedb](https://github.com/servicetitan/contactcenter-interactions-service/commit/50ffedb04a5e0bc49422ea8da5dae1b082bca0ab))
* **CCP-2858:** Fix Date Format in XLSX File Download ([#253](https://github.com/servicetitan/contactcenter-interactions-service/issues/253)) ([13fcccc](https://github.com/servicetitan/contactcenter-interactions-service/commit/13fcccc1b059a68ca118eb19156d4d12456eb74e))

## [1.12.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.11.1...v1.12.0) (2024-12-02)


### Features

* **CCP-1964:** Add review-related fields to Interactions Service and sync them to Monolith ([#241](https://github.com/servicetitan/contactcenter-interactions-service/issues/241)) ([80126da](https://github.com/servicetitan/contactcenter-interactions-service/commit/80126da0b65a023e12b1d9ffaa70ae76f26deeec))
* **CCP-1964:** Do not update reviewer for initial call classification ([#247](https://github.com/servicetitan/contactcenter-interactions-service/issues/247)) ([51fd2d6](https://github.com/servicetitan/contactcenter-interactions-service/commit/51fd2d6cb1136a10cdfc81a6cbba8c7fdcb1afdd))


### Bug Fixes

* **CCP-2516:** "AdditionalDetail" coming back null after attempted update. ([#244](https://github.com/servicetitan/contactcenter-interactions-service/issues/244)) ([bc69bd0](https://github.com/servicetitan/contactcenter-interactions-service/commit/bc69bd070dd694d0983dfb7a5702575fffa4712c))
* **CCP-2516:** expanding tests to check for additional details update. ([#245](https://github.com/servicetitan/contactcenter-interactions-service/issues/245)) ([8634f84](https://github.com/servicetitan/contactcenter-interactions-service/commit/8634f84719621f8dcb7aa2ed1a50d7f144fa4a25))

## [1.11.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.11.0...v1.11.1) (2024-11-19)


### Chores

* **CCP-2563:** Added missing IAC for interactionjobidupdated_queue ASB queue. ([#242](https://github.com/servicetitan/contactcenter-interactions-service/issues/242)) ([7871186](https://github.com/servicetitan/contactcenter-interactions-service/commit/7871186cbeeacdf8773be0240a3538b00f8eedc4))

## [1.11.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.10.0...v1.11.0) (2024-11-13)


### Features

* **CCP-2082:** Enforce Business Logic on Call Type Editing ([#221](https://github.com/servicetitan/contactcenter-interactions-service/issues/221)) ([624f516](https://github.com/servicetitan/contactcenter-interactions-service/commit/624f516f39dbe05c2d4b52bc256644fc35ba2fda))
* **CCP-2334:** add TI sentiment and mapper ([#231](https://github.com/servicetitan/contactcenter-interactions-service/issues/231)) ([9c3c2b7](https://github.com/servicetitan/contactcenter-interactions-service/commit/9c3c2b7691664979898b78166977c9eaf3f501b3))
* **CCP-2476:** BE: update filtering to match most recent search index and PostCall filtering ([#238](https://github.com/servicetitan/contactcenter-interactions-service/issues/238)) ([53967fd](https://github.com/servicetitan/contactcenter-interactions-service/commit/53967fdf963d480955299e485bd589a88e5b097e))


### Bug Fixes

* **CCP-2272:** BE - Move sync of job number & additional detail from the classification ASB message handler to its own component. ([#225](https://github.com/servicetitan/contactcenter-interactions-service/issues/225)) ([2e43475](https://github.com/servicetitan/contactcenter-interactions-service/commit/2e43475b748568cf39617b70934ac43eb12c8410))
* **CCP-2370:** Use duration from conversation instead of calculating ([#236](https://github.com/servicetitan/contactcenter-interactions-service/issues/236)) ([2ff1a91](https://github.com/servicetitan/contactcenter-interactions-service/commit/2ff1a91ca489865e72ea2ada82775e54dc91514b))


### Chores

* **CCP-2384:** Updated Platform Diagnostics to 3.72.14 ([#235](https://github.com/servicetitan/contactcenter-interactions-service/issues/235)) ([3e530ec](https://github.com/servicetitan/contactcenter-interactions-service/commit/3e530ec36b7065d20c7d43512694872c6ca78c37))
* **CCP-2459:** Interactions Service: Updated exception alerts to use st_logging_events_total.  Revised value formatting. ([#237](https://github.com/servicetitan/contactcenter-interactions-service/issues/237)) ([d5a0429](https://github.com/servicetitan/contactcenter-interactions-service/commit/d5a0429e42c8bb8885c88302c5737c2447c15092))
* **CCP-2460:** BFF: Updated alert use of labels.exception_type. ([#240](https://github.com/servicetitan/contactcenter-interactions-service/issues/240)) ([570810c](https://github.com/servicetitan/contactcenter-interactions-service/commit/570810c56f3bbd3725a2b492e961db09b3756095))
* **CCP-2478:** BE - refactor code to better consolidate interaction record filtering. ([#239](https://github.com/servicetitan/contactcenter-interactions-service/issues/239)) ([b3f69f2](https://github.com/servicetitan/contactcenter-interactions-service/commit/b3f69f20fdf322af89e8ec76ae3a10ebaa216a1d))

## [1.10.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.9.1...v1.10.0) (2024-11-04)


### Features

* (CCP-2167) filtering for new "To" field. ([#219](https://github.com/servicetitan/contactcenter-interactions-service/issues/219)) ([3ec0c3c](https://github.com/servicetitan/contactcenter-interactions-service/commit/3ec0c3c2b6cc56aa8d2cddaea26f342ef9000354))
* CCP-2087 Cleanup of SessionId from Interaction ([#202](https://github.com/servicetitan/contactcenter-interactions-service/issues/202)) ([3abc145](https://github.com/servicetitan/contactcenter-interactions-service/commit/3abc145b334a53e3804e6b75e2409750f3a41180))
* **CCP-2325:** BE - parse and convert enum values coming from front end to CSV download service ([#228](https://github.com/servicetitan/contactcenter-interactions-service/issues/228)) ([80359ee](https://github.com/servicetitan/contactcenter-interactions-service/commit/80359eeaeb8151968ece55fae1a208e8c55fed7a))
* **SEIN-2707:** Add query param to get interactions by call ID ([#226](https://github.com/servicetitan/contactcenter-interactions-service/issues/226)) ([978a0f1](https://github.com/servicetitan/contactcenter-interactions-service/commit/978a0f1da49c80cddf8682fcc050da0add89b449))


### Chores

* **SP-3807:** update check pr action to enforce pr title ([#232](https://github.com/servicetitan/contactcenter-interactions-service/issues/232)) ([35125fb](https://github.com/servicetitan/contactcenter-interactions-service/commit/35125fb870568b5f510441b2f978c6121c144968))

## [1.9.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.9.0...v1.9.1) (2024-10-23)


### Chores

* **CCP-2180:** skip duplicate Post-Call-Transcript-Created messages ([#220](https://github.com/servicetitan/contactcenter-interactions-service/issues/220)) ([a867226](https://github.com/servicetitan/contactcenter-interactions-service/commit/a86722630e6347457c7b7aa38f5c031cca9b4175))

## [1.9.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.8.0...v1.9.0) (2024-10-22)


### Features

* Update Call Type/Reason UI (CCP-1577) ([#139](https://github.com/servicetitan/contactcenter-interactions-service/issues/139)) ([073cad3](https://github.com/servicetitan/contactcenter-interactions-service/commit/073cad3a93ddc4c34822fc1ccfd39330af955e16))


### Bug Fixes

* log levels and retries (CCP-2192) ([#214](https://github.com/servicetitan/contactcenter-interactions-service/issues/214)) ([cf4df60](https://github.com/servicetitan/contactcenter-interactions-service/commit/cf4df600f4679920e2198d2dcfa5b7612fda1cfe))
* Revert "feat: Update Call Type/Reason UI (CCP-1577)" ([#223](https://github.com/servicetitan/contactcenter-interactions-service/issues/223)) ([8c742a2](https://github.com/servicetitan/contactcenter-interactions-service/commit/8c742a2677ecaa05461ae3fe4d3ca89087f9036c))

## [1.8.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.7.5...v1.8.0) (2024-10-18)


### Features

* update log level (CCP-2151) ([#207](https://github.com/servicetitan/contactcenter-interactions-service/issues/207)) ([42f9b67](https://github.com/servicetitan/contactcenter-interactions-service/commit/42f9b6752c68688b2535ca00c4e1024844c08de8))


### Bug Fixes

* update follow up service codegen ([#218](https://github.com/servicetitan/contactcenter-interactions-service/issues/218)) ([3dfcae8](https://github.com/servicetitan/contactcenter-interactions-service/commit/3dfcae837cfad23e3cba2db485e76de33fb01cd0))


### Chores

* Interactions Service: Added Warning logging for caught exceptions ([#217](https://github.com/servicetitan/contactcenter-interactions-service/issues/217)) ([9e8a8a1](https://github.com/servicetitan/contactcenter-interactions-service/commit/9e8a8a18d1330e3b4bdd4b50223cb4dd03506123))
* Interactions Service: Enabled Critical severity Prometheus alerts.  Added ASB metrics and alerts. ([#206](https://github.com/servicetitan/contactcenter-interactions-service/issues/206)) ([a2bd832](https://github.com/servicetitan/contactcenter-interactions-service/commit/a2bd83207f94f3092646984f2a7845225e95b6db))

## [1.7.5](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.7.4...v1.7.5) (2024-10-16)


### Chores

* Pinning ubuntu version to ubuntu-22.04 ([#210](https://github.com/servicetitan/contactcenter-interactions-service/issues/210)) ([bb88781](https://github.com/servicetitan/contactcenter-interactions-service/commit/bb887811a253741baf96d6dd876690e0f1d6db13))

## [1.7.4](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.7.3...v1.7.4) (2024-10-16)


### Bug Fixes

* Properly register kafka message producer ([#208](https://github.com/servicetitan/contactcenter-interactions-service/issues/208)) ([103958a](https://github.com/servicetitan/contactcenter-interactions-service/commit/103958aed0ce3c8e9031c19914454b66168b9449))

## [1.7.3](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.7.2...v1.7.3) (2024-10-14)


### Bug Fixes

* Fix message handler scope disposal ([#203](https://github.com/servicetitan/contactcenter-interactions-service/issues/203)) ([3d95613](https://github.com/servicetitan/contactcenter-interactions-service/commit/3d95613f0932d9cf1e7082c9323c046f69545959))

## [1.7.2](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.7.1...v1.7.2) (2024-10-11)


### Chores

* Revised Interactions Service resource alerts to expose labels ([#197](https://github.com/servicetitan/contactcenter-interactions-service/issues/197)) ([3c0dae2](https://github.com/servicetitan/contactcenter-interactions-service/commit/3c0dae27794ebcb2e88d98ffa20dc3f0464b4ebf))

## [1.7.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.7.0...v1.7.1) (2024-10-10)


### Bug Fixes

* default call reason to null (CCP-2103) ([#199](https://github.com/servicetitan/contactcenter-interactions-service/issues/199)) ([dfa1cb7](https://github.com/servicetitan/contactcenter-interactions-service/commit/dfa1cb749a2232ab3bef8a6af68d33c7a4b8bb2d))

## [1.7.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.6.0...v1.7.0) (2024-10-10)


### Features

* CCP-1532: BE - Update InteractionsRepository to Support Streaming of All Records (Not Just Paged Results) ([#156](https://github.com/servicetitan/contactcenter-interactions-service/issues/156)) ([c3367f1](https://github.com/servicetitan/contactcenter-interactions-service/commit/c3367f14e489609de1ca67044d431df97c6837b7))

## [1.6.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.5.6...v1.6.0) (2024-10-07)


### Features

* switch release-please to use app token ([#195](https://github.com/servicetitan/contactcenter-interactions-service/issues/195)) ([802aa3f](https://github.com/servicetitan/contactcenter-interactions-service/commit/802aa3f0a72bf2da12ee7f9306080c79353c4252))


### Bug Fixes

* **CCP-1877:** helm template escaping for alerts ([#191](https://github.com/servicetitan/contactcenter-interactions-service/issues/191)) ([d7412df](https://github.com/servicetitan/contactcenter-interactions-service/commit/d7412df1f2deedd336acb41666bc31e106196dc7))
* Do not fetch interaction for abandoned call post flow, check feature flag with anonymous org ([#190](https://github.com/servicetitan/contactcenter-interactions-service/issues/190)) ([f9883b4](https://github.com/servicetitan/contactcenter-interactions-service/commit/f9883b48093805f8437c6507bff880513b44d427))
* scl processing, followups processing, tenant name fetching, other fixes ([#182](https://github.com/servicetitan/contactcenter-interactions-service/issues/182)) ([3e6e10a](https://github.com/servicetitan/contactcenter-interactions-service/commit/3e6e10a139a81652df39de7876e9d267f093a341))


### Chores

* alert test ([#192](https://github.com/servicetitan/contactcenter-interactions-service/issues/192)) ([3db85b9](https://github.com/servicetitan/contactcenter-interactions-service/commit/3db85b9cd93b1676b8bf2bd29d68c841bedf2713))
* Interactions alert updates ([#188](https://github.com/servicetitan/contactcenter-interactions-service/issues/188)) ([99b4712](https://github.com/servicetitan/contactcenter-interactions-service/commit/99b4712f15af5ec6f97460abf9faae778396a1bf))
* Test alert update (percentage formatting) ([#194](https://github.com/servicetitan/contactcenter-interactions-service/issues/194)) ([ab068c0](https://github.com/servicetitan/contactcenter-interactions-service/commit/ab068c03824e1baab6ff515eec29eb27ef3de8ad))

## [1.5.6](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.5.5...v1.5.6) (2024-09-26)


### Bug Fixes

* Population of from/to on call creation ([#179](https://github.com/servicetitan/contactcenter-interactions-service/issues/179)) ([c527e03](https://github.com/servicetitan/contactcenter-interactions-service/commit/c527e038142025e6cd51e99e82c6bffa71a487c9))


### Chores

* Interactions service alerts ([#178](https://github.com/servicetitan/contactcenter-interactions-service/issues/178)) ([7207ae8](https://github.com/servicetitan/contactcenter-interactions-service/commit/7207ae805084929e2c0949b06b294777d59a4f3b))
* Update Interactions service alerts ([#181](https://github.com/servicetitan/contactcenter-interactions-service/issues/181)) ([e3f0b6f](https://github.com/servicetitan/contactcenter-interactions-service/commit/e3f0b6ff87cd0d47c2a031b1082957080b1c0b4c))

## [1.5.5](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.5.4...v1.5.5) (2024-09-25)


### Bug Fixes

* Improve logging and fixes ([#174](https://github.com/servicetitan/contactcenter-interactions-service/issues/174)) ([e4ab3ee](https://github.com/servicetitan/contactcenter-interactions-service/commit/e4ab3eeb5b4d6d968253d24b04925945b98373a3))

## [1.5.4](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.5.3...v1.5.4) (2024-09-24)


### Chores

* Change HighMemoryUsage alert rule severity from high to warning ([#172](https://github.com/servicetitan/contactcenter-interactions-service/issues/172)) ([f76cc5f](https://github.com/servicetitan/contactcenter-interactions-service/commit/f76cc5fce4d8f4abb23b83973251c88bf5400966))

## [1.5.3](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.5.2...v1.5.3) (2024-09-24)


### Bug Fixes

* Update secret keys for STV2ApiClient ([#170](https://github.com/servicetitan/contactcenter-interactions-service/issues/170)) ([cc0e94e](https://github.com/servicetitan/contactcenter-interactions-service/commit/cc0e94e604d08b911d7a92bd29ff0d0da59cde4b))

## [1.5.2](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.5.1...v1.5.2) (2024-09-24)


### Chores

* trying to escape {{ for helm ([#168](https://github.com/servicetitan/contactcenter-interactions-service/issues/168)) ([35fcbca](https://github.com/servicetitan/contactcenter-interactions-service/commit/35fcbcabfbc3b8f6605f809c2c6c65e8ce145466))

## [1.5.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.4.1...v1.5.0) (2024-09-23)


### Features

* CCP-1559 STApi version update ([#159](https://github.com/servicetitan/contactcenter-interactions-service/issues/159)) ([70037a6](https://github.com/servicetitan/contactcenter-interactions-service/commit/70037a6a82d40d2efe412762c4b0d4bea73e8251))


### Bug Fixes

* Do not auto complete ASB messages ([#165](https://github.com/servicetitan/contactcenter-interactions-service/issues/165)) ([6ddfb00](https://github.com/servicetitan/contactcenter-interactions-service/commit/6ddfb0055618dc84535890b489dae1f1100b0ebd))


### Chores

* Update sample HighMemory alert for Interactions Service ([#166](https://github.com/servicetitan/contactcenter-interactions-service/issues/166)) ([f74a3b2](https://github.com/servicetitan/contactcenter-interactions-service/commit/f74a3b2c4215205f3fd43bd73c58606bef873764))

## [1.4.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.4.0...v1.4.1) (2024-09-23)


### Bug Fixes

* **CCP-1931, CCP-1949:** Fix public api usage and other fixes ([#163](https://github.com/servicetitan/contactcenter-interactions-service/issues/163)) ([bac466d](https://github.com/servicetitan/contactcenter-interactions-service/commit/bac466df0de504144f430f17650ebffd334e1fc5))
* Optimize post call flow, fix bug ([#158](https://github.com/servicetitan/contactcenter-interactions-service/issues/158)) ([1642bb0](https://github.com/servicetitan/contactcenter-interactions-service/commit/1642bb0114fd613f28ef64821746749064b7e417))


### Chores

* CCPro memory alert test2 ([#162](https://github.com/servicetitan/contactcenter-interactions-service/issues/162)) ([37be17b](https://github.com/servicetitan/contactcenter-interactions-service/commit/37be17ba1360993613acb98dc0bed236aa78363a))

## [1.4.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.3.1...v1.4.0) (2024-09-19)


### Features

* fix abandoned call followup creation (CCP-1721) ([#138](https://github.com/servicetitan/contactcenter-interactions-service/issues/138)) ([80a6d28](https://github.com/servicetitan/contactcenter-interactions-service/commit/80a6d28f6e32923829ee18b2d042a4cc45e70497))


### Bug Fixes

* Add New Interaction Timestamps ([#153](https://github.com/servicetitan/contactcenter-interactions-service/issues/153)) ([d3cf1c1](https://github.com/servicetitan/contactcenter-interactions-service/commit/d3cf1c1e41361cd34d1bd69a95d361f5c6f92767))
* ASB reprocessing ([#154](https://github.com/servicetitan/contactcenter-interactions-service/issues/154)) ([5a7b0b4](https://github.com/servicetitan/contactcenter-interactions-service/commit/5a7b0b43dbb6e14e08e43dc8a311bab05e4b428d))
* Consolidate Kafka topics, fix topic naming and other fixes ([#148](https://github.com/servicetitan/contactcenter-interactions-service/issues/148)) ([0e2972d](https://github.com/servicetitan/contactcenter-interactions-service/commit/0e2972d5c05cb98ff2767c327d9e7c3a52514892))
* Fix duplicate processing ([#157](https://github.com/servicetitan/contactcenter-interactions-service/issues/157)) ([06744fd](https://github.com/servicetitan/contactcenter-interactions-service/commit/06744fd0480417a68d5f924c6f07f106776c75b6))
* Post call classification flow fixes ([#152](https://github.com/servicetitan/contactcenter-interactions-service/issues/152)) ([5766b94](https://github.com/servicetitan/contactcenter-interactions-service/commit/5766b943ceb4178406ba4e9654e509e77de6f344))
* update interaction dto ([#155](https://github.com/servicetitan/contactcenter-interactions-service/issues/155)) ([7ad6409](https://github.com/servicetitan/contactcenter-interactions-service/commit/7ad64097d30feae3534c101c24a20cf83cd9de21))

## [1.3.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.3.0...v1.3.1) (2024-09-17)


### Bug Fixes

* Also account for enums stored as string values ([#146](https://github.com/servicetitan/contactcenter-interactions-service/issues/146)) ([b489c58](https://github.com/servicetitan/contactcenter-interactions-service/commit/b489c58bb1100579994d2d215016e1061a672373))
* Fix json object value parser ([#144](https://github.com/servicetitan/contactcenter-interactions-service/issues/144)) ([05a8414](https://github.com/servicetitan/contactcenter-interactions-service/commit/05a84140dbd96ba0cb6922fd66d5ae432e6c1c95))


### Chores

* Update authority URL in stage and prod ([#149](https://github.com/servicetitan/contactcenter-interactions-service/issues/149)) ([f4a1760](https://github.com/servicetitan/contactcenter-interactions-service/commit/f4a17603b0a71db935d9704c7aa6d28c9c840c2f))

## [1.3.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.2.0...v1.3.0) (2024-09-16)


### Features

* CCP-1376 update interaction service to be agnostic of channel ([#103](https://github.com/servicetitan/contactcenter-interactions-service/issues/103)) ([1f5d550](https://github.com/servicetitan/contactcenter-interactions-service/commit/1f5d550d41eb757977576b16db6e0c136d9e1e58))


### Bug Fixes

* add logs and filter ([#141](https://github.com/servicetitan/contactcenter-interactions-service/issues/141)) ([5bc2249](https://github.com/servicetitan/contactcenter-interactions-service/commit/5bc2249473467d0f1d744f3e82bf602656bd047e))
* add logs and fix enums ([#140](https://github.com/servicetitan/contactcenter-interactions-service/issues/140)) ([4568874](https://github.com/servicetitan/contactcenter-interactions-service/commit/456887410a844357a5664803067595dc54e6ca1e))
* make interaction classification nullable ([#142](https://github.com/servicetitan/contactcenter-interactions-service/issues/142)) ([8017813](https://github.com/servicetitan/contactcenter-interactions-service/commit/80178130d920ce26e6c2c668a2bff862e1cbb6db))
* move interaction call related data population fully to background, add CallCreatedAt ([#136](https://github.com/servicetitan/contactcenter-interactions-service/issues/136)) ([cac3f10](https://github.com/servicetitan/contactcenter-interactions-service/commit/cac3f103844072d1d3484b5c03b636b7b3f4cb74))
* Timestamp needs to be Call Created Date/Time from PCS (not interaction record) ([#134](https://github.com/servicetitan/contactcenter-interactions-service/issues/134)) ([e734fdc](https://github.com/servicetitan/contactcenter-interactions-service/commit/e734fdc9c98ec3c0f754603ba48e7d9e4795fddd))


### Chores

* Update open telemetry settings ([#137](https://github.com/servicetitan/contactcenter-interactions-service/issues/137)) ([e398316](https://github.com/servicetitan/contactcenter-interactions-service/commit/e398316e143451e922ceda146a42802498c1c769))

## [1.2.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.1.2...v1.2.0) (2024-09-11)


### Features

* set contact center id for abandoned calls followups (CCP-1723) ([#131](https://github.com/servicetitan/contactcenter-interactions-service/issues/131)) ([5acb4c0](https://github.com/servicetitan/contactcenter-interactions-service/commit/5acb4c077c969c1de9839ef5b5c5d5f531fc3df9))

## [1.1.2](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.1.1...v1.1.2) (2024-09-08)


### Bug Fixes

* **CCP-1826:** Switch customer and tenant name search to autocomplete from text to support partial matches ([#127](https://github.com/servicetitan/contactcenter-interactions-service/issues/127)) ([c640926](https://github.com/servicetitan/contactcenter-interactions-service/commit/c640926cec225760db6a07386f00bac3cc1ef552))
* Limit fuzzy and update search by phone to be autocomplete ([#129](https://github.com/servicetitan/contactcenter-interactions-service/issues/129)) ([d1c4f2e](https://github.com/servicetitan/contactcenter-interactions-service/commit/d1c4f2ea5cd82251787e3dd42a2d6bebb351d333))


### Chores

* Update search index definition ([#130](https://github.com/servicetitan/contactcenter-interactions-service/issues/130)) ([148a2fe](https://github.com/servicetitan/contactcenter-interactions-service/commit/148a2fe9610c3b5596e4ab5d42c73bd02fff1d9f))

## [1.1.1](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.1.0...v1.1.1) (2024-09-08)


### Bug Fixes

* Update search index name to match deployment name ([#125](https://github.com/servicetitan/contactcenter-interactions-service/issues/125)) ([27d2988](https://github.com/servicetitan/contactcenter-interactions-service/commit/27d298803b427ac16c1cdaa694339acd4ceb165d))

## [1.1.0](https://github.com/servicetitan/contactcenter-interactions-service/compare/v1.0.0...v1.1.0) (2024-09-06)


### Features

* add asb topics and queues ([#95](https://github.com/servicetitan/contactcenter-interactions-service/issues/95)) ([834a1a9](https://github.com/servicetitan/contactcenter-interactions-service/commit/834a1a9fb321ad5723a129f73aded2a04c23ee01))
* Add channelId filter ([#93](https://github.com/servicetitan/contactcenter-interactions-service/issues/93)) ([9eabbc8](https://github.com/servicetitan/contactcenter-interactions-service/commit/9eabbc8f01241db45f616824c430bea85c061621))
* Add escalation metrics to interactions model ([#42](https://github.com/servicetitan/contactcenter-interactions-service/issues/42)) ([014bf6c](https://github.com/servicetitan/contactcenter-interactions-service/commit/014bf6c9f13632d4a1285586bf57fc2211eed11d))
* add iac config ([#50](https://github.com/servicetitan/contactcenter-interactions-service/issues/50)) ([2ac9daf](https://github.com/servicetitan/contactcenter-interactions-service/commit/2ac9daf37907986c659895301f2247affd5ea217))
* Add IsAccurate flags ([#47](https://github.com/servicetitan/contactcenter-interactions-service/issues/47)) ([8699d20](https://github.com/servicetitan/contactcenter-interactions-service/commit/8699d20955e886a9b340cafc29fdfa982454206e))
* Add SentimentScore update capability, chore: add NodaTime, fix time flaky tests, rework test composition ([#58](https://github.com/servicetitan/contactcenter-interactions-service/issues/58)) ([524098c](https://github.com/servicetitan/contactcenter-interactions-service/commit/524098c919955c45d50f2619f23085b85e1a5b7a))
* add subscriptions ([#102](https://github.com/servicetitan/contactcenter-interactions-service/issues/102)) ([8f9b580](https://github.com/servicetitan/contactcenter-interactions-service/commit/8f9b580e8a10dc3541fa042e0a47c0e604737ed2))
* Adding activities to interactions model ([#46](https://github.com/servicetitan/contactcenter-interactions-service/issues/46)) ([a21bd07](https://github.com/servicetitan/contactcenter-interactions-service/commit/a21bd070fe833982cc9328f5dc370b65fddb09e4))
* adding sentiment fields to interaction and postCall models ([#35](https://github.com/servicetitan/contactcenter-interactions-service/issues/35)) ([66e4d73](https://github.com/servicetitan/contactcenter-interactions-service/commit/66e4d73cbabcea22455bbc5b0545544f1753a0dc))
* Adding summary to interactions model ([#43](https://github.com/servicetitan/contactcenter-interactions-service/issues/43)) ([8ef412c](https://github.com/servicetitan/contactcenter-interactions-service/commit/8ef412c41276732a4a951e97f25d4460b1e05b12))
* Agent Notes ([#48](https://github.com/servicetitan/contactcenter-interactions-service/issues/48)) ([6653029](https://github.com/servicetitan/contactcenter-interactions-service/commit/6653029b55e9d6c5f86970ef47526c9c55cc66cc))
* Allow user editing of sentiment and transcript summary ([#39](https://github.com/servicetitan/contactcenter-interactions-service/issues/39)) ([535c785](https://github.com/servicetitan/contactcenter-interactions-service/commit/535c785a194b08e4d7a4335e6a6a95bc1206bcc1))
* call classification (CCP-1373) ([#106](https://github.com/servicetitan/contactcenter-interactions-service/issues/106)) ([1963400](https://github.com/servicetitan/contactcenter-interactions-service/commit/19634008c8bc5ec7bea4e997b88a47ff2d81caef))
* ccp 626 (add a summarization status field to the post call) ([#27](https://github.com/servicetitan/contactcenter-interactions-service/issues/27)) ([9e77d4f](https://github.com/servicetitan/contactcenter-interactions-service/commit/9e77d4ff471b5b380051dac195efc81d4e2256ce))
* **CCP-1037:** add tenant name as input to create interaction endpoint ([#51](https://github.com/servicetitan/contactcenter-interactions-service/issues/51)) ([b35a669](https://github.com/servicetitan/contactcenter-interactions-service/commit/b35a669edb3d4d01ac323ce7bf6fdb93a81293af))
* **CCP-1144:** Integrate kafka consumer for call change notification and ASB topics/subs ([#105](https://github.com/servicetitan/contactcenter-interactions-service/issues/105)) ([b542844](https://github.com/servicetitan/contactcenter-interactions-service/commit/b5428447c55a5f988542656fafa0cda78676ff12))
* CCP-1385 - Add OpenTelementry logging (interactions service) ([#94](https://github.com/servicetitan/contactcenter-interactions-service/issues/94)) ([d7ff346](https://github.com/servicetitan/contactcenter-interactions-service/commit/d7ff3464f3f0ecd638b5dd7eadea48dcffd48530))
* **CCP-1411:** Integrate Prometheus Reporting and metrics endpoint ([#107](https://github.com/servicetitan/contactcenter-interactions-service/issues/107)) ([9f3c44a](https://github.com/servicetitan/contactcenter-interactions-service/commit/9f3c44acd9598bf9be7b62585a9c3e8fc62697f8))
* CCP-625 & CCP-741: interaction service Kafka consumers ([#34](https://github.com/servicetitan/contactcenter-interactions-service/issues/34)) ([930aaef](https://github.com/servicetitan/contactcenter-interactions-service/commit/930aaef721a68db03d64726e05350df52d49c905))
* **CCP-836, CCP-901:** Populate DisplayId, DurationSeconds and Channel values on interactions ([#79](https://github.com/servicetitan/contactcenter-interactions-service/issues/79)) ([b88d3c5](https://github.com/servicetitan/contactcenter-interactions-service/commit/b88d3c50e2bed914fd5abfb9795139e5cf5cb41c))
* **CCP-851:** BE: Modify query to include Sentiment Filter ([#71](https://github.com/servicetitan/contactcenter-interactions-service/issues/71)) ([bdad7e8](https://github.com/servicetitan/contactcenter-interactions-service/commit/bdad7e82976e8d748512936be267143d87e2a9d8))
* implementing retry for failing Kafka consumers ([#37](https://github.com/servicetitan/contactcenter-interactions-service/issues/37)) ([10919fd](https://github.com/servicetitan/contactcenter-interactions-service/commit/10919fdb1f03024aa5bc5f1449c6b49d2353ed41))
* interactions add sort order by all fields on UI ([#68](https://github.com/servicetitan/contactcenter-interactions-service/issues/68)) ([a866d6f](https://github.com/servicetitan/contactcenter-interactions-service/commit/a866d6f6e34a3c00beeaad33d67885e3c97c4a0a))
* Post call flow implementation (CCP-1234) ([#88](https://github.com/servicetitan/contactcenter-interactions-service/issues/88)) ([7df2de9](https://github.com/servicetitan/contactcenter-interactions-service/commit/7df2de934680dd44811519373b864902204ebfe9))
* Process PostCall Transcript Producer ([#69](https://github.com/servicetitan/contactcenter-interactions-service/issues/69)) ([76ed64e](https://github.com/servicetitan/contactcenter-interactions-service/commit/76ed64ec6bef215609a40c02bcc9ae8f70bcefd8))
* Remove null check for CallReasonName in DataService ([#123](https://github.com/servicetitan/contactcenter-interactions-service/issues/123)) ([1b4321d](https://github.com/servicetitan/contactcenter-interactions-service/commit/1b4321db77db0150709d1edf45b0f1e6617a50b0))
* Search Interactions  in Atlas ([#72](https://github.com/servicetitan/contactcenter-interactions-service/issues/72)) ([cf166f4](https://github.com/servicetitan/contactcenter-interactions-service/commit/cf166f4b2a8612f7855a831191c883161acfc5ef))
* SEIN-2071 ([#66](https://github.com/servicetitan/contactcenter-interactions-service/issues/66)) ([206379e](https://github.com/servicetitan/contactcenter-interactions-service/commit/206379e7940aa18d0d066f4c7ffc146a1bcfc67c))
* **SRE-1592:** add search index ([#110](https://github.com/servicetitan/contactcenter-interactions-service/issues/110)) ([e7f8d06](https://github.com/servicetitan/contactcenter-interactions-service/commit/e7f8d0634579f0b75e9e3908214acf0ea45c9372))
* Update AuthenticationModule to use account-service scope ([#89](https://github.com/servicetitan/contactcenter-interactions-service/issues/89)) ([c32eb88](https://github.com/servicetitan/contactcenter-interactions-service/commit/c32eb88c51bf545b1eb4be1aa5d73d110b9c8b7f))
* Update authorization policies for Interactions service ([#57](https://github.com/servicetitan/contactcenter-interactions-service/issues/57)) ([cc49ddb](https://github.com/servicetitan/contactcenter-interactions-service/commit/cc49ddb61a3617143025b3d20c4a5d1983924544))
* Update policy to require "eh.ids" scope for API access ([#44](https://github.com/servicetitan/contactcenter-interactions-service/issues/44)) ([8848475](https://github.com/servicetitan/contactcenter-interactions-service/commit/8848475a67caf2246e56a91b81cd9c700d83a133))
* update telecom call message contracts (CCP-1719) ([#118](https://github.com/servicetitan/contactcenter-interactions-service/issues/118)) ([7a424b7](https://github.com/servicetitan/contactcenter-interactions-service/commit/7a424b727811c3258047c2c1da925ae419224448))


### Bug Fixes

* add messageId for ASB messages, fix some redundancies ([#124](https://github.com/servicetitan/contactcenter-interactions-service/issues/124)) ([b520c5e](https://github.com/servicetitan/contactcenter-interactions-service/commit/b520c5e9fb940ec8ac19931437ce3c8b183eed35))
* add missing queue ([#122](https://github.com/servicetitan/contactcenter-interactions-service/issues/122)) ([5fbdcf1](https://github.com/servicetitan/contactcenter-interactions-service/commit/5fbdcf13bbb6b622018c3caa631a79d79d7d133f))
* adding ASB connection string to IAC secrets ([#40](https://github.com/servicetitan/contactcenter-interactions-service/issues/40)) ([d400d66](https://github.com/servicetitan/contactcenter-interactions-service/commit/d400d668f9ef2a507ba57b4dbb4994aeae48a3cf))
* applying json property attributes to messages coming from TI and PCS ([#41](https://github.com/servicetitan/contactcenter-interactions-service/issues/41)) ([7aeea95](https://github.com/servicetitan/contactcenter-interactions-service/commit/7aeea953c864a5f3552d8a29e31df1ad457fc98a))
* asb service group for data source ([#97](https://github.com/servicetitan/contactcenter-interactions-service/issues/97)) ([46a5ef3](https://github.com/servicetitan/contactcenter-interactions-service/commit/46a5ef336efc78a0b08b41bcdd16183caf65d41f))
* auth issuer url ([#56](https://github.com/servicetitan/contactcenter-interactions-service/issues/56)) ([415c9c9](https://github.com/servicetitan/contactcenter-interactions-service/commit/415c9c945d9cd3d703ee007ec83323d92c853b4f))
* CallTypeId check ([#92](https://github.com/servicetitan/contactcenter-interactions-service/issues/92)) ([0211d64](https://github.com/servicetitan/contactcenter-interactions-service/commit/0211d64529dfdbc328ba260e5f7e0ba0c9a8d8e4))
* CallTypeId is actually an enum, so it begins with 0 ([#90](https://github.com/servicetitan/contactcenter-interactions-service/issues/90)) ([290e0df](https://github.com/servicetitan/contactcenter-interactions-service/commit/290e0df93699ff30cf9d6f4cad8e1cd0c199e260))
* case sensitivity in sorting ([#84](https://github.com/servicetitan/contactcenter-interactions-service/issues/84)) ([a9a247b](https://github.com/servicetitan/contactcenter-interactions-service/commit/a9a247b7596cfd02e0b864618d16997852005bb2))
* **CCP-1046:** update duration seconds to float instead of int ([#52](https://github.com/servicetitan/contactcenter-interactions-service/issues/52)) ([176f9d9](https://github.com/servicetitan/contactcenter-interactions-service/commit/176f9d9338fa655b180b8a4e27610e207c8446e8))
* **CCP-1429:** better control on search query + full atlas deployment in GH action ([#99](https://github.com/servicetitan/contactcenter-interactions-service/issues/99)) ([f657be5](https://github.com/servicetitan/contactcenter-interactions-service/commit/f657be5bd335f6410bd8d21c42a481791d4ab894))
* Create SCL Evaluation in ST & SCL Follow-Up on Assessed Event ([#67](https://github.com/servicetitan/contactcenter-interactions-service/issues/67)) ([bb1f39c](https://github.com/servicetitan/contactcenter-interactions-service/commit/bb1f39cab97386a8d62308efc40df2eadab9dd15))
* deserializer settings  ([#119](https://github.com/servicetitan/contactcenter-interactions-service/issues/119)) ([286b865](https://github.com/servicetitan/contactcenter-interactions-service/commit/286b8657354af48dccd8a32857e9ad17ca0f4345))
* Do not force mandatory SearchQuery parameter ([#86](https://github.com/servicetitan/contactcenter-interactions-service/issues/86)) ([761b535](https://github.com/servicetitan/contactcenter-interactions-service/commit/761b53537ab1524cf551c1b050345591caeae77c))
* error in asb tf ([#96](https://github.com/servicetitan/contactcenter-interactions-service/issues/96)) ([ddfd529](https://github.com/servicetitan/contactcenter-interactions-service/commit/ddfd5292c414e8352610e9e7265d24dc02a2a74e))
* Fix deserialization of outdated model from mongo: ignore non-matching elements. ([#73](https://github.com/servicetitan/contactcenter-interactions-service/issues/73)) ([ea1d9bc](https://github.com/servicetitan/contactcenter-interactions-service/commit/ea1d9bceee7f7136399bcaa6269a363bf6da8894))
* Fix PostCall model deserialize ([#74](https://github.com/servicetitan/contactcenter-interactions-service/issues/74)) ([b470503](https://github.com/servicetitan/contactcenter-interactions-service/commit/b4705039ef89986bb7bef36c4bc44c37f1eed76d))
* force  test config and not dev config ([#80](https://github.com/servicetitan/contactcenter-interactions-service/issues/80)) ([d87fcb0](https://github.com/servicetitan/contactcenter-interactions-service/commit/d87fcb075e08b0afb7f95b339325a7d9160a4fa6))
* IAC config for V2 API ([#61](https://github.com/servicetitan/contactcenter-interactions-service/issues/61)) ([a2beb3c](https://github.com/servicetitan/contactcenter-interactions-service/commit/a2beb3c9b412ae7d8f46906aa63e6e50ad876ddb))
* Interaction mapper missing a field ([#63](https://github.com/servicetitan/contactcenter-interactions-service/issues/63)) ([7d0b58e](https://github.com/servicetitan/contactcenter-interactions-service/commit/7d0b58e2f4cd71fd339f94ae5806b306302cff05))
* Reverting Summary does not allow the user to rate original summary ([#91](https://github.com/servicetitan/contactcenter-interactions-service/issues/91)) ([0d85c95](https://github.com/servicetitan/contactcenter-interactions-service/commit/0d85c95f4a629526cb033fa078db16c16fad6488))
* SEIN-2070 Adds `FollowUpsRepository` ([#62](https://github.com/servicetitan/contactcenter-interactions-service/issues/62)) ([3599135](https://github.com/servicetitan/contactcenter-interactions-service/commit/3599135b0b03f812374b1c646a75884ef6cb6816))
* SEIN-2070 Adds FollowUps service generated code and DI ([#59](https://github.com/servicetitan/contactcenter-interactions-service/issues/59)) ([eaa9cd4](https://github.com/servicetitan/contactcenter-interactions-service/commit/eaa9cd4676a5198a3dd7227339cffddfbe5ed341))
* SEIN-2071 Fix the sort direction for interactions query ([#78](https://github.com/servicetitan/contactcenter-interactions-service/issues/78)) ([d2d41cc](https://github.com/servicetitan/contactcenter-interactions-service/commit/d2d41cc0a4ce8bced2cc1488fbc3d6d7e777d0a0))
* SEIN-2071 Remove CallSid from interaction ([#77](https://github.com/servicetitan/contactcenter-interactions-service/issues/77)) ([b730406](https://github.com/servicetitan/contactcenter-interactions-service/commit/b73040691a05d50764448fdb2b40c8a752d281d7))
* SEIN-2109 Adds `MonolithRepository` ([#65](https://github.com/servicetitan/contactcenter-interactions-service/issues/65)) ([72595fc](https://github.com/servicetitan/contactcenter-interactions-service/commit/72595fc17011da4df1722ff6530ca361d4a4ff06))
* service bus connection string ([#101](https://github.com/servicetitan/contactcenter-interactions-service/issues/101)) ([fec6472](https://github.com/servicetitan/contactcenter-interactions-service/commit/fec6472cc459cd30682ae793476debf85d393cd2))
* Startup and service issues ([#33](https://github.com/servicetitan/contactcenter-interactions-service/issues/33)) ([894cd09](https://github.com/servicetitan/contactcenter-interactions-service/commit/894cd095326733b742213e7d559b69645a52da43))
* tf for index ([#112](https://github.com/servicetitan/contactcenter-interactions-service/issues/112)) ([8ca3f52](https://github.com/servicetitan/contactcenter-interactions-service/commit/8ca3f52e528c29a24cd10c02d7df4b84f6703631))
* typo in bus name ([#120](https://github.com/servicetitan/contactcenter-interactions-service/issues/120)) ([11557cd](https://github.com/servicetitan/contactcenter-interactions-service/commit/11557cd870718b4c8c25fc205a1067af27c0e035))
* typo in sb sub tf ([#104](https://github.com/servicetitan/contactcenter-interactions-service/issues/104)) ([6c9acb0](https://github.com/servicetitan/contactcenter-interactions-service/commit/6c9acb0ccc37e79b6d8a6892acda7074801e847e))
* Update displayId to a required string ([#45](https://github.com/servicetitan/contactcenter-interactions-service/issues/45)) ([b35f6bf](https://github.com/servicetitan/contactcenter-interactions-service/commit/b35f6bf95abb625bc873acf691761ec028d19945))
* update followups-service codegen ([#70](https://github.com/servicetitan/contactcenter-interactions-service/issues/70)) ([1d72616](https://github.com/servicetitan/contactcenter-interactions-service/commit/1d72616f0073908f9c47096737e2b2371d1744e6))
* update post call record (CCP-1760) ([#121](https://github.com/servicetitan/contactcenter-interactions-service/issues/121)) ([e3deb7a](https://github.com/servicetitan/contactcenter-interactions-service/commit/e3deb7a044e23927cea18a268d9ee316cefb69de))
* Update secret keys for ST API ([#76](https://github.com/servicetitan/contactcenter-interactions-service/issues/76)) ([6bec496](https://github.com/servicetitan/contactcenter-interactions-service/commit/6bec496fb8bf9e40c61d4b6f87ff3c143afda4d5))


### Chores

* Add CSharpier formatter ([#115](https://github.com/servicetitan/contactcenter-interactions-service/issues/115)) ([82f61ec](https://github.com/servicetitan/contactcenter-interactions-service/commit/82f61ece189c9a553c3e807ab1e95f53616ec845))
* Add SonarScanner ([#54](https://github.com/servicetitan/contactcenter-interactions-service/issues/54)) ([e820aad](https://github.com/servicetitan/contactcenter-interactions-service/commit/e820aad1fbdd3028e74b2bb620c888a409f80f5d))
* Add StyleCop and threading analyzers ([#108](https://github.com/servicetitan/contactcenter-interactions-service/issues/108)) ([cd09263](https://github.com/servicetitan/contactcenter-interactions-service/commit/cd092631e85797d9528744fc1a25ac207f468054))
* Add support for Mongo migrations ([#85](https://github.com/servicetitan/contactcenter-interactions-service/issues/85)) ([978e4b4](https://github.com/servicetitan/contactcenter-interactions-service/commit/978e4b43e02cfe761f64e269fb85ce87635b1e26))
* Address StyleCop and analyzer issues from prev commit ([#109](https://github.com/servicetitan/contactcenter-interactions-service/issues/109)) ([ec7e700](https://github.com/servicetitan/contactcenter-interactions-service/commit/ec7e700f27d919eb38672cf1cd117f2bb4b58649))
* **CCP-1087:** Add Failed summary assessment status ([#64](https://github.com/servicetitan/contactcenter-interactions-service/issues/64)) ([4250373](https://github.com/servicetitan/contactcenter-interactions-service/commit/42503731e322a0bafb5a312aa2fe42eb41082dfe))
* **CCP-1410:** Adjust logging to use Platform Logger ([#98](https://github.com/servicetitan/contactcenter-interactions-service/issues/98)) ([59cfa81](https://github.com/servicetitan/contactcenter-interactions-service/commit/59cfa81de5ad5e09377b91fb339f29ffde0af7a1))
* CCP-1605: BE: Update Project and Instance label for Interaction Service deployment.yaml.tpl ([#111](https://github.com/servicetitan/contactcenter-interactions-service/issues/111)) ([d29779f](https://github.com/servicetitan/contactcenter-interactions-service/commit/d29779f0d3167045fe4cb4e9d03ede849897ecde))
* CCP-712: Handle query params being sent by BFF ([#36](https://github.com/servicetitan/contactcenter-interactions-service/issues/36)) ([6a52fe8](https://github.com/servicetitan/contactcenter-interactions-service/commit/6a52fe87bafae4387ccd05c2cef05076b6074c69))
* **deps:** bump pymongo from 4.2.0 to 4.6.3 in /docker-compose in the pip group across 1 directory ([#31](https://github.com/servicetitan/contactcenter-interactions-service/issues/31)) ([6024462](https://github.com/servicetitan/contactcenter-interactions-service/commit/602446222e5e0d83c486440a92296378bb836b85))
* docker compose for mongo and kafka ([#28](https://github.com/servicetitan/contactcenter-interactions-service/issues/28)) ([d5f728b](https://github.com/servicetitan/contactcenter-interactions-service/commit/d5f728bf79f8276a8f9e773d1bea0b7360bfb266))
* Improved db seeding ([#81](https://github.com/servicetitan/contactcenter-interactions-service/issues/81)) ([b74c8cf](https://github.com/servicetitan/contactcenter-interactions-service/commit/b74c8cf4097be8ed2696ecfe54fc0db31eefe210))
* Interactions service cleanup ([#53](https://github.com/servicetitan/contactcenter-interactions-service/issues/53)) ([eb27b8d](https://github.com/servicetitan/contactcenter-interactions-service/commit/eb27b8dd1dcab44822af831d8153a843e0ca33cb))
* Metrics, logging and more ([#113](https://github.com/servicetitan/contactcenter-interactions-service/issues/113)) ([de4140e](https://github.com/servicetitan/contactcenter-interactions-service/commit/de4140e8fc2c7508b678db4fe4f9917e43ded817))
* Org Nodes ([#55](https://github.com/servicetitan/contactcenter-interactions-service/issues/55)) ([5c11abe](https://github.com/servicetitan/contactcenter-interactions-service/commit/5c11abee803f09795f10d43f218242958ced5bc2))
* removed tutorials from mongo.Dockerfile ([#30](https://github.com/servicetitan/contactcenter-interactions-service/issues/30)) ([67f4d55](https://github.com/servicetitan/contactcenter-interactions-service/commit/67f4d558d1be98b24f8934fbc812cc2f2dbdeb80))
* removing call transcript meta data from post call model ([#49](https://github.com/servicetitan/contactcenter-interactions-service/issues/49)) ([80d7cbb](https://github.com/servicetitan/contactcenter-interactions-service/commit/80d7cbba78c7ddde229eda811dc8006b4b6547b0))
* Replace docker-compose file ([#38](https://github.com/servicetitan/contactcenter-interactions-service/issues/38)) ([2de0afe](https://github.com/servicetitan/contactcenter-interactions-service/commit/2de0afec796dc72ae66db0a2413dd1be37feae57))
* SEIN-2162 add testing endpoints for producing kafka events ([#82](https://github.com/servicetitan/contactcenter-interactions-service/issues/82)) ([b8ad0b5](https://github.com/servicetitan/contactcenter-interactions-service/commit/b8ad0b5dce0d2689959a7960ca65d9d10e5293a1))
* SEIN-2167 Update followup creation requests ([#87](https://github.com/servicetitan/contactcenter-interactions-service/issues/87)) ([883eade](https://github.com/servicetitan/contactcenter-interactions-service/commit/883eadef604ca8a60f1375ee1ad4a252e6027e5d))
* Update appsettings.Development.json with new QA BaseUrl and Au… ([#116](https://github.com/servicetitan/contactcenter-interactions-service/issues/116)) ([fb5da04](https://github.com/servicetitan/contactcenter-interactions-service/commit/fb5da044a1dee1f238dfbfffc927b81a6b148910))
* update gitignore to exclude coverage report and local appsettings ([#75](https://github.com/servicetitan/contactcenter-interactions-service/issues/75)) ([58b10cf](https://github.com/servicetitan/contactcenter-interactions-service/commit/58b10cf1147f24667aa6d9f9489061e4a9eb65fa))
* Upgrade packages, global usings, .editorconfig ([#114](https://github.com/servicetitan/contactcenter-interactions-service/issues/114)) ([edc5d02](https://github.com/servicetitan/contactcenter-interactions-service/commit/edc5d02c09c1df8dbfb92bce2e30c0aaf1074e29))

## 1.0.0 (2024-05-28)


### Features

* Add jwt auth with user context ([#22](https://github.com/servicetitan/contactcenter-interactions-service/issues/22)) ([c03c519](https://github.com/servicetitan/contactcenter-interactions-service/commit/c03c5193bb72a44e6d17bb9ee1a7a7e7c6981aaf))
* added pagedResults to post calls API ([#19](https://github.com/servicetitan/contactcenter-interactions-service/issues/19)) ([bf8d083](https://github.com/servicetitan/contactcenter-interactions-service/commit/bf8d0837af4b8e45eeac9b7f8b705445fec59201))
* Connect database at service level ([#21](https://github.com/servicetitan/contactcenter-interactions-service/issues/21)) ([f2bd5f3](https://github.com/servicetitan/contactcenter-interactions-service/commit/f2bd5f3da537de44bb6224f1500bd44912a6b0b6))
* setup docker-compose ([#14](https://github.com/servicetitan/contactcenter-interactions-service/issues/14)) ([1b125f6](https://github.com/servicetitan/contactcenter-interactions-service/commit/1b125f6c376126a3d8bdc77ceaa466f64c05b6f1))
* Switch to prefixed interaction id ([#25](https://github.com/servicetitan/contactcenter-interactions-service/issues/25)) ([25de6c1](https://github.com/servicetitan/contactcenter-interactions-service/commit/25de6c1abe8f112418873a15e83bd60581e25638))
* Update healthcheck with env and version ([#23](https://github.com/servicetitan/contactcenter-interactions-service/issues/23)) ([f7c3beb](https://github.com/servicetitan/contactcenter-interactions-service/commit/f7c3beb27d0af8b2c5f9b250bad1cd19fb5ad1c3))
* Update README and ignore .env.txt ([#6](https://github.com/servicetitan/contactcenter-interactions-service/issues/6)) ([f347cc2](https://github.com/servicetitan/contactcenter-interactions-service/commit/f347cc20d204cff553ecd10a7760c05dc5045088))
* Use annotations for input validation ([#24](https://github.com/servicetitan/contactcenter-interactions-service/issues/24)) ([6472727](https://github.com/servicetitan/contactcenter-interactions-service/commit/6472727e818e2535987d86726934dd61df07bcb0))
* Used paged Interactions result ([#18](https://github.com/servicetitan/contactcenter-interactions-service/issues/18)) ([e0e0781](https://github.com/servicetitan/contactcenter-interactions-service/commit/e0e0781c0c1eb5a09785b77a499682ac220313ec))


### Bug Fixes

* **ci:** update service naming in chart/workflows ([424323a](https://github.com/servicetitan/contactcenter-interactions-service/commit/424323a12425432a73867004bf0b4cc8e68b2c7b))


### Chores

* Add editorconfig and GitHub Actions workflow for formatting ([#26](https://github.com/servicetitan/contactcenter-interactions-service/issues/26)) ([920f540](https://github.com/servicetitan/contactcenter-interactions-service/commit/920f5406015245082f7111fb946329d13365fbdc))
* Add GitHub workflows for auto author assign, PR checks, etc ([#8](https://github.com/servicetitan/contactcenter-interactions-service/issues/8)) ([eebe7cb](https://github.com/servicetitan/contactcenter-interactions-service/commit/eebe7cb50ab719a2a4ab6da81b29e61c7c995cd4))
* added additional controller tests ([#15](https://github.com/servicetitan/contactcenter-interactions-service/issues/15)) ([67467fa](https://github.com/servicetitan/contactcenter-interactions-service/commit/67467fa875f0a47bf67682d06358b3a6db327ec5))
* added tests to controllers, made some interactions fields nullable ([#13](https://github.com/servicetitan/contactcenter-interactions-service/issues/13)) ([44a5a01](https://github.com/servicetitan/contactcenter-interactions-service/commit/44a5a01353089ac80b4a96cc65f873ed71f0a972))
* removing logic from consumers (JBCE to reimplement) ([#12](https://github.com/servicetitan/contactcenter-interactions-service/issues/12)) ([9220d92](https://github.com/servicetitan/contactcenter-interactions-service/commit/9220d92597ee9b7dbfd11652c56c8dac8a966316))
* Test framework with Mongodb ([#5](https://github.com/servicetitan/contactcenter-interactions-service/issues/5)) ([1073aca](https://github.com/servicetitan/contactcenter-interactions-service/commit/1073acabdf06880e118cb6b1605759ff5771045e))
* Update .gitignore to match web-app-template ([#9](https://github.com/servicetitan/contactcenter-interactions-service/issues/9)) ([8f7bb25](https://github.com/servicetitan/contactcenter-interactions-service/commit/8f7bb25635d8312dac4790d9427e901bb1615a3e))
* Update code coverage parameters ([#11](https://github.com/servicetitan/contactcenter-interactions-service/issues/11)) ([3cbb294](https://github.com/servicetitan/contactcenter-interactions-service/commit/3cbb2947ccebca10a832bc65e3ecedd2ee1d38bb))
* Update CODEOWNERS file to include @servicetitan/contactcenter ([#7](https://github.com/servicetitan/contactcenter-interactions-service/issues/7)) ([b34c059](https://github.com/servicetitan/contactcenter-interactions-service/commit/b34c0598fb48c4720bbb6b575f56305c878c2317))
* Update mongodb version in build-test github workflow ([#20](https://github.com/servicetitan/contactcenter-interactions-service/issues/20)) ([f61cf18](https://github.com/servicetitan/contactcenter-interactions-service/commit/f61cf1871a04743283e440ae4fffd3cfbdf480d5))
* Update release-please.yml to use simple release type ([#16](https://github.com/servicetitan/contactcenter-interactions-service/issues/16)) ([3d4806c](https://github.com/servicetitan/contactcenter-interactions-service/commit/3d4806c8273ac1c0adc78bb6118028fb141de1d9))
