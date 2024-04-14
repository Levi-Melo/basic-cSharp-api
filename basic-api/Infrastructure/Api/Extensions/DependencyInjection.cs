using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Services;
using basic_api.Domain.Account.UseCases;
using basic_api.Application.Account.UseCases;
using basic_api.Domain.Book.UseCases;
using basic_api.Application.Book.UseCases;
using basic_api.Domain.Genre.UseCases;
using basic_api.Application.Genre.UseCases;
using basic_api.Domain.Location.UseCases;
using basic_api.Application.Location.UseCases;
using basic_api.Domain.Publisher.UseCases;
using basic_api.Application.Publisher.UseCases;
using basic_api.Domain.Stock.UseCases;
using basic_api.Application.Stock.UseCases;
using basic_api.Domain.Tenant.UseCases;
using basic_api.Application.Tenant.UseCases;
using basic_api.Domain.Writer.UseCases;
using basic_api.Application.Writer.UseCases;
using basic_api.Domain.Order.UseCases;
using basic_api.Application.Order.UseCases;
using basic_api.Domain.Account.Facade;
using basic_api.Application.Account.Facade;
using basic_api.Domain.Book.Facade;
using basic_api.Application.Book.Facade;
using basic_api.Domain.Genre.Facade;
using basic_api.Application.Genre.Facade;
using basic_api.Application.Location.Facade;
using basic_api.Domain.Location.Facade;
using basic_api.Domain.Order.Facade;
using basic_api.Application.Order.Facade;
using basic_api.Domain.Publisher.Facade;
using basic_api.Application.Publisher.Facade;
using basic_api.Domain.Stock.Facade;
using basic_api.Application.Tenant.Facade;
using basic_api.Application.Stock.Facade;
using basic_api.Domain.Account.Controllers;
using basic_api.Application.Account.Controllers;
using basic_api.Domain.Book.Controllers;
using basic_api.Application.Book.Controllers;
using basic_api.Domain.Genre.Controllers;
using basic_api.Application.Genre.Controllers;
using basic_api.Domain.Location.Controllers;
using basic_api.Application.Location.Controllers;
using basic_api.Domain.Publisher.Controllers;
using basic_api.Application.Publisher.Controllers;
using basic_api.Domain.Stock.Controllers;
using basic_api.Application.Stock.Controllers;
using basic_api.Domain.Order.Controller;
using basic_api.Application.Order.Controller;
using basic_api.Application.Tenant.Controllers;
using basic_api.Domain.Tenant.Facade;
using basic_api.Domain.Tenant.Controller;
using basic_api.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Amazon.S3;
using Amazon.Runtime;
using Amazon;


namespace basic_api.Infrastructure.Api.Extensions
{
    public static class DependencyInjection
    {
            public static void Inject(this IServiceCollection serviceCollection, IConfiguration configuration)
            {
                serviceCollection.AddSignalR();

                serviceCollection.AddDbContext<DataContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


                // Services
                serviceCollection.AddTransient<IFileService, FileService>(sp =>
                {
                    BasicAWSCredentials creds = new(configuration.GetConnectionString("AccessKeyID"), configuration.GetConnectionString("secretAccessKeyID"));

                    var s3Client = new AmazonS3Client(creds, new AmazonS3Config
                    {
                        RegionEndpoint = RegionEndpoint.USEast1,
                    });
                    return new FileService(s3Client, configuration.GetConnectionString("DefaultAwsBucket"), configuration.GetConnectionString("DefaultAwsDirectory"));
                });

                serviceCollection.AddTransient<IAuthService<AuthPayload>, AuthService<AuthPayload>>(sp =>
                {
                    return new AuthService<AuthPayload>(configuration, 60 * 24);
                });

                serviceCollection.AddTransient<IEmailService, EmailService>(sp =>
                {
                    var s3Client = new AmazonS3Client()
                    {
                        Config =
                                {
                                    //adicionar configuração
                                }
                    };
                    return new EmailService(
                        configuration.GetConnectionString("SmtpServer"),
                        int.Parse(configuration.GetConnectionString("SmtpPort")),
                        configuration.GetConnectionString("UserName"),
                        configuration.GetConnectionString("UserPassword"));
                });

                // Repositories
                serviceCollection.AddScoped<ITenantRepository, TenantRepository>();
                serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
                serviceCollection.AddScoped<IBookRepository, BookRepository>();
                serviceCollection.AddScoped<IGenreRepository, GenreRepository>();
                serviceCollection.AddScoped<ILocationRepository, LocationRepository>();
                serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
                serviceCollection.AddScoped<IPublisherRepository, PublisherRepository>();
                serviceCollection.AddScoped<IRoleRepository, RoleRepository>();
                serviceCollection.AddScoped<IStockRepository, StockRepository>();
                serviceCollection.AddScoped<IWriterRepository, WriterRepository>();

                // UseCases
                
                // Account
                serviceCollection.AddScoped<IAccountGetUseCase, AccountGetUseCase>();
                serviceCollection.AddScoped<IAccountSignInUseCase, AccountSignInUseCase>();
                serviceCollection.AddScoped<IAccountUpdateUseCase, AccountUpdateUseCase>();
                serviceCollection.AddScoped<IAccountDeleteUseCase, AccountDeleteUseCase>();
                serviceCollection.AddScoped<IAccountInsertUseCase, AccountInsertUseCase>();

                // Book
                serviceCollection.AddScoped<IBookGetUseCase, BookGetUseCase>();
                serviceCollection.AddScoped<IBookUpdateUseCase, BookUpdateUseCase>();
                serviceCollection.AddScoped<IBookDeleteUseCase, BookDeleteUseCase>();
                serviceCollection.AddScoped<IBookInsertUseCase, BookInsertUseCase>();

                // Genre
                serviceCollection.AddScoped<IGenreGetUseCase, GenreGetUseCase>();
                serviceCollection.AddScoped<IGenreUpdateUseCase, GenreUpdateUseCase>();
                serviceCollection.AddScoped<IGenreDeleteUseCase, GenreDeleteUseCase>();
                serviceCollection.AddScoped<IGenreInsertUseCase, GenreInsertUseCase>();

                // Location
                serviceCollection.AddScoped<ILocationGetUseCase, LocationGetUseCase>();
                serviceCollection.AddScoped<ILocationUpdateUseCase, LocationUpdateUseCase>();
                serviceCollection.AddScoped<ILocationDeleteUseCase, LocationDeleteUseCase>();
                serviceCollection.AddScoped<ILocationInsertUseCase, LocationInsertUseCase>();

                // Publisher
                serviceCollection.AddScoped<IPublisherGetUseCase, PublisherGetUseCase>();
                serviceCollection.AddScoped<IPublisherUpdateUseCase, PublisherUpdateUseCase>();
                serviceCollection.AddScoped<IPublisherDeleteUseCase, PublisherDeleteUseCase>();
                serviceCollection.AddScoped<IPublisherInsertUseCase, PublisherInsertUseCase>();

                // Stock
                serviceCollection.AddScoped<IStockGetUseCase, StockGetUseCase>();
                serviceCollection.AddScoped<IStockUpdateUseCase, StockUpdateUseCase>();
                serviceCollection.AddScoped<IStockDeleteUseCase, StockDeleteUseCase>();
                serviceCollection.AddScoped<IStockInsertUseCase, StockInsertUseCase>();

                // Tenant
                serviceCollection.AddScoped<ITenantGetUseCase, TenantGetUseCase>();
                serviceCollection.AddScoped<ITenantUpdateUseCase, TenantUpdateUseCase>();
                serviceCollection.AddScoped<ITenantDeleteUseCase, TenantDeleteUseCase>();
                serviceCollection.AddScoped<ITenantInsertUseCase, TenantInsertUseCase>();

                // Writer
                serviceCollection.AddScoped<IWriterGetUseCase, WriterGetUseCase>();
                serviceCollection.AddScoped<IWriterUpdateUseCase, WriterUpdateUseCase>();
                serviceCollection.AddScoped<IWriterDeleteUseCase, WriterDeleteUseCase>();
                serviceCollection.AddScoped<IWriterInsertUseCase, WriterInsertUseCase>();

                // Order
                serviceCollection.AddScoped<IOrderGetUseCase, OrderGetUseCase>();
                serviceCollection.AddScoped<IOrderUpdateUseCase, OrderUpdateUseCase>();
                serviceCollection.AddScoped<IOrderDeleteUseCase, OrderDeleteUseCase>();
                serviceCollection.AddScoped<IOrderInsertUseCase, OrderInsertUseCase>();
                serviceCollection.AddScoped<IAccessOrderStooksUseCase, AccessOrderStooksUseCase>();
                serviceCollection.AddScoped<IDevolveOrderUseCase, DevolveOrderUseCase>();
                serviceCollection.AddScoped<IReplyOrderUseCase, ReplyOrderUseCase>();
                serviceCollection.AddScoped<IVerifyStatusOrderUsecase, VerifyStatusOrderUsecase>();
            

                // Facades
                serviceCollection.AddScoped<IAccountFacade, AccountFacade>();
                serviceCollection.AddScoped<IBookFacade, BookFacade>();
                serviceCollection.AddScoped<IGenreFacade, GenreFacade>();
                serviceCollection.AddScoped<ILocationFacade, LocationFacade>();
                serviceCollection.AddScoped<IPublisherFacade, PublisherFacade>();
                //serviceCollection.AddScoped<IRoleFacade, RoleFacade>();
                serviceCollection.AddScoped<IStockFacade, StockFacade>();
                serviceCollection.AddScoped<ITenantFacade, TenantFacade>();
                serviceCollection.AddScoped<IOrderFacade, OrderFacade>();

                // Controllers
                serviceCollection.AddScoped<IAccountController, AccountController>();
                serviceCollection.AddScoped<IBookController, BookController>();
                serviceCollection.AddScoped<IGenreController, GenreController>();
                serviceCollection.AddScoped<ILocationController, LocationController>();
                serviceCollection.AddScoped<IPublisherController, PublisherController>();
                //serviceCollection.AddScoped<IRoleController, RoleController>();
                serviceCollection.AddScoped<IStockController, StockController>();
                serviceCollection.AddScoped<ITenantController, TenantController>();
                serviceCollection.AddScoped<IOrderController, OrderController>();
        }

    }
}
