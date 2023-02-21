#!/bin/bash
export PG_HOST=localhost
export PG_PORT=3306
export PG_DATABASE=example
export PG_USER=postgres
export PG_PASS=password
export Wrappit_HostName=localhost
export Wrappit_Port=5672
export Wrappit_UserName=guest
export Wrappit_Password=guest
export Wrappit_ExchangeName=Exchange
export Wrappit_QueueName=Example.Queue
export Wrappit_DurableExchange=false

read -p "Enter the name of the migration: " migration_name

set ASPNETCORE_ENVIRONMENT=Development && dotnet ef migrations add $migration_name
$SHELL