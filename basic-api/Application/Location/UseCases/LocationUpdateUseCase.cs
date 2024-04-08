﻿using basic_api.Application.Base.UseCase;
using basic_api.Domain.Location.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Location.UseCases
{
    public class LocationUpdateUseCase(BaseRepository<LocationModel> repo) : UpdateUseCase<LocationModel>(repo), ILocationUpdateUseCase
    {
    }
}
