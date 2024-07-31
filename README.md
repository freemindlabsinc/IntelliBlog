# IntelliBlog

### Status

- This repo has just made public and it's still under **heavy** development.
- This and other documentation is still being written and updated: do not expect perfection nor completeness, yet.

## Overview
[License: MIT]

IntelliBlog (IB) is a minimalist blogging system that focuses on simplicity while providing a rich set 
of features, integration with AI and an enteprise-ready architecture that is easy to use and to manage.

We think of IntelliBlog as the most over-engineered blogging system in the world, but the concepts and 
patterns we use in the solution are applicable to many other domains.

> **IB is ultimately meant to be downloaded and used, but at the same time it is also an ever-evolving 
reference for .NET and C# developers who are looking for a real-world example of how to apply certain architectral patterns and concepts to their solutions.**

We reccomend you read the rest of the sections in this document to get a
better understanding of what IntelliBlog is and the architectural goals we set for it, but if you want to quickly get IntelliBlog on your system, you can skip to the [Getting Started](#getting-started) section.

### Patterns and Concepts

The IntelliBlog project is a playground for a number of architectural patterns and concepts. 

The architecture we adopted is heavily inspired by the CA and DDD examples written by [Jason Taylor](https://github.com/jasontaylordev/CleanArchitecture), [Steve "Ardalis" Smith"](https://github.com/ardalis/CleanArchitecture) and [Vaughn Vernon](https://github.com/VaughnVernon/IDDD_Samples_NET), but it replaces REST with GraphQL thus giving us a chance to provide an extremely flexible and performant API to the developers of our front-end, and to the third parties who want to integrate with our blogging system.


> One of the fundamental problems we were trying to resolve is how can we provide a flexible query API that prevents frontend developers from requiering a new endpoint every time they need a new piece of data. **GraphQL and the Relay patterns seem to provide the best answer to that question**.

The following list gives an idea of what you can find in the IntelliBlog source code:

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

[TBC]

## Getting Started

To get started, you need to clone this repository and configure a few user secrets as explained 
in the [Configuration Instructions](/CONFIGURATION.md).

## The solution structure

The solution is structured in a way that makes it easy to navigate and understand.

[Solution Structure](/SOLUTION_STRUCTURE.md).

## The big questions

We believe the project contains some interesting answers to questions such as:

- How should we structure our solution?
    - 
- How to apply Clean Architecture in a real project.
- Should we use REST, GraphQL, a combination ?

## Features

## Dependencies

## Getting Started