using DinkToPdf.Contracts;
using DinkToPdf;
using DoctorConsultent_API.Context;
using DoctorConsultent_API.IRepository;
using DoctorConsultent_API.IServices;
using DoctorConsultent_API.Repository;
using DoctorConsultent_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Add Repositories
builder.Services.AddScoped(typeof(IUserDetailsRepository), typeof(UserDetailRepository));
//Add Services
builder.Services.AddScoped(typeof(IUserDetails), typeof(SUserDetails));
builder.Services.AddScoped(typeof(IRazorPay), typeof(SRazorPay));
builder.Services.AddScoped(typeof(ISendEmail), typeof(SSendEmail));
builder.Services.AddScoped(typeof(SPdfService), typeof(SPdfService));
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.WebHost.UseUrls("http://0.0.0.0:" + (Environment.GetEnvironmentVariable("PORT") ?? "5000"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://sharmaved-001-site1.ktempurl.com") // Allow requests from this domain
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddCors();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
    x.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
