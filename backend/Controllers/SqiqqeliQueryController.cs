using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Npgsql;

namespace backend
{

    [ApiController]
    [Route("[controller]")]
    public class SqiqqeliQueryController : ControllerBase
    {
        private readonly ILogger<SqiqqeliQueryController> _logger;

        public SqiqqeliQueryController(ILogger<SqiqqeliQueryController> logger)
        {
            _logger = logger;
        }

        public static async Task InsertTask(string name, string content, NpgsqlConnection conn)
        {
            await using var cmd = new NpgsqlCommand("INSERT INTO \"Task\" (\"Name\", \"Content\", \"StartDate\", \"EndDate\", \"ActivityId\", \"Status\", \"Tags\") VALUES (($1), ($2), ($3), ($4), ($5), ($6), ($7));", conn)
            {
                Parameters =
    {
        new() { Value = name },
        new() { Value = content },
        new() { Value = DateTime.Now },
        new() { Value = DateTime.Now.AddDays(7) },
        new() { Value = 2 },
        new() { Value = 2 },
        new() { Value = 2 }
    }
            };

            await cmd.ExecuteNonQueryAsync();
        }

        [HttpGet(Name = "Bennys")]
        public async Task<Tasks> b_ennys(NpgsqlConnection conn)
        {
            await using var cmd = new NpgsqlCommand("Select * from \"task\"", conn);

            return new Tasks
            {
                Name = "benny",
                Content = "Benny's pizza kebob",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3657),
                ActivityId = 1,
                Status = 1,
                Tags = [1,]
            };
        }

        public static async Task InsertStatus(string title, string style, NpgsqlConnection conn)
        {
            await using var cmd = new NpgsqlCommand("INSERT INTO \"Status\" (\"Title\", \"Style\") VALUES (($1), ($2));", conn)
            {
                Parameters =
    {
        new() { Value = title },
        new() { Value = style }
    }
            };

            await cmd.ExecuteNonQueryAsync();
        }

        public static async Task InsertActivityType(string name, NpgsqlConnection conn)
        {
            await using var cmd = new NpgsqlCommand("INSERT INTO \"ActivityType\" (\"Name\") VALUES (($1));", conn)
            {
                Parameters =
    {
        new() { Value = name }
    }
            };

            await cmd.ExecuteNonQueryAsync();
        }
        public static async Task InsertActivity(string title, string description, string url, NpgsqlConnection conn)
        {
            await using var cmd = new NpgsqlCommand("INSERT INTO \"Activity\" (\"Title\", \"Description\", \"Url\", \"StartDate\", \"EndDate\", \"Status\", \"Tags\", \"ActivityType\") VALUES (($1), ($2), ($3), ($4), ($5), ($6), ($7), ($8));", conn)
            {
                Parameters =
    {
        new() { Value = title },
        new() { Value = description },
        new() { Value = url },
        new() { Value = DateTime.Now },
        new() { Value = DateTime.Now.AddDays(7) },
        new() { Value = 1 },
        new() { Value = 1 },
        new() { Value = 1 }
    }
            };

            await cmd.ExecuteNonQueryAsync();
        }
        public static async Task InsertTag(string name, string color, NpgsqlConnection conn)
        {
            await using var cmd = new NpgsqlCommand("INSERT INTO \"Tag\" (\"Name\", \"Color\") VALUES (($1), ($2));", conn)
            {
                Parameters =
    {
        new() { Value = name },
        new() { Value = color }
    }
            };

            await cmd.ExecuteNonQueryAsync();
        }

        public static async void SelectTask(NpgsqlConnection conn)
        {
            await using var cmd2 = new NpgsqlCommand("SELECT * FROM \"Task\"", conn);

            await cmd2.ExecuteNonQueryAsync();
        }
    }
}