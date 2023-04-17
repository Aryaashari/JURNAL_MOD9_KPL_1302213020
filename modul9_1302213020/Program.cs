using modul9_1302213020;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var movies = new[]
{
    new Movie("The Shawshank Redemption",
              "Frank Darabont",
              new[]{"Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler"},
              "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion."),
    new Movie("The Godfather",
              "Francis Ford Coppola",
              new[]{"Marlon Brando", "Al Pacino", "James Caan", "Diane"},
              
              "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son."),
    new Movie("The Dark Knight",
              "Christopher Nolan",
              new[]{"Christian Bale", "Heath Ledger", "Aaron Eckhart"},
              "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."),
};


app.MapGet("/api/Movies", () =>
{
    return movies;
})
.WithName("GetMovies");

app.MapPost("/api/Movies", () =>
{

}).WithName("InsertMovie");

app.MapGet("/api/Movies/{id}", () =>
{
    
    return movies;
})
.WithName("GetMoviesById");

app.MapPut("/api/Movies/{id}", () => { }).WithName("UpdateMovie");

app.MapDelete("/api/Movies/{id}", () => { }).WithName("DeleteMovie");

app.Run();

internal record Movie(string title, string director, string[] stars, string description) { }