using gRPC.Client.Sample.Services;
using gRPC.Server.Sample.Services.gRPC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddGrpcClient<RealEstate.RealEstateClient>(c =>
{
    c.Address = new Uri("https://localhost:7042");
});
builder.Services.AddScoped<IRealEstateGrpcService, RealEstateGrpcService>();
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

app.Run();
