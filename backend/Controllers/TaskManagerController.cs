using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Npgsql;

namespace backend
{
    [EnableCors("allow-all")]
    [ApiController]
    [Route("[controller]")]
    public class TaskManagerController : ControllerBase
    {

        const string connectionString = "host=localhost;port=5432;database=taskmanager;username=postgres;password=password;sslmode=prefer";
        NpgsqlConnection conn = new NpgsqlConnection(connectionString);

        private readonly ILogger<TaskManagerController> _logger;

        public TaskManagerController(ILogger<TaskManagerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("InsertTask")]
        public IActionResult InsertTask(string name, string content)
        {

            var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            var cmd = new NpgsqlCommand("INSERT INTO \"Task\" (\"Name\", \"Content\", \"StartDate\", \"EndDate\", \"ActivityId\", \"Status\", \"Tags\") VALUES (($1), ($2), ($3), ($4), ($5), ($6), ($7));", conn)
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

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetTasks")]
        public List<Tasks> GetTasks()
        {
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM \"Task\"", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Tasks> taskList = new List<Tasks>();
            while (reader.Read())
            {
                Tasks taskRow = new Tasks();
                taskRow.Id = reader.GetInt32(0);
                taskRow.Name = reader.GetString(1);
                taskRow.Content = reader.GetString(2);
                taskRow.StartDate = reader.GetDateTime(3);
                taskRow.EndDate = reader.GetDateTime(4);
                taskRow.ActivityId = reader.GetInt32(5);
                taskRow.Status = reader.GetInt32(6);
                taskRow.Tags = reader.GetInt32(7);
                taskList.Add(taskRow);
            }
            return taskList;
        }

        [HttpDelete("DeleteTask")]
        public IActionResult DeleteTask([FromQuery] int id)
        {
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM \"Task\" WHERE \"Id\" = ($1);", conn)
            {
                Parameters =
    {
        new() { Value = id }
    }
            };

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("InsertActivity")]
        public IActionResult InsertActivity([FromQuery] string title, [FromQuery] string description, [FromQuery] string url)
        {
            conn.Open();
            var cmd = new NpgsqlCommand("INSERT INTO \"Activity\" (\"Title\", \"Description\", \"Url\", \"StartDate\", \"EndDate\", \"Status\", \"Tags\", \"ActivityType\") VALUES (($1), ($2), ($3), ($4), ($5), ($6), ($7), ($8));", conn)
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
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetActivities")]
        public List<Activity> GetActivities()
        {
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM \"Activity\"", conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Activity> activityList = new List<Activity>();
            while (reader.Read())
            {
                Activity activityRow = new Activity();
                activityRow.Id = reader.GetInt32(0);
                activityRow.Title = reader.GetString(1);
                activityRow.Description = reader.GetString(2);
                activityRow.Url = reader.GetString(3);
                activityRow.StartDate = reader.GetDateTime(4);
                activityRow.EndDate = reader.GetDateTime(5);
                activityRow.Status = reader.GetInt32(6);
                activityRow.Tags = reader.GetInt32(7);
                activityRow.ActivityType = reader.GetInt32(8);
                activityList.Add(activityRow);
            }
            return activityList;
        }

        [HttpDelete("DeleteActivity")]
        public IActionResult DeleteActivity([FromQuery] int id)
        {
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM \"Activity\" WHERE \"Id\" = ($1);", conn)
            {
                Parameters =
    {
        new() { Value = id }
    }
            };

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPost("InsertTag")]
        public IActionResult InsertTag(string name, string color)
        {
            conn.Open();
            var cmd = new NpgsqlCommand("INSERT INTO \"Tag\" (\"Name\", \"Color\") VALUES (($1), ($2));", conn)
            {
                Parameters =
    {
        new() { Value = name },
        new() { Value = color }
    }
            };
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetTags")]
        public IActionResult GetTags()
        {
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM \"Tag\"", conn);

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("DeleteTag")]
        public IActionResult DeleteTag([FromQuery] int id)
        {
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM \"Tag\" WHERE \"Id\" = ($1);", conn)
            {
                Parameters =
    {
        new() { Value = id }
    }
            };

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }

        //     [HttpPost("InsertStatus")]
        //     public IActionResult InsertStatus([FromQuery] string title, [FromQuery] string style)
        //     {
        //         conn.Open();
        //         var cmd = new NpgsqlCommand("INSERT INTO \"Status\" (\"Title\", \"Style\") VALUES (($1), ($2));", conn)
        //         {
        //             Parameters =
        // {
        //     new() { Value = title },
        //     new() { Value = style }
        // }
        //         };

        //         if (cmd.ExecuteNonQuery() > 0)
        //         {
        //             conn.Close();
        //             return StatusCode(200, "OK");
        //         }
        //         else
        //         {
        //             conn.Close();
        //             return StatusCode(500, "Internal Server Error");
        //         }
        //     }

        [HttpGet("GetStatuses")]
        public IActionResult GetStatuses()
        {
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM \"Status\"", conn);

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "OK");
            }
            else
            {
                conn.Close();
                return StatusCode(500, "Internal Server Error");
            }
        }


        //     [HttpPost("InsertActivityType")]
        //     public IActionResult InsertActivityType([FromQuery] string name)
        //     {
        //         conn.Open();
        //         var cmd = new NpgsqlCommand("INSERT INTO \"ActivityType\" (\"Name\") VALUES (($1));", conn)
        //         {
        //             Parameters =
        // {
        //     new() { Value = name }
        // }
        //         };
        //         if (cmd.ExecuteNonQuery() > 0)
        //         {
        //             conn.Close();
        //             return StatusCode(200, "OK");
        //         }
        //         else
        //         {
        //             conn.Close();
        //             return StatusCode(500, "Internal Server Error");
        //         }
        //     }

        // [HttpGet("GetActivityTypes")]
        // public IActionResult GetActivityTypes()
        // {
        //     conn.Open();
        //     var cmd = new NpgsqlCommand("SELECT * FROM \"ActivityType\"", conn);

        //     NpgsqlDataReader reader = cmd.ExecuteReader();


        //     for (int i = 0; i < reader.FieldCount; i++)
        //     {
        //         reader.GetString(i);
        //     }

        // }
    }
}