using Application.Dictionary;
using Application.Files;
using Infrastructure.Files;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DictionaryService>();
builder.Services.AddTransient<IFileReader, IoFileReader>();

var app = builder.Build();

var dictionaryService = app.Services.GetRequiredService<DictionaryService>();
var dictionary = dictionaryService.CreateDictionary("..\\input.txt", 6);
dictionary.PrintWords();

