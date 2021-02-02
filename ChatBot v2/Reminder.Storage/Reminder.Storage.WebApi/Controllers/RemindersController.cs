using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Storage.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Reminder.Storage.WebApi.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderStorage _storage;
        private readonly ILogger<ReminderController> _logger;

        public ReminderController(
            ILogger<ReminderController> logger,
            IReminderStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var reminderItems = _storage.GetList(new[]
              {
                ReminderItemStatus.Awaiting,
                ReminderItemStatus.Failed,
                ReminderItemStatus.ReadyToSend,
                ReminderItemStatus.SuccessfullySent
            });

         List<ReminderItemGetModel> result = reminderItems
                .Select(ri => new ReminderItemGetModel(ri))
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            ReminderItem reminderItem = _storage.Get(id);
            var model = new ReminderItemGetModel(reminderItem);

            return Ok(result);
        }



        [HttpPost]
        public IActionResult Add([FromBody]ReminderItemAddModel model)
        {


            ReminderItem reminderItem = new ReminderItem(
                model.Date,
                model.Message,
                model.ContactId,
                model.Status);

            _storage.Add(reminderItem);
            return Created();
        }
    }
}
