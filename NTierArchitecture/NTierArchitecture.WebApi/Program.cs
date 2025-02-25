using NTierArchitecture.DataAccess;
using NTierArchitecture.Business;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NTierArchicture.Entities.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));

var serviceProvider = builder.Services.BuildServiceProvider();

var jwtConfiguration = serviceProvider.GetRequiredService<IOptions<Jwt>>().Value;

builder.Services.AddAuthentication().AddJwtBearer(cfr =>
{
    cfr.TokenValidationParameters = new()
    {
        ValidateIssuer = true,      //Uyg kime ait- hangi siteye ait oldu�unu belirtir bunun kontrolu
        ValidateAudience = true,    //Uygulamam�n hangi siteye a��ld���n� uyg kontrolu
        ValidateIssuerSigningKey = true, //Bizim verice�imiz g�venlik anahtar�n�n do�rulanmas�n� isteyip istemeyece�imizi
        ValidateLifetime = true,    //Uyg da bir son tarihimiz varsa (token i�in)
        ValidIssuer = "",
        ValidAudience = "",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddBusiness();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
