using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithDataVolume() // Stores data in a volume to persist data between runs
    .WithPgWeb(); // Simple web ui to manage database
;
var postgresdb = postgres.AddDatabase("postgresdb");

var redisCacheServer = builder.AddRedis("redis")
    .WithRedisCommander(); // Simple web ui to view and manage redis resource

var app = builder
    .AddProject<AspireApp_WebApp>("webapp")
    .WithReference(postgresdb) // Adds connection information for the postgres server to the app
    .WithReference(redisCacheServer)
    .WaitFor(postgres) // Do not start running until the postgres server is healthy
    .WaitFor(redisCacheServer); // Same for redis

builder.Build().Run();
