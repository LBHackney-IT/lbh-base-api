.PHONY: setup
setup:
	docker-compose build

.PHONY: serve
serve:
	docker-compose up transactions-api
