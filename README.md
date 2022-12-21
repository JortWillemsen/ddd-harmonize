# Implementation of a Domain Driven Design microservice
 With CQRS, Event sourcing, Ports and Adapters, Postgres and RabbitMQ

## Why?

To tackle complex business logic in a microservice we can deploy a Domain Driven Design (DDD) approach to software development to more readily succeed at achieving high-quality software model designs (Vaughn Vernon, 2013a).

## How?

Using design techniques such as Command Query Responsibility Segregation (CQRS), Event Sourcing and the Ports and Adapters pattern to level up DDD and use it at it's highest potential.

## When?

You should use DDD only when tackling complex business logic. When creating a simple application like a digital to-do list it better to make a more traditional three layered CRUD application. This is because the hassle to setup DDD and use it with as intended is not worth it for such little gain.

## Thank you notes

Big thanks to [Xander Vedder](https://github.com/xandervedder) who created [Wrappit](https://github.com/xandervedder/Wrappit): A simple wrapper around the C# implementation of RabbitMQ and allowed for easy message bus implementation.

## Sources
Implementing Domain Driven Design, Vaughn Vernon, 2013
- a: Chapter 1, Getting Started With DDD

