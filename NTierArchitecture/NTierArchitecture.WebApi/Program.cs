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
        ValidateIssuer = true,      //Uyg kime ait- hangi siteye ait olduğunu belirtir bunun kontrolu
        ValidateAudience = true,    //Uygulamamın hangi siteye açıldığını uyg kontrolu
        ValidateIssuerSigningKey = true, //Bizim vericeğimiz güvenlik anahtarının doğrulanmasını isteyip istemeyeceğimizi
        ValidateLifetime = true,    //Uyg da bir son tarihimiz varsa (token için)
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
