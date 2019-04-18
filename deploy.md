``` bash
# using https://shell.azure.com

# Check that you are logged into the right subscription
az account list -o table

# if the right subscription is not set to be the default use this to change it
az account set -s <SubscriptionId>

# 5 to 8 character prefix to identify you (all lowercase, no special characters)
prefix=sweisfel3

# setup some more variables
gitrepo=https://github.com/shawnweisfeld/CosmosToDo
webappname=$prefix$RANDOM
rg=$prefix-monitoringlab
location='eastus'
accountName=$prefix$RANDOM

# Create a resource group.
az group create --location $location --name $rg

# Create an App Service plan
az appservice plan create --name $webappname --resource-group $rg --sku S1

# Create a web app.
az webapp create --name $webappname --resource-group $rg --plan $webappname

# Deploy sample code to our webapp
az webapp deployment source config --name $webappname --resource-group $rg --repo-url $gitrepo --branch master

# Create a SQL API Cosmos DB account
az cosmosdb create --resource-group $rg --name $accountName --default-consistency-level "Session"

## Get the endpoint and key of the cosmos db that we just created
endpoint=`az cosmosdb show -n $accountName -g $rg --query 'documentEndpoint' --output tsv`
primaryKey=`az cosmosdb list-keys -n $accountName -g $rg --query 'primaryMasterKey' --output tsv`

# connect our webapp to our cosmosdb
az webapp config appsettings set -g $rg -n $webappname --settings endpoint=$endpoint primaryKey=$primaryKey

# Get the url to our website so that you can open it in a browser
echo http://$webappname.azurewebsites.net
```
