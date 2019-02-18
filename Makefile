.PHONY: setup
setup:
	docker-compose build

.PHONY: serve
serve:
	docker-compose up transactions-api

.PHONY: build
build:
	docker-compose run transactions-api dotnet build
