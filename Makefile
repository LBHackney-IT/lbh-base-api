.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose build base-api

.PHONY: serve
serve:
	docker-compose build base-api && docker-compose up base-api

.PHONY: shell
shell:
	docker-compose run base-api bash

.PHONY: test
test:
	docker-compose up test-database & docker-compose build base-api-test && docker-compose up base-api-test

.PHONY: lint
lint:
	-dotnet tool install -g dotnet-format
	dotnet tool update -g dotnet-format
	dotnet format
