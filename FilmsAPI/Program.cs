using FilmsAPI;
using Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddJwt();
builder.Services.AddSwagger();
builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

//Adiciona a POLICY de autorazição e autenticação
builder.Services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
         JwtBearerDefaults.AuthenticationScheme);

    defaultAuthorizationPolicyBuilder =
        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
});

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

app.MapControllers();
app.Run();