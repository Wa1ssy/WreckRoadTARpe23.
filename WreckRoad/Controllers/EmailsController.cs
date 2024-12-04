using Microsoft.AspNetCore.Mvc;
using WreckRoad.Core.Dto;
using WreckRoad.Models.Emails;

namespace WreckRoad.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailsController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel) 
        {
            var dto = new EmailDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
            };
            _emailServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
