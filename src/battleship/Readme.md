# Battleship Game  Service API

this is a lambda used to provide services to a potential implamentation of the popular battleship game

it is based on the aws serverless application model and is written in C# and runs on .net core framework 


# Build instructions
to build your solution run
- dotnet restore
- cd test/battleship.Tests
- dotnet test
- cd..
- cd..
- cd src/battleship
- dotnet lambda package


# Deployment instructions:
  create an s3 bucket for the source code of your lambda by running following from your aws cli:

  - aws s3 mb s3://<bucket name> --region ap-southeast-2

  to prepare the package for the deployment and to transform the template.yml run:

  - sam package --template-file ./template.yml --output-template-file sam-template.yml --s3-bucket <bucket name>

  to deploy the packaged source code to aws lambda run:

  - sam deploy --template-file ./sam-template.yml --stack-name <your stack name> --capabilities CAPABILITY_IAM