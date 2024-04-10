////using Microsoft.AspNetCore.Mvc;

////// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

////namespace EmployeeServer.Api.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class EmailSenderController : ControllerBase
////    {
////        // GET: api/<EmailSenderController>
////        [HttpGet]
////        public IEnumerable<string> Get()
////        {
////            return new string[] { "value1", "value2" };
////        }

////        // GET api/<EmailSenderController>/5
////        [HttpGet("{id}")]
////        public string Get(int id)
////        {
////            return "value";
////        }

////        // POST api/<EmailSenderController>
////        [HttpPost]
////        public void Post([FromBody] string value)
////        {
////        }

////        // PUT api/<EmailSenderController>/5
////        [HttpPut("{id}")]
////        public void Put(int id, [FromBody] string value)
////        {
////        }

////        // DELETE api/<EmailSenderController>/5
////        [HttpDelete("{id}")]
////        public void Delete(int id)
////        {
////        }
////    }
////}
////using System;
////using System.Net;
////using System.Net.Mail;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Mvc;

////namespace EmailSender.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class EmailController : ControllerBase
////    {
////        private const string SenderEmail = "batya4119712@gmail.com"; // כתובת המייל שלך
////        private const string SenderPassword = "326656899"; // הסיסמה של המייל שלך

////        [HttpPost]
////        public async Task<IActionResult> SendEmail(EmailModel emailModel)
////        {
////            try
////            {
////                var smtpClient = new SmtpClient("smtp.gmail.com")
////                {
////                    Port = 587,
////                    Credentials = new NetworkCredential(SenderEmail, SenderPassword),
////                    EnableSsl = true,
////                };

////                var message = new MailMessage(SenderEmail, emailModel.ToEmail)
////                {
////                    Subject = "סיסמה חדשה", // נושא האימייל
////                    Body = $"שם: {emailModel.Name}\nסיסמה: {GeneratePassword()}" // גוף האימייל
////                };

////                await smtpClient.SendMailAsync(message);
////                return Ok("הודעת האימייל נשלחה בהצלחה.");
////            }
////            catch (Exception ex)
////            {
////                return BadRequest($"שגיאה בשליחת האימייל: {ex.Message}");
////            }
////        }

////        // פונקציה ליצירת סיסמה אקראית
////        private string GeneratePassword()
////        {
////            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
////            var random = new Random();
////            var password = new char[8];
////            for (int i = 0; i < password.Length; i++)
////            {
////                password[i] = chars[random.Next(chars.Length)];
////            }
////            return new string(password);
////        }
////    }

////    // מודל עבור פרטי האימייל
////    public class EmailModel
////    {
////        public string Name { get; set; }
////        public string ToEmail { get; set; }
////    }
////}
//using System;
//using System.Net;
//using System.Net.Mail;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace EmailSender.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmailController : ControllerBase
//    {
//        private const string SenderEmail = "batya4119712@gmail.com"; // כתובת המייל שלך
//        private const string SenderPassword = "326656899"; // הסיסמה של המייל שלך

//        [HttpPost]
//        public async Task<IActionResult> SendEmail(EmailModel emailModel)
//        {
//            try
//            {
//                var smtpClient = new SmtpClient("smtp.gmail.com")
//                {
//                    Port = 465,
//                    Credentials = new NetworkCredential(SenderEmail, SenderPassword),
//                    EnableSsl = true, // הפעלת חיבור SSL
//                };

//                var message = new MailMessage(SenderEmail, emailModel.ToEmail)
//                {
//                    Subject = "סיסמה חדשה", // נושא האימייל
//                    Body = $"שם: {emailModel.Name}\nסיסמה: {GeneratePassword()}" // גוף האימייל
//                };

//                await smtpClient.SendMailAsync(message);
//                return Ok("הודעת האימייל נשלחה בהצלחה.");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest($"שגיאה בשליחת האימייל: {ex.Message}");
//            }
//        }

//        // פונקציה ליצירת סיסמה אקראית
//        private string GeneratePassword()
//        {
//            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
//            var random = new Random();
//            var password = new char[8];
//            for (int i = 0; i < password.Length; i++)
//            {
//                password[i] = chars[random.Next(chars.Length)];
//            }
//            return new string(password);
//        }
//    }

//    // מודל עבור פרטי האימייל
//    public class EmailModel
//    {
//        public string Name { get; set; }
//        public string ToEmail { get; set; }
//    }
//}


