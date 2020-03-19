# INSTRUCTIONS: 
# 1) ENSURE YOU DELETE THE MODULES YOU DO NOT REQUIRE - E.G. YOU ONLY NEED A NETWORK LAYER, THEN DELETE REST OF THE MODULES (COMMON, BACK END, FRONT END)
# 2) ENSURE YOU REPLACE ALL INPUT PARAMETERS, THAT CURRENTLY STATE 'ENTER VALUE', WITH VALID VALUES 
# 3) YOUR CODE WOULD NOT COMPILE IF STEP NUMBER 2 IS NOT PERFORMED!
# 4) ENSURE YOU CREATE A BUCKET FOR YOUR STATE FILE AND YOU ADD THE NAME BELOW - MAINTAINING THE STATE OF THE INFRASTRUCTURE YOU CREATE IS ESSENTIAL
# 5) THE VALUES THAT ARE REPEATED ARE TAKEN OUT UNDER THE 'LOCALS' VARIABLE SECTION - PLEASE PROVIDE VALUES FOR THOSE

provider "aws" {
  region  = "eu-west-2"
  version = "~> 2.0"
}

locals {
  application_name = your application name # The name to use for your application
  vpc_name = the name of the vpc where you are creating the RESOURCES # The name of the VPC, without environment
}


data "aws_iam_role" "ec2_container_service_role" {
  name = "ecsServiceRole"
}

data "aws_iam_role" "ecs_task_execution_role" {
  name = "ecsTaskExecutionRole"
}

terraform {
  backend "s3" {
    bucket  = your bucket name
    encrypt = true
    region  = "eu-west-2"
    key     = the key to be used (path)
  }
}

module "development" {
  source                      = "github.com/LBHackney-IT/aws-hackney-components-per-service-terraform.git//modules/environment/backend/fargate"
  cluster_name                = ecs cluster name # Replace with your cluster name.
  ecr_name                    = ecr repository name # Replace with your repository name - pattern: "hackney/YOUR APP NAME"
  environment_name            = "development"
  application_name            = local.application_name 
  security_group_name         = back end security group name OR PREFIX # Replace with your security group name, WITHOUT SPECIFYING environment. IF USING FARGATE, SUPPLY A NAME FOR A NEW SECURITY GROUP. IF YOU ARE USING EC2, SUPPLY THE NAME OF THE EXISTING BACK END SECURITY GROUP.
  vpc_name                    = local.vpc_name 
  port                        = port # Replace with the port to use for your api / app
  desired_number_of_ec2_nodes = number of nodes # Variable will only be used if EC2 is required. Do not remove it. 
  lb_prefix                   = NLB name # Replace with your NLB name, without environment
  ecs_execution_role          = data.aws_iam_role.ecs_task_execution_role.arn
  lb_iam_role_arn             = data.aws_iam_role.ec2_container_service_role.arn
  task_definition_environment_variables = {
    ASPNETCORE_ENVIRONMENT = "development"
  }
  task_definition_environment_variable_count = number # This number needs to reflect the number of environment variables provided

  task_definition_secrets      = {}
  task_definition_secret_count = number # This number needs to reflect the number of environment variables provided
}

/*   ADD ANY OTHER CUSTOM RESOURCES REQUIRED HERE      */

/*   ADD FRONT END MODULE HERE                         */
module "frontend" { //example config
  source              = "github.com/LBHackney-IT/aws-hackney-components-per-service-terraform.git//modules/environment/frontend/fargate"
  environment_name    = "development"
  application_name    = local.application_name
  ecs_cluster         = name cluster to be used # Replace with your ECS cluster name
  security_group_name = back end security group name OR PREFIX (name without environment) # Replace with your security group name, WITHOUT SPECIFYING environment. 
  # IF USING FARGATE, SUPPLY A NAME FOR A NEW SECURITY GROUP. IF YOU ARE USING EC2, SUPPLY THE NAME OF THE EXISTING BACK END SECURITY GROUP.
  lb_prefix           = load balancer prefix # Replace with the name of the ALB, without environment
  port = number # The port to use for accessing the application - ensure no clashes with existing applications
  path_pattern  = the pattern for routing to the front end app # Replace with the path pattern to be used for routing
  vpc_name      = local.vpc_name

  desired_number_of_ec2_nodes = number of nodes # Variable will only be used if EC2 is required. Do not remove it. 
  ecs_execution_role          = "${data.aws_iam_role.ecs_task_execution_role.arn}"
  lb_iam_role_arn             = "${data.aws_iam_role.ec2_container_service_role.arn}"

  task_definition_environment_variables = {
    NODE_ENV = "production"
  }
  task_definition_environment_variable_count = number # This number needs to reflect the number of environment variables provided
  task_definition_secrets      = {}
  task_definition_secret_count = number # This number needs to reflect the number of environment variables provided
}