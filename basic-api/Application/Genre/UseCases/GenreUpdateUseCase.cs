﻿using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Genre.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Genre.UseCases
{
    public class GenreUpdateUseCase(IGenreRepository repo) : UpdateUseCase<GenreModel>(repo), IGenreUpdateUseCase
    {
    }
}
