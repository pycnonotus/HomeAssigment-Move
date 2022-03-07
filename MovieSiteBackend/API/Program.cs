using Core.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
const string AllCors = "AllCors";

builder.Services.AddCors(options =>
{
    // For QOL,  In real life I would not use it this way
    options.AddPolicy(AllCors, builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200").AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IMoviesService, MoviesServiceServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
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

// app.UseHttpsRedirection();
// app.UseAuthorization();
app.UseCors(AllCors);

app.MapControllers();

app.Run();

