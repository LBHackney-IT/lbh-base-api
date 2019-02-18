.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose run transactions-api dotnet build

.PHONY: serve
serve:
	docker-compose up transactions-api

.PHONY: shell
shell:
	docker-compose run transactions-api bash

.PHONY: test
test:
	docker-compose build transactions-api-test && docker-compose run transactions-api-test

