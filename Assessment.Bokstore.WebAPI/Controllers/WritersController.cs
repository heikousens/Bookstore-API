using Assessment.Bookstore.Domain.Interfaces;
using Assessment.Bookstore.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Bokstore.WebAPI.Controllers
{
    [Route("api/writers")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        public IWriterService WriterService { get; }
        public IBindBookService BindService { get; }

        public WritersController(IWriterService writerService, IBindBookService bindService)
        {
            WriterService = writerService;
            BindService = bindService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Writer>> GetWriters()
        {
            var writers = WriterService.ShowAllWriters();
            return Ok(writers);
        }

        [HttpGet("{idWriter}")]
        public ActionResult GetWriter([FromRoute] Guid idWriter)
        {
            var writer = WriterService.ShowWriter(idWriter);

            if (writer == null)
            {
                return NotFound();
            }

            return Ok(writer);
        }

        [HttpPost]
        public ActionResult PostWriter([FromBody] DataWriter dataWriter)
        {
            var registeredWriter = WriterService.RegisterWriter(dataWriter);

            return Created("GetWriter", registeredWriter);
        }

        [HttpPut("{idWriter}")]
        public ActionResult<Writer> PutWriter([FromRoute] Guid idWriter, Writer writer)
        {
            if (idWriter != writer.Id)
            {
                return BadRequest();
            }

            WriterService.UpdateWriter(idWriter, writer);

            return Ok(writer);
        }

        [HttpDelete("{idWriter}")]
        public ActionResult<Writer> DeleteWriter([FromRoute] Guid idWriter)
        {

            var writer = WriterService.ShowWriter(idWriter);

            if (writer == null)
            {
                return NotFound();
            }

            WriterService.DeleteWriter(idWriter);

            return NoContent();

        }

        [HttpPost("{idWriter}/books/{idBook}")]
        public ActionResult PostBindWriterToBook([FromRoute] Guid idWriter, [FromRoute] Guid idBook)
        {

            var result = BindService.BindBookToWriter(idWriter, idBook);

            if (!string.IsNullOrEmpty(result.Error))
            {
                return BadRequest(result.Error);
            }

            return Created("", result.Writer);
        }
    }
}
