using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.Dependency.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<ITravelDal, EfTraveldal>();
//builder.Services.AddSingleton<ITravelService, TravelManager>();
//builder.Services.AddSingleton<IFaqService, FaqManager>();
//builder.Services.AddSingleton<IFaqDal, EfFaqDal>();
//builder.Services.AddSingleton<IAboutService, AboutManager>();
//builder.Services.AddSingleton<IAboutDal, EfAboutDal>();
//builder.Services.AddSingleton<ICategoryService, CategoryManager>();
//builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
//builder.Services.AddSingleton<IBlogService, BlogManager>();
//builder.Services.AddSingleton<IBlogDal, EfBlogDal>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<AutofacBusinessModule>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
