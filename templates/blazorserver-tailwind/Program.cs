WebApplication
    .CreateBuilder(args)
    .Configure()
    .Build()
    .Configure()
    .ExecuteBeforeRunAsync().Result
    .Run();