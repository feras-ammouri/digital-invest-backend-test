# Crowd Lending Platform POC

# Prerequisites
- SQL Server

# How to run
- Get SQL Server up and running
- Create a database which should be used for this POC either by using the CreateDBScript which is in the repository or by using EF migration using the following commands:
  - add-migration "name of migration"
  - Update-Database
- Use PopulateDataScript.sql to populate the data.
- Change the connection string section in the appsettings.json accroding to the database server credentials and database name.

# Main endpoints
- GET: <url>/api/projects
- POST: <url>/api/projects with a body like the following:

  {
    "ProjectId": "7229c3fd-a545-4234-a241-c8525a8a047e",
    "InvestorId": "7229c3fd-a545-4234-a241-c8525a8a047c",
    "InvestmentAmount": 100.05
  }
 
