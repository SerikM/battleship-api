# Battleship Game  Service API

This is a lambda api whose purpose is to provide player tracking services to a potential implamentation of the popular battleship game.

This application is based on the aws serverless application model (SAM) and is written in C# and runs on .net core framework 3.1


# Build instructions
- In order to build and package your solution run from .\battleship-api\src\battleship following netcode commands
- dotnet restore
- dotnet lambda package 

- In order to run tests run following commands from .\battleship-api\test\battleship.Tests
- dotnet test


# Deployment instructions. 
  - Note for the following commands to succeed you will need SAM CLI installed on your machine. It can be installed from https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/serverless-sam-cli-install.html.
  
  - Create an s3 bucket for the source code of your lambda by running following from your aws cli from \battleship-api\src\battleship directory: 
  - aws s3 mb s3://<you bucket name> --region ap-southeast-2

  - To prepare the package for the deployment to CF and to transform the template.yml run:
  - sam package --template-file ./template.yml --output-template-file sam-template.yml --s3-bucket <you bucket name>

  - To deploy the packaged source code to aws lambda using CF run:
  - sam deploy --template-file ./sam-template.yml --stack-name <your stack name> --capabilities CAPABILITY_IAM

  
# Testing instructions. 
 - The api can be tested using postman.
 - In order to create the playing field and to place a ship on one of the playing boards the following call may be used:

   https://<host url>/Prod/v1/default (use PUT method) 
 - example payload:  {"PlayerId": "123", "Locations": [{"Row": 1, "Column": 2}]}

 - The above call will creat a board for the player with ID 123 and will place a ship that consists of one cell into  coordinates  (1 : 2). To make a larger ship add more elements to the Locations collection.
 - In order to make an attack on a ship use the following:

   https://<host url>/Prod/v1/default (use POST method) 
 - example payload: {"PlayerId":"123", "Row":1, "Column": 2}

 - The above call will retun return message "hit". If, for example, we use payload with {"PlayerId":"123", "Row":1, "Column": 3} the api is expected to return "miss". 

 - The api may be run locally and when started from the VS debug menu it will be listening on http://localhost:5000/v1/default. The following calls may be used for testing:


   http://localhost:5000/v1/default (use PUT method) 
 - example payload:  {"PlayerId": "123", "Locations": [{"Row": 1, "Column": 2}]}

   http://localhost:5000/v1/default (use POST method) 
 - example payload: {"PlayerId":"123", "Row":1, "Column": 2}
