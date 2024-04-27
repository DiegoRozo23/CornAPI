using API_Contro_Plagas.Context;
using API_Contro_Plagas.Repostitories;
using API_Contro_Plagas.Services;
using Microsoft.EntityFrameworkCore;
//using API_Contro_Plagas.Repositories;
//using API_Contro_Plagas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AppRepositories

builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<IEvolutionCropRepository, EvolutionCropRepository>();
builder.Services.AddScoped<IExterminationRepository, ExterminationRepository>();
builder.Services.AddScoped<IPesticideRepository, PesticideRepository>();
builder.Services.AddScoped<IPlagueRepository, PlagueRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ITypeCropRepository, TypeCropRepository>();
builder.Services.AddScoped<ITypePlagueRepository, TypePlagueRepository>();
builder.Services.AddScoped<ITypeUserRepository, TypeUserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region AppServices

builder.Services.AddScoped<ICropService, CropService>();
builder.Services.AddScoped<IEvolutionCropService, EvolutionCropService>();
builder.Services.AddScoped<IExterminationService, ExterminationService>();
builder.Services.AddScoped<IPesticideService, PesticideService>();
builder.Services.AddScoped<IPlagueService, PlagueService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ITypeCropService, TypeCropService>();
builder.Services.AddScoped<ITypePlagueService, TypePlagueService>();
builder.Services.AddScoped<ITypeUserService, TypeUserService>();
builder.Services.AddScoped<IUserService, UserService>();




#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
