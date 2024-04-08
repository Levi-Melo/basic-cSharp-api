using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Domain.Writer.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Writer.Facade
{
    public class WriterFacade(
        GetUseCase<WriterModel> getUseCase, 
        DeleteUseCase<WriterModel> deleteUseCase, 
        InsertUseCase<WriterModel> insertUseCase, 
        UpdateUseCase<WriterModel> updateUseCase
        ) : Facade<WriterModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IWriterFacade
    {
    }
}
