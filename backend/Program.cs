// using Npgsql;

// var connectionString = "host=localhost;port=5432;database=taskmanager;username=postgres;password=password;sslmode=prefer";

// await using var conn = new NpgsqlConnection(connectionString);
// await conn.OpenAsync();

// await backend.SqiqqeliQueryController.InsertStatus("sdkmf", "sdfkdfmskfsdkmsdfmksdf sdfm mksfd", conn);
// await backend.SqiqqeliQueryController.InsertTag("bennys", "tomato, conn", conn);
// await backend.SqiqqeliQueryController.InsertActivityType("benny", conn);
// await backend.SqiqqeliQueryController.InsertActivity("benny's pizza", "kebab", "pizza.keb.ab", conn);
// await backend.SqiqqeliQueryController.InsertTask("dfkmawefawef", "aowiefjaweofiawefojiawefioawef awef iaw fwe", conn);
// await backend.SqiqqeliQueryController.DeleteTask("dfkmawefawef", conn);

// backend.SqiqqeliQueryController.SelectTask(conn);


// using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers(options => { options.RespectBrowserAcceptHeader = true; }).AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
    options.AddPolicy("allow-all", builder => {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
        builder.AllowCredentials();
    });
});

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
