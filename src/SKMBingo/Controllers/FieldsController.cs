using Microsoft.AspNetCore.Mvc;
using SKMBingo.Models.Api;
using SKMBingo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SKMBingo.Controllers
{
    [Route("api/fields")]
    public class FieldsController : Controller
    {
        IFieldService _fService;
        public FieldsController(IFieldService fieldService)
        {
            _fService = fieldService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Field> GetAll()
        {
            return _fService.GetFields(true);
        }

        [HttpGet]
        [Route("active")]
        public IEnumerable<Field> GetActive()
        {
            return _fService.GetFields();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetSingle(int id)
        {
            Field fld = _fService.GetSingle(id);
            if(fld == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(fld);
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult Add([FromBody] Field field)
        {
            int id = _fService.AddField(field);
            if(id == -2)
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }
            else if(id > 0)
            {
                return CreatedAtRoute("api/fields/{id}", id);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, [FromBody]Field field)
        {
            if(field.Id != 0 && field.Id != id)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            if(_fService.Update(id, field))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}/activate")]
        public ActionResult Activate(int id)
        {
            int result = _fService.Activate(id);
            if (result == 1)
            {
                return Ok();
            }
            else if(result == 0)
            {
                return NotFound();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }
        }

        [HttpPut]
        [Route("{id}/deactivate")]
        public ActionResult Deactivate(int id)
        {
            if (_fService.Deactivate(id))
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
