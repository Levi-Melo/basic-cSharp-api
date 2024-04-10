using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Application.Writer.UseCases;
using basic_api.Domain.Writer.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Writer.Facade
{
    public class WriterFacade(
        WriterGetUseCase getUseCase,
        WriterDeleteUseCase deleteUseCase,
        WriterInsertUseCase insertUseCase,
        WriterUpdateUseCase updateUseCase
        ) : Facade<WriterModel>(
            getUseCase,
            deleteUseCase,
            insertUseCase,
            updateUseCase), IWriterFacade
    {
    }
}
