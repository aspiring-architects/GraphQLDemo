using GraphQLServer.GraphQLModels;
using GraphQLServer.GraphQLQuery;
using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<GraphQLDemoDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDemoDBContext"));
});

//builder.Services.AddPooledDbContextFactory<GraphQLDemoDBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDemoDBContext"));
//});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//GraphQL
builder.Services
    .AddGraphQLServer()             //HotChocolate.AspNetCore
    .AddQueryType<Query>()
    .AddType<StudentType>()
    .AddType<StudentResultType>()
    .AddFiltering()                 //HotChocolate.Data
    .AddSorting()
    .AddProjections();
    //.AddInMemorySubscriptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

//GraphQL
app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
app.UseGraphQLVoyager("/ui/voyagar");

app.Run();

//Steps
//Install-Package Microsoft.EntityFrameworkCore.Tools
//Install-Package Microsoft.EntityFrameworkCore.SqlServer
//Scaffold-DbContext "Server=KARLPERSONALOFF\SQLEXPRESS;Database=GraphQLDemoDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
