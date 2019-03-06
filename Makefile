.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose run base-api dotnet build

.PHONY: serve
serve:
	docker-compose up base-api

.PHONY: shell
shell:
	docker-compose run base-api bash

.PHONY: test
test:
	docker-compose build base-api-test && docker-compose up base-api-test
