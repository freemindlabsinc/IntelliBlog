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