using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Storage.WebApi.Core;
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
            if (reminderItem == null)
            {
                return NotFound();
            }

            var model = new ReminderItemGetModel(reminderItem);
            return Ok(model);
        }



        [HttpPost]
        public IActionResult Add([FromBody] ReminderItemAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReminderItem reminderItem = new ReminderItem(
                model.Date,
                model.Message,
                model.ContactId,
                model.Status);

            _storage.Add(reminderItem);
            return CreatedAtAction(
                nameof(Get),
                new { id = reminderItem.Id },
                new ReminderItemGetModel(reminderItem));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ReminderItemUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReminderItem reminderItem = _storage.Get(id);
            if (reminderItem == null)
            {
                return NotFound();
            }
            
            model.UpdateRemiderItem(reminderItem);
            _storage.Update(reminderItem);

            return NoContent();
        }
    }
}
