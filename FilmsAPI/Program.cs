using FilmsAPI;
using FilmsAPI.Middlewares;
using Infra;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddJwt();
builder.Services.AddSwagger();
builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

//Adiciona a validação e uso dos JWTs e outras POLICIES
app.UseAuthorization();
app.UseAuthentication();
app.UseMiddleware<GlobalErrorMiddleware>();
app.MapControllers();
app.Run();