using BitcoinBlockSolution.Core.Services.Impl;
using BitcoinBlockSolution.Core.Services;
using BitcoinBlockSolution.Core.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient();
builder.Services.Configure<BlockchainApiSettings>(builder.Configuration.GetSection("BlockchainApi"));
builder.Services.AddTransient<IBlockchainService, BlockchainService>();
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

app.Run();
