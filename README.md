# IntelliBlog

![zz.](./docs/images/rabbit.jpg)

### Status

- :warning: This repo has just made public and it's still under **heavy** development. Consider it a work in progress.
- :white_flag: This and other documentation is still being written and updated: do not expect perfection nor completeness, yet.

## Overview
[License: MIT]

IntelliBlog (IB) is a minimalist blogging system that focuses on simplicity while providing a rich set 
of features, integration with AI and an enteprise-ready architecture that is easy to use and to manage.

We think of IntelliBlog as the *most over-engineered blogging system in the world*, but the concepts and 
patterns we use in the solution are applicable to many other domains.

> :ok_hand: **IB is ultimately meant to be downloaded and used, but at the same time it is also an ever-evolving 
reference for .NET and C# developers who are looking for a real-world example of how to apply certain architectral patterns and concepts to their solutions.**

We reccomend you read the rest of the sections in this document to get a
better understanding of what IntelliBlog is and the architectural goals we set for it, but if you want to quickly get IntelliBlog on your system, you can skip to the [Getting Started](#getting-started) section.

### Patterns and Concepts

The IntelliBlog project is a playground for a number of architectural patterns and concepts. 

The architecture we adopted is heavily inspired by the Clean Architecture (CA) and Domain Driver Design (DDD) examples written by [Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture), [Steve "Ardalis" Smith"](https://github.com/ardalis/CleanArchitecture) and [Vaughn Vernon](https://github.com/VaughnVernon/IDDD_Samples_NET), but it adds a few twists of its own, such as:

1) A more straighforward way to deal with the query side of CQRS:
    - Frontend developers are often required to ask for new endpoints every time they need a new piece of data. These endpoints often end up over-fetching or under-fetching data, and the backend developers are often asked to create new endpoints to satisfy the frontend developers' needs. **This is cumbersome and inefficient. We believe that GraphQL and Relay patterns provide a better way to deal with this problem.**
    - [ :warning: Complete]

2) A simpler way to think of Domain and Application layers:
      - Do we really need 2 projects for the Domain and Application layers? We think not. We believe that the Domain and Application layers can be combined into a single project, and that this makes it easier to navigate the solution and to understand the relationships between the different parts of the system. 
        [ :warning: Rework or expand]

3) Pipelines:
    - In the Blogging project we use MediatR pipelines to handle cross-cutting concerns such as validation, and transaction management (Unit of Work pattern). 
    - In the Infrastructure project we use Entity Framework Interceptors to dispatch domain events, create CRUD events and handle other cross-cutting concerns such as setting properties like CreatedBy, LastModifiedOn, etc.
    - Pipelines are a powerful way to keep the code clean and to separate concerns.

4) :warning: More    

The following list gives an idea of what else you can find in the IntelliBlog source code:

- Architecture
    - [x] Clean Architecture
    - [x] Domain Driven Design
    - [x] Event-Driven Architecture 
    - [x] CQRS    
    - [x] Messaging

- Integrations
    - [x] Graph APIs        
    - [ ] Search Engine Integration
    - [ ] AI Integration
    - [x] Telemetry        
    - [ ] LlamaIndex (Python)

- Other
    - [x] Reliability
        
The items with a checkmark are already present in the source code in one way or the other. The remaining items indicate upcoming functionality.

In addition, we intend to make each of the bullet points above link to an article that explains how the concept is applied in the IntelliBlog project. Those articles would include screenshots and other visual aids to help you understand the concepts better.
    
## Technolgy Stack

Major frameworks & libraries:

- [x] .NET 8
    - [x] ASP.Net Core
    - [x] Blazor
    - [x] Entity Framework Core
- [x] ChilliCream GraphQL Platform
    - [x] Hot Chocolate
    - [x] Straberry Shake
    - [x] Banana Cake Pop
- [x] FluentUI
- [ ] Semantic Kernel       
    - [ ] phi3 SLM
    - [ ] Ollama
    - [ ] ChatGPT/AzureAI
    - [ ] etc.
- [ ] LLamaIndex (Python)
- [ ] Elasticsearch
- [ ] REDIS
- [x] Microsoft SQL Server
    - [ ] PostgreSQL
- [ ] RabbitMQ

Other:

- [x] FluentValidation
- [x] Ardalis.GuardClauses
- [x] Serilog
- [x] Bogus
- [x] Polly
- [x] MediatR
- [x] FluentAssertions
- [ ] MailKit
- [x] MediatR
- [x] xUnit
  

## Prerequisites

- .NET 8
- Docker
- Visual Studio 2022 or equivalent IDE.

## The Big Picture

Please take a read at the [Big Picture](/BIG_PICTURE.md) document to understand the main concepts.

[ :warning: TBC]

## Getting Started

To get started, you need to clone this repository and configure a few user secrets as explained 
in the [Configuration Instructions](/CONFIGURATION.md).

## The solution structure

The solution is structured in a way that makes it easy to navigate and understand.

[Solution Structure](/SOLUTION_STRUCTURE.md).

[ :warning: TBC]