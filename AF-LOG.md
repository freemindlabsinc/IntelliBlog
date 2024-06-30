### 6/30/2024

- Started the day watching these videos:
    - Redis Cache, PostgreSQL Databases, Messaging, & More with .NET Aspire
        - https://www.youtube.com/watch?v=4t_-g4fwEG0
    - EF Core database model first - take it to the next level with Power Tools CLI | .NET Conf 2023
        - https://www.youtube.com/watch?v=fwR59ep-2-8
        - Useful if I were to connect to 3rd party dbs like with COBRA!!
    - Beginner's Guide to Dev Containers - The Instant Dev Environment That I LOVE!
        - https://www.youtube.com/watch?v=X7guekGZM20
        - Not sure I'll use it given Aspire, but it seems related to Testcontainers (at least in principle).    

- Cleaned up a lot
    - Simplified the names of projects and folders. It is now much more readable
        
        - Intelliblog.Domain, Intelliblog.Application, Intelliblog.Infrastructure, Intelliblog.WebApi, Intelliblog.FunctionalTests, Intelliblog.UnitTests and Intelliblog.IntegrationTests
        
    - I think Ardalis project structure could be improved

        - I linked my .Domain to MediatR.Contracts. No need for the full mediator in .Core/.Domain
        - IMPORTANT: In his Core example he has IArticleDeleteService and ArticleDeletedEvent so that handlers can subscribe 
        to these Domain Events and react. While I agree Domain Events are indeed part of the Domain, I think both the 
        events-handlers AND event-raisers belong to Application. In Domain we should only list them, and that implies the 
        Application has to honor them.
            - Having some implementers like IArticleDeleteService/ArticleDeleteService in Domain is a mistake imo.

    - 
         
    - IMPORTANT: I guess what I am doing is mixing the best of what I learned in my career, plus Ardalis and Jason Taylor.
        - Ardalis: the project structure and initial template
        - Jason Taylor: the DDD focus with Domain & Application
            - I like his Domain much better than Ardfalis Core. JT is cleaner imho

### 6/29/2024

- Struggled a bit to make migrations work with the subfolder structure \Data\migrations
    - Created Notes.txt file which contains the right dotnet ef database commands
    - I had a SqlServer (Linux) listening on 127.0.0.1 while localhost was being used by SqlLocalDb.

- Switched from sqlite to sql server
    - Renamed main connection string 'DbConnection' and added secrets
    - Generated first migration
    - Upgraded packages
    - Added .gitignore for the log files outputed by the web api
    - Tested api.http works

- Caught up on several techniques for testing.

    - Added https://github.com/martincostello/xunit-logging to integration tests

    - Created a temporary connects-to-db test to show I can create a service provider easily in the test 

        - I can get output from ILogger and the test itself.

- Article.Tags seem to work but I don't think I am getting the right SQL. I see OPENJSON used. 
    - SELECT TOP(1) [a].[Id], [a].[Tags], [a].[Title]
      FROM [Articles] AS [a]
      WHERE N'TAG2' IN (
          SELECT [t].[value]
          FROM OPENJSON([a].[Tags]) WITH ([value] nvarchar(max) '$') AS [t]
      )

- Watched very useful videos about testing:

    - The cleanest way to use Docker for testing in .NET 
        - https://www.youtube.com/watch?v=8IRNC7qZBmk

    - The BEST way to reset your database for testing in .NET
        - https://www.youtube.com/watch?v=E4TeWBFzcCw
        - Respawn (from JBogard) https://github.com/jbogard/Respawn

### 6/28/2024

- Talked to SF and then published to Github
- Renamed LOG.MD to AF-LOG.md
- Created Dev branch

### 6/27/2024

- Watched some good videos about EF 8
    - https://www.youtube.com/watch?v=_8iH5QnkIJo
        - JSON columns and related features resolve a lot of problems for the mapping of the Domain layer.
        - Might be able to use MSSQL/Postgres instead of having to move to Cosmos or Mongo. #lessunknowns
    - Refreshed my memory about strongly typed ids
        - I should use them. It helped me greatly in videomatic #safercode
        - https://www.youtube.com/watch?v=MJcaxi3bOO8
      


### 6/26/2024

- Started the application using the Aspire starter template.
- Renamed projects and folders so that they don't have the solution name as prefix.
    - We now have the base \src and \tests folders.
- Created the Solution Items folder with all the basic files for the solution:
    - Directory.*.props, .global.json, .gitignore, .editorconfig
    - See https://github.com/jasontaylordev/CleanArchitecture for more.
- Added FunctionalTests and UnitTests projects.
- Added LOG.md (this file)

- Lots of goodies with EF 8
    - See https://www.dandoescode.com/blog/ef-core-8-exploring-mustknow-key-features