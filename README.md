WeebScores - Anime Ranking Microservices - *VERY MUCH STILL IN PROGRESS*

WeebScores is a microservices-based anime ranking platform built using .NET. It follows Domain-Driven Design (DDD), Clean Architecture, and utilizes CQRS.

Architecture Overview

The project consists of multiple microservices, each responsible for a specific domain:

IdentityService: Handles user authentication, authorization, and identity management. *IN PROGRESS*

AnimeService: Manages anime data, including genres, user ratings, and ranking. *IN PROGRESS*

GenreService: *IN PROGRESS*

AnaylticsService: *IN PROGRESS*

API Gateway: Uses Ocelot to route requests and provide a unified API entry point. *IN PROGRESS*

Tech Stack

.NET 8 for microservices

Entity Framework Core for data access

MS SQL Server as the database

Ocelot for API Gateway

CQRS for separating read and write operations

JWT Authentication for security

Docker for containerization (optional)
