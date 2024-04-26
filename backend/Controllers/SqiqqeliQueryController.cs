using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Npgsql;

namespace backend
{

    [ApiController]
    [Route("[controller]")]
    public class SqiqqeliQueryController : ControllerBase
    {

        const string connectionString = "host=localhost;port=5432;database=taskmanager;username=postgres;password=password;sslmode=prefer";
        NpgsqlConnection conn = new NpgsqlConnection(connectionString);

        private readonly ILogger<SqiqqeliQueryController> _logger;

        public SqiqqeliQueryController(ILogger<SqiqqeliQueryController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Insert task and free eBooks here")]
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
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }

        [HttpGet("Get tasks plus free eBooks for free")]
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

        [HttpDelete("Delete task and press here for free eBook!")]
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
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }

        [HttpPost("Insert Activity to receive eBooks at no charge")]
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
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }

        [HttpGet("Get activities and free eBooks FREE OF CHARGE!!!")]
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

        [HttpDelete("Delete activity and press here for free eBook!")]
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
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }


        [HttpPost("Insert a tag, but also receive free eBook!")]
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
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }

        [HttpGet("Get tags. Get free eBooks.")]
        public IActionResult GetTags()
        {
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM \"Tag\"", conn);

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }

        [HttpDelete("Delete tag and click here for hundreds of free eBooks!")]
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
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }

        //     [HttpPost("Insert status and receive free eBook!")]
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
        //             return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
        //         }
        //         else
        //         {
        //             conn.Close();
        //             return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
        //         }
        //     }

        [HttpGet("Get statuses in addition to your free eBooks. So cool.")]
        public IActionResult GetStatuses()
        {
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT * FROM \"Status\"", conn);

            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
            }
            else
            {
                conn.Close();
                return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
            }
        }


        //     [HttpPost("Insert Activity Type plus get a free eBook!")]
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
        //             return StatusCode(200, "\n                                                            ,1," + "\n                               ......                     .ifL1" + "\n                            .;1ttttLLf1,                 ;fffff," + "\n                           :LCLfttfLLLLL:              ,tffffffi" + "\n                          ,CCCLf11ff1tff;            ,1Lffffffff." + "\n                          iLttt11ifLLLfft.           :iitffffffLi" + "\n                          ;t1111ii1fffff1               ffffft;i1." + "\n                          ,1iiiiii1tt1it,              ifffff," + "\n                           ;1i;;;;i1tff:              .fffff1" + "\n                           ,t1ii;:::;i;               ifffff," + "\n                          .,;11iii;:                 .fffff1" + "\n                     ..,,.,,.,iftitGi...             ifffff," + "\n                 .,,,::::,,,,..;LLLGt::::,,,.       .fffff1" + "\n                 ;,,,,,,,,,,,,,.,;tfi,::,,::::,     ;fffff," + "\n                 ::,,,,,,,,..,:,,.:ft,::,,:,,::.   .fffff1" + "\n                 ,i:,,,,,,,,..,,,,,,;,:::,:,,,::   ;fffff," + "\n                 .1:,,,,,,,,..,,,:,,,::,,,:,,,,:, .fffff1" + "\n                  ;;:,,,,,:, ..,,,::,,,:,,:,,,,::.,1tfff:" + "\n                  ,1;:,,,,;f:.,,,,,,:,..,,:,..,,::,  ..," + "\n                   ;i::,,,,,:,,:,,:,:::,,,;1:,.,,,:," + "\n                   .;;;:,,,,,,,,,::::::::::LGC;,,,,:." + "\n                    .;;:,,.,,,,,,,,,,,,,,:::;;:,,,,,:" + "\n                     ,:::,.....,,,,,,,,,,,:,,,,,,,,,:." + "\n                     ....,....,,,,,,.....,,,,,,,,,,,,." + "\n                     ,,..     .,::;:........,,,,,..." + "\n                     :,,......      ............" + "\n                     :,...........   ....:,...,." + "\n                     ,,............. ...,1;,,,,." + "\n                                         ..");
        //         }
        //         else
        //         {
        //             conn.Close();
        //             return StatusCode(418, "\n               ..,,:::;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::1ffLLLLLLLLLLL" + "\n              ..,,::;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;::::iiiiiiii;ii11ttttttttt" + "\n           .,,,:;;;;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,:;iiiiiiiiiiiii;;;;;;;;;;" + "\n         .,..,:;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,t1iiiiiiiiiiiiiiiiiiiiiiiii" + "\n            :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  ;C00L1iiiiiiiiiiiiiiiiiiiiiii" + "\n           :iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii;,  :tG0000Gfiiiiiiiiiiiiiiiiiiiiii" + "\n ::::::,,..;iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii:. ,tG00000000Liiiiiiiiiiiiiiiiiiiii" + "\n ;;;;iiii::iiiiiiiiiiiiiiiiiiiii;iiiiiiiiii;.  ;C00000000000C1iiiiiiiiiiiiiiiiiii" + "\n 11i;::;i;;iiiiiiiiiiiiiiii;;;iiii;iiiiii;,  :f0Ct11fC0000000G1;iiiiiiii;;;;i:;ii" + "\n 11111i;:;iiiiiiiiiiiiiiiiiiiiiiii:;iii;,  ,tG00i,. .,iL000000L,:iii;;;;itLCf:ii;" + "\n 1111111i:;iiiiiiiiiiiiiiiiiiii;;iii;:,..,:t0000t,    .:L0000C;,,;;;ifCG88@@L:;;:" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii;;;:::;ii;f000Gt:.. .:f000L;,::;tG8@@@@88Gt:;;i" + "\n 11111111i;iiiiiiiiiiiiiiiiiiiiiii,.:,::;;ii;f0000Cft1tLG0Gf::,,iC8@@8@80CC0C;iii" + "\n 11111111;;iiiiiiiiiiiiiiiiiiii;,.  :;;:;:;ii;1C00000000GLi::,iC8@88@80CG8@@81;;i" + "\n 1111iii;;iiiiiiiiiiiiiiiiiii;,  ..:iiii;:;iii;itCGGGCLti;:::f8@888@8CC8@@@@@8L1i" + "\n 1111;;;;;;;;iiiiiiiiiiiiii;.  .iLCt;;ii;;iiiiii;;i;:::,:::;L8@888@0L0@@@@@@@@8Gf" + "\n 1111111i;;:;iiiiiiiiiiii;,  .1C0000Gt;;iiiiiiiiiii;:;;;;;;G@8888@GC8@@@@@@@8GG08" + "\n 111111i;;;;:iiiiiiiiiii:.  :LGLLLCG00C1;;iiiiiiiiiiiiii;iG@888@@CC@@@@@@@0CG8@@@" + "\n i1111111111;;iiiiiiiii:  .1GL;,..,iL000Li;iiiiiiiiiiii;i0@888@@0C@@@@@@8CC8@@@@@" + "\n .,;i11111111;;iiiiiii:  ;L001,    .:f000Gi:iiiiiiiii;;;C@8888@@@@@@@@8GC8@@@@@@@" + "\n    .,:;iiiii;:;iiiii:  iGG00L:.    .;G000L,;iiii;::::::C8@@8@@@@@@@@0C0@@@@@@@@@" + "\n         ..... .:iiii: .tGGG00L1;,..,iGGGGf.:;iii;,..,. .:f88@@@@@@@CC8@@@@@@@@@@" + "\n                 :iii;.:;tGGGG00GCLffCGGGL:,:iiii;..f0i    L@@@@@@@@8@@@@@88@@@@@" + "\n                  ,:ii;ii;1LGGGGG00GGGGGf;::;ii;;, ;8t.    f@@@@@@@@@@@@@@@8@@@@@" + "\n                    ,;iiiii;1LGGGGGGGGLi,:;:;i1tfi .:      C@@@@@@@@@8GLC8@@@@@@@" + "\n                     .:iiiii;i1fLCCCCt:,:;;:1C08@0i:::::;;i0@@@@@@@0LiiG@@@@@@@@@" + "\n                       ,;iiiiii;iii;:,:;;;;t8@@8@@@88888@@@@@8088G1::f8@@@@@@@@@@" + "\n                        .:iiiiiiii;;;;iii;f8@@@@@@@@@@@@@@@@@@8Gi,,t08G0@@@@@@@@@" + "\n                          ,;iiiiiiiiiiii;i8@80GG@@@@@@@@@@@@@@8t:1G80G88888@@@@@@" + "\n                           .:iiiiiiiiiii;180CC0@@@@@@@@@@@@@@@CL08008@@888@@@@@@@" + "\n                             :iiiiiiiiii;;CG88@@@@@8GG0@@@@@@@@@@@@@888@@@@@@@@@@" + "\n                             ,iiiiiiii;:::0@@8@@8GGG0@@@@@@888@@@@@@@@@@@@@@@@@@@");
        //         }
        //     }

        // [HttpGet("Get activity types at no cost, just like our eBooks!")]
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