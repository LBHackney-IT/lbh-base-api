# THE SECTION BELOW IS FOR USE WITH DYNAMODB
# 
# resource "aws_dynamodb_table" "baseapi_dynamodb_table" {
#     name                  = "example_table"   # TODO: This should be the DynamoDb table name in use
#     billing_mode          = "PROVISIONED"
#     read_capacity         = 10                # TODO: This should be confirmed
#     write_capacity        = 10                # TODO: This should be confirmed
#     hash_key              = "id"              # TODO: This should be the name of the id field for the entity
# 
#     attribute {
#         name              = "id"              # TODO: This should be the name of the id field for the entity
#         type              = "N"               # TODO: This should be the type of the id field for the entity (N - a number; S - a string; B - a binary value)
#     }
# 
#     tags = {
#         Name              = "base-api-${var.environment_name}"
#         Environment       = var.environment_name
#         terraform-managed = true
#         project_name      = var.project_name
#     }
# }
# 
# resource "aws_iam_policy" "baseapi_dynamodb_table_policy" {
#     name                  = "lambda-dynamodb-base-api"
#     description           = "A policy allowing read/write operations on the dynamoDB for the Base API"
#     path                  = "/base-api/"
# 
#     policy                = <<EOF
# {
#     "Version": "2012-10-17",
#     "Statement": [
#         {
#             "Effect": "Allow",
#             "Action": [
#                         "dynamodb:BatchGetItem",
#                         "dynamodb:GetItem",
#                         "dynamodb:Query",
#                         "dynamodb:Scan",
#                         "dynamodb:BatchWriteItem",
#                         "dynamodb:PutItem",
#                         "dynamodb:UpdateItem"
#                      ],
#             "Resource": "${aws_dynamodb_table.baseapi_dynamodb_table.arn}"
#         }
#     ]
# }
# EOF
# }
