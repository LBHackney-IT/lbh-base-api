# LBH Transactions API

This API brings all the transaction records for citizens from Universal Housing backoffice.  It does all the required calculations with regards to the transactions and allows any Front-end to use them straightaway.  The calculation logic being centralized makes the future change control on the API easier making sure changes are applied to all the Front-end applications from one place.

## Stack

- .NET Core as a web framework.
- nUnit as a test framework.

## Dependencies

- Universal Housing

## Contributing

### Setup

1. Install [Docker][docker-download].
2. Clone this repository.
3. Open it in your IDE.

### Development

To serve the application, run it using your IDE of choice, we use Visual Studio CE and JetBrains Rider on Mac. 

The application can also be served locally using docker:
1. Log into AWS ECR. This requires having setup the AWS CLI with your user credentials 
```sh
$ aws ecr get-login --no-include-email
```
2. Build and serve the application. It will be available in the port 3000.
```sh
$ docker-compose run transactions-api dotnet build && docker-compose up transactions-api
```

### Release process

We use a pull request workflow, where changes are made on a branch and approved by one or more other maintainers before the developer can merge into `master` branch.

![Circle CI Workflow Example](docs/circle_ci_workflow.png)

Then we have an automated four step deployment process, which runs in CircleCI.

1. Automated tests (nUnit) are run to ensure the release is of good quality.
2. The application is deployed to staging automatically, where we check our latest changes work well.
3. We manually confirm a production deployment in the CircleCI workflow once we're happy with our changes in staging.
4. The application is deployed to production.

Our staging and production environments are hosted by AWS. We would deploy to production per each feature/config merged into  `master`  branch.

## Testing

To run tests:
```sh
$ docker-compose build transactions-api-test && docker-compose run transactions-api-test
```

## Contacts

### Active Maintainers

- **Cormac Brady**, Developer at [Made Tech][made-tech] (cormac@madetech.com)
- **Selwyn Preston**, Lead Developer at London Borough of Hackney (selwyn.preston@hackney.gov.uk)
- **Miguel Saitz**, Junior Developer at London Borough of Hackney (miguel.saitz@hackney.gov.uk)

### Other Contacts

- **Rashmi Shetty**, Development Manager at London Borough of Hackney (rashmi.shetty@hackney.gov.uk)

[docker-download]: https://www.docker.com/products/docker-desktop
[universal-housing-simulator]: https://github.com/LBHackney-IT/lbh-universal-housing-simulator
[made-tech]: https://madetech.com/

