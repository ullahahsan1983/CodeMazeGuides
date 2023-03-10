var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    var cacheProfiles = builder.Configuration
            .GetSection("CacheProfiles")
            .Get<Dictionary<string, CacheProfile>>()!;

    foreach (var cacheProfile in cacheProfiles)
    {
        options.CacheProfiles.Add(cacheProfile.Key, cacheProfile.Value);
        //options.CacheProfiles.Add(cacheProfile.Key, cacheProfile.Get<CacheProfile>());
    }
});

builder.Services.AddOutputCache();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOutputCache();

app.Run();
