# Implementation of a Domain Driven Design microservice
 With CQRS, Event sourcing, Ports and Adapters, Postgres and RabbitMQ

## Why?

To tackle complex business logic in a microservice we can deploy a Domain Driven Design (DDD) approach to software development to more readily succeed at achieving high-quality software model designs (Vaughn Vernon, 2013a).

## How?

Using design techniques such as Command Query Responsibility Segregation (CQRS), Event Sourcing and the Ports and Adapters pattern to level up DDD and use it at it's highest potential.

## When?

You should use DDD only when tackling complex business logic. When creating a simple application like a digital to-do list it better to make a more traditional three layered CRUD application. This is because the hassle to setup DDD and event sourcing to use it as intended is not worth it for such little gain.

## What I found

When starting this project the excitement for using event sourcing and DDD was very high. I have used DDD before and would recommend it to everyone. But... using event sourcing is like opening a can of worms you sometimes do not intent to eat. It brings an enormous amount of complexity on top of the already complex and ellaborate way of writing domain driven. Especcialy when you implement event sourcing because you like the sound of it. My advice to anyone: DON'T use event sourcing... Unless you really stand to gain from the history, fail-safety and realtime data processing. Nonetheless I urge everyone to atleast try it out for you can only find the disadvantages when using such architectures in a real wordt scenario. 

## Thank you notes

Big thanks to [Xander Vedder](https://github.com/xandervedder) who created [Wrappit](https://github.com/xandervedder/Wrappit): A simple wrapper around the C# implementation of RabbitMQ and allowed for easy message bus implementation.

## Sources
Implementing Domain Driven Design, Vaughn Vernon, 2013
- a: Chapter 1, Getting Started With DDD

