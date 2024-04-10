﻿using basic_api.Application.Location.Facade;
using basic_api.Controllers;
using basic_api.Domain.Location.Controllers;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Location.Controllers
{
    [ApiController]
    [Route("locations")]
    public class LocationController(LocationFacade facade) : Controller<LocationModel>(facade), ILocationController
    {
    }
}