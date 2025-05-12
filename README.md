# MicroTec.HR

To Run The Application you will need to follow the following steps 

1 - Download and Install Docker  
2 - in the APIs Project Run Docker Compose UP which the docker file is located 
3 - if you don't want a container DB , you can replace the connection string in appsettings.developement.json
4 - in this location you will need to run EF to generate and seed the database __YourLocation__\MicroTec.HR\MicroTec.Hr.BackendApis This Command  
dotnet ef database update --project ../MicroTec.Hr.Infrastructure --startup-project MicroTec.Hr.BackendApis
5 - YES the project doesn't auto generate any database changes until you manually tell it to do that. 


Notes to Consider while you are reviewing the POC  
1 - Generic Repository are an Anti Pattern and it is evil to implement espically in the ERP project. 
