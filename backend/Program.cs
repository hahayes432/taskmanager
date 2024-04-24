using Npgsql;

var connectionString = "host=localhost;port=5432;database=taskmanager;username=postgres;password=password;sslmode=prefer";

await using var conn = new NpgsqlConnection(connectionString);
await conn.OpenAsync();

await SqiqqeliQueryController.InsertStatus("sdkmf", "sdfkdfmskfsdkmsdfmksdf sdfm mksfd", conn);
await SqiqqeliQueryController.InsertTag("bennys", "tomato, conn", conn);
await SqiqqeliQueryController.InsertActivityType("benny", conn);
await SqiqqeliQueryController.InsertActivity("benny's pizza", "kebab", "pizza.keb.ab", conn);
await SqiqqeliQueryController.InsertTask("dfkmawefawef", "aowiefjaweofiawefojiawefioawef awef iaw fwe", conn);

SqiqqeliQueryController.SelectTask(conn);

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
