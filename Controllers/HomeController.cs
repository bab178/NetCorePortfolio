using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCorePortfolio.Models.Home;
using NetCorePortfolio.Models.Shared;
using NetCorePortfolio.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NetCorePortfolio.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IResumeRepository _resumeRepository;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IResumeRepository resumeRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _resumeRepository = resumeRepository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            SetTitleAndDescription();

            var portfolioItems = new List<PortfolioItem>();
            _configuration.GetSection("PortfolioItems").Bind(portfolioItems);

            return View("Index", new IndexViewModel(portfolioItems));
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            SetTitleAndDescription();
            return View("Contact");
        }

        [HttpGet("TryGetLatestResume")]
        public FileContentResult TryGetLatestResume()
        {
            var bytes = _resumeRepository.TryGetLatestResume();
            return bytes != null ? File(bytes, "application/pdf") : null;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromForm] EmailFormModel emailFormModel)
        {
            SetTitleAndDescription();

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage);

                return BadRequest(errors);
            }

            try
            {
                string subject = $"New Portfolio Contact - {emailFormModel.Subject}";
                string body = GetHtmlEmailBody(emailFormModel);

                await SendContactEmailAsync(subject, body);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email");
            }

            return Json(new { success = false });
        }


        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SetTitleAndDescription()
        {
            ViewBag.Title = _configuration.GetValue<string>("Page:Title");
            ViewBag.Description = _configuration.GetValue<string>("Page:Description");
        }

        private string GetHtmlEmailBody(EmailFormModel emailFormModel)
        {
            var stringBuilder = new StringBuilder("<h2>Portfolio Contact Data</h2>");
            stringBuilder.AppendLine($"<p>Name: {emailFormModel.Name}</p>");
            stringBuilder.AppendLine($"<p>Email: {emailFormModel.FromEmailAddress}</p>");
            stringBuilder.AppendLine($"<p>Message:<br/>{emailFormModel.Message}</p>");
            return stringBuilder.ToString();
        }

        private async Task SendContactEmailAsync(string subject, string body)
        {
            string host = _configuration.GetValue<string>("Smtp:Host");
            int port = _configuration.GetValue<int>("Smtp:Port");
            string fromEmailAddress = _configuration.GetValue<string>("Smtp:FromAddress");
            string toEmailAddress = _configuration.GetValue<string>("Smtp:ToAddress");
            string username = _configuration.GetValue<string>("Smtp:Username");
            string password = _configuration.GetValue<string>("Smtp:Password");

            var credentials = new NetworkCredential(username, password);
            using (var smtpClient = new SmtpClient(host, port))
            {
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                using (var message = new MailMessage())
                {
                    message.IsBodyHtml = true;

                    message.From = new MailAddress(fromEmailAddress);
                    message.To.Add(toEmailAddress);
                    message.Subject = subject;
                    message.Body = body;

                    await smtpClient.SendMailAsync(message);
                }
            }
        }
    }
}
