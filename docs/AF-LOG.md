### 8/3/2024

- Made repo public after adding some minimal documentation in the markdown files.

### 7/29/2024

- I have been on the front end for a few days now and I am really pleased with the results
    - I can embed .graphql files straight into the solution and ChillCream's tools (straberry shake) generate the view model code for me. It is really nice.
    - I have been thinking a lot about the similarities between the approach to things of
    ChillCream and RemObjects and it's like this guy is a modern version of me back then?

- The main point and biggest lesson is probably about how Chillcream's code generetors make the promise of GraphQL a reality and fit PERFECTLY with both Domain Driven Design and Clean Architecture. 
- It's what I have been wanting for COBRA for a very long time (e.g. open API and how to have a flexible query model)
- GQL and CQRS are a match made in heaven.
    - In Intellblog I made an executive decision that is very important: 
        - We don't need to lower our standards for the API to REST because is more well known.
        - GQL is REST, opinionated.

### 7/21/2024

- GQL: Lots of thoughts after learning how Data Loaders work and after
seeing DAB
- I tried DAB and played with it. It is very good. I think it would be the perfect software for CODY to look at but it's not the right solution for INTB. 
    - WHat we need to do is expose our GQL stuff following the starnards (e.g. Relay)
    that HotChocolate supports. That is the way.
    - I am gonna concentrate on how to do clean DDD, CQRS but with a GLQ focus!!! 
    - There ain't much info on this stuff out there.
- TODO: at some point I need to list the conventions I am using. For instance, record for commands instead of the old readonly-record-struct approach I used before
- TODO: Strongly typed ids might work fine with GQL.. I should reintroduce them...

### 7/19/2024

- GraphQL, Blazor and Identity courses. Frank Liu. WOW
- Did a lot of video watching and learning.
    - [TODO] Put the links here

### 7/12/2024

- I did some more clean up of directory structure and file separation. 
    - I was not happy with having a file per class in commands (app) and requests (api): it was too much.
      - I used all possible strategies: one file per class, one file group of things , with and without subfolders.
      - Ultimately I think I have found the perfect mix for app and api:
        - Application/Features/Blogs/Commands/Create
            - CreateBlogCommand.cs (includes Validator)
            - CreateBlogCommandHandler.cs
        - API/EndPoints/Blogs/Create
            - CreateBlogEndpoint.cs
            - CreateBlogRequest.cs (includes Validator)
            - CreateBlogResponse.cs                        

- Strongly typed ids ended up being a problem with Mapster and I had to remove them.


### 7/11/2024

- I've completed a large number of things. Big update.
- I finally finalized how the dependency injection extensions should work and who calls who.
    - Blogging.Domain
        - references: NOTHING
    - Application 
        - (references) -> Blogging.Domain
        - (exposes) AddApplicationServices()        
    - Blogging.Infrastructure 
        - (references) -> Application
        - (exposes) AddInfrastructureServices()
        - (registers) AppDbContext using ConnectionString
    - API
        - (references) -> Application, Blogging.Infrastructure
        - (registers) -> Aspire's DbContext (after removing the prior one)
        - (calls) -> AddApplicationServices() and AddInfrastructureServices()
    - FrondEnd 
        - references: NOTHING
        - NSWAG API client (IntelliBlogAPIClient.cs)

    - I wired up 3 endpoints: CreateArticle, ListArticles, CreateBlog
        - The endpoints have request, response, handler and validator
        - 

### 7/4/2024

- I think the Domain is done, at least for now. 
    - I have all aggregates defined and I have a number of methods on each aggregate
    to enforce encapsulation and controlled access to invariants.

- I am now working on the Application layer. 
    
### 7/3 to 7/5/2024

-Massive R&D on aggregates and associations. 
    - I am going in the right direction 
    - I really got a lot of insight on what is coming next
    - Videos:
        - Vaughn Vernon - How to Use Aggregates for Tactical Design (3 Parts)
            - https://www.youtube.com/watch?v=Xf_aLAK1RfE
            - https://www.youtube.com/watch?v=JOsv01y8dlw
            - https://www.youtube.com/watch?v=aVHVFi8aAm

-Outcome of last days 
    - Domain model looks good
    - EF schema looks good too

-What to do next:
    -We now need Domain Services (including base IRepository)
    -We also need Domain Events


### 7/2/2024 

- Lots of work on domain.
    - DDD & Many to Many Object Relational Mapping -> https://udidahan.com/2009/01/24/ddd-many-to-many-object-relational-mapping/

### 7/2/2024

- Started the day well by reading and watching videos on EF8-DDD related stuff
    -  Read "Implement a microservice domain model with .NET"
		- https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model
		
		- In the first part it makes spotless examples of how to ensure clean DDD
		
			- No public setters in any entity property
				- "To follow DDD patterns, entities must not have public setters in any entity property. "
				
			- Collections should be read-only
			- I can only update stuff through a method
				- QUOTE: "Changes in an entity should be driven by explicit methods with explicit 
				ubiquitous language about the change they're performing in the entity."

	- Read "Design a microservice domain model"		
		- https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-domain-model
			- QUOTES:
				- "Your goal is to create a single cohesive domain model for each business microservice or 
				Bounded Context (BC)"
				- "The domain model must capture the rules, behavior, business language, and constraints of the 
				single Bounded Context or business microservice that it represents."
				- "Domain entities must implement behavior in addition to implementing data attributes."
				- "If you have a complex microservice that has logic implemented in the service classes instead of in the domain entities, 
				you could be falling into the anemic domain model"
				- "The anemic domain model is just a procedural style design. Anemic entity objects are not 
				real objects because they lack behavior (methods). They only hold data properties and thus it is 
				not object-oriented design. By putting all the behavior out into service objects (the business layer), 
				you essentially end up with spaghetti code or transaction scripts, and therefore you lose the advantages that a domain model provides."
				- "Regardless, if your microservice or Bounded Context is very simple (a CRUD service), the anemic domain 
				model in the form of entity objects with just data properties might be good enough, and it might not be 
				worth implementing more complex DDD patterns. In that case, it will be simply a persistence model, because 
				you have intentionally created an entity with only data for CRUD purposes."
				- "Thinking about transaction operations is probably the best way to identify aggregates."
							
	- Read "Design a DDD-oriented microservice"
		- https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice
		
			- QUOTES (many from Eric Evans's book Domain Driven Design):
				- "Sometimes these DDD technical rules and patterns are perceived as obstacles that have a steep learning 
				curve for implementing DDD approaches. But the important part is not the patterns themselves, but organizing 
				the code so it is aligned to the business problems, and using the same business terms (ubiquitous language). 
				In addition, DDD approaches should be applied only if you are implementing complex microservices with 
				significant business rules. Simpler responsibilities, like a CRUD service, can be managed with simpler 
				approaches."
				
				- "Determining where to place boundaries between Bounded Contexts balances two competing goals. 
				First, you want to initially create the smallest possible microservices, although that should not be the 
				main driver; you should create a boundary around things that need cohesion. 
				Second, you want to avoid chatty communications between microservices. 
				These goals can contradict one another. 
				You should balance them by decomposing the system into as many small microservices as you can until you see 
				communication boundaries growing quickly with each additional attempt to separate a new Bounded Context. 
				Cohesion is key within a single bounded context."
				
				- "Domain Model Layer: Responsible for representing concepts of the business, information about the business 
				situation, and business rules. State that reflects the business situation is controlled and used here, even 
				though the technical details of storing it are delegated to the infrastructure. 
				This layer is the heart of business software."
				
				- "Application Layer: Defines the jobs the software is supposed to do and directs the expressive domain 
				objects to work out problems. The tasks this layer is responsible for are meaningful to the business 
				or necessary for interaction with the application layers of other systems. 
				This layer is kept thin. It does not contain business rules or knowledge, but only coordinates 
				tasks and delegates work to collaborations of domain objects in the next layer down. 
				It does not have state reflecting the business situation, but it can have state that reflects 
				the progress of a task for the user or the program."
				
				- "The infrastructure layer is how the data that is initially held in domain entities (in memory) is persisted 
				in databases or another persistent store. An example is using Entity Framework Core code to implement 
				the Repository pattern classes that use a DBContext to persist data in a relational database."
				
				- "Dependencies in a DDD Service, the Application layer depends on Domain and Infrastructure, and Infrastructure 
				depends on Domain, but Domain doesn't depend on any layer. 
				This layer design should be independent for each microservice. As noted earlier, you can implement the most 
				complex microservices following DDD patterns, while implementing simpler data-driven microservices 
				(simple CRUD in a single layer) in a simpler way."
		
		- Spent considerable time looking at eShop -> https://github.com/dotnet/eShop
			
			- VERY IMPORTANT REALIZATION:
				- There's no real need to have an Application project and then a WebAPI project.
				While it would be nice to be able to guarantee we can simply create a GraphQL API end point
				project and simply call what was in the Application assembly, it really never materialized 
				as a practical need. If we were to need GraphQL we could still reference the WebAPI project or
				we can separate the Application pieces that would have a use in the new assembly.
				It is not stuff that justifies the complexity of an extra Project in the solution.
				
				
- At some point in the past I realized that unit test projects should really be a few:
	- UnitTests, IntegrationTests, FunctionalTests
		- Functional is the higher level: it literally calls TestWebServer via HTTP (but in memory)
		- Integration is the place where I test stuff in Application
			- Q: Do I test command handlers directly?
		- Unit is where I test in memory things like domain objects and functionality

- Started branch ddd-adjustments2
    
    - IMPORTANT REALIZATION: both Ardalis and Jason Tayler's DDD solutions make use of an
    Application project. If we're to take inspiration from eShop (and we do), that is a
    complication we don't need. We can implement the mediator calls DIRECTLY in the web api project particularily with FastEndpoints.

        - I am going to move things around some more... wish me luck!
        - 


### 7/1/2024

- The one month sprint starts today!

- I looked into the OPENJSON features of EF 8, specifically in the context of the Article.Tags property.     
    
    - https://chatgpt.com/share/de265a4f-1c4e-41fe-af67-9d6d1a6496b6
    - Conclusion: "Using a normalized table structure for storing tags is generally better for performance, maintainability, and query efficiency, especially when dealing with frequent and complex searches. JSON columns offer flexibility but can complicate querying and indexing, leading to potential performance issues. Therefore, for your use case, a normalized table design is recommended."
    
    - DECISION: do not use JSON for tags. Use a separate table.

- Worked on Domain:
    
    - I spent all day restructuring the domain and EF until I found a good output.
        
        - IMPORTANT: Having unit tests for the domain was incredibly useful. I spotted several issues
        right away (e.g. access to stuff I should not have, etc.). It definitely accelerated my work
        and I now KNOW that things are solid even at the domain level.
        
        - I like the DB.

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