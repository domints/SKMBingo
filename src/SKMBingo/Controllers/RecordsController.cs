using Microsoft.AspNetCore.Mvc;
using SKMBingo.Models.Api;
using SKMBingo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SKMBingo.Controllers
{
    [Route("api/records")]
    public class RecordsController : Controller
    {
        IRecordService _rService;

        public RecordsController(IRecordService recordService)
        {
            _rService = recordService;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Record> GetAll()
        {
            return _rService.GetAll();
        }

        [Route("today")]
        [HttpGet]
        public IEnumerable<Record> GetToday()
        {
            return _rService.GetForDay(DateTime.Now);
        }

        [Route("{day}")]
        [HttpGet]
        public IEnumerable<Record> GetDay(DateTime day)
        {
            return _rService.GetForDay(day);
        }

        [Route("{id}")]
        [HttpPost]
        public ActionResult Check(int id)
        {
            if(_rService.Check(id))
            {
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult UnCheck(int id)
        {
            if(_rService.Uncheck(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
