﻿using basic_api.Domain.Base.Controller;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;

namespace basic_api.Domain.Location.Controllers
{
    public interface ILocationController : IController<LocationModel, LocationGetModel, LocationUpdateModel>
    {
    }
}
