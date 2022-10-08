using MailWebApi.Models;
using MailWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    /// <summary>
    /// EMail Controller for sending a message
    /// </summary>
    public class MailsController : ControllerBase
    {
        private  IMailService _mailService;
        private  IDataStorage<Mail> _mailData;

        public MailsController(IMailService mailService , IDataStorage<Mail> mailData)
        {
            _mailData = mailData;
            _mailService = mailService;
        }

        [HttpGet()]
        /// <summary>
        /// GET request to recive all storage email
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAll()
        {
            var allMessages = await _mailData.GetAllAsync();
            var allMessagesDTO = await allMessages.Select(x => new MailDTO
             {
                 Subject = x.Subject,
                 Body = x.Body,
                 Recipients = (List<string>)x.Recipients.Select(x => x.ToString()),
                 Date = x.Date,
                 Result = x.Result,
                 FailedMessage = x.FailedMessage
             }
            ).ToListAsync();
            return Ok(allMessagesDTO);
        }
        [HttpPost()]
        /// <summary>z
        /// POST request for send emails and store it
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns>Contain request for send emails </returns>
        public async Task<IActionResult> PostMail(MailRequestDTO mailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var mail = await _mailService.SendEmailAsync(mailRequest);
                await _mailData.AddAsync(mail);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
