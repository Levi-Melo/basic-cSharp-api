using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Writer.Controllers;
using basic_api.Domain.Writer.Facade;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Writer.Controllers
{
    [ApiController]
    [Route("writers")]
    public class WriterController(IWriterFacade facade) : Controller<WriterModel, WriterGetModel, WriterUpdateModel>(), IWriterController
    {
        readonly IWriterFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(WriterGetModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<WriterGetModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override WriterModel Get(WriterGetModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<WriterModel> Get(GetManyParams<WriterGetModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override WriterModel Insert(WriterModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<WriterModel> Insert(IEnumerable<WriterModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public override WriterModel Update(WriterUpdateModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<WriterModel> Update(IEnumerable<WriterUpdateModel> input)
        {
            return _facade.Update(input);
        }
    }
}
