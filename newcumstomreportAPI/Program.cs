using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IReportServiceConfiguration>(sp => new ReportServiceConfiguration
{
    ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
    HostAppId = "newcumstomreportAPI",
    Storage = new FileStorage(),
    ReportSourceResolver = new UriReportSourceResolver(
        Path.Combine(Environment.CurrentDirectory, "Reports"))
});
builder.Services.AddSingleton<IReportDesignerServiceConfiguration>(sp => new ReportDesignerServiceConfiguration
{
    DefinitionStorage = new FileDefinitionStorage(Path.Combine(Environment.CurrentDirectory, "Reports")),
    SettingsStorage = new FileSettingsStorage(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Telerik Reporting")),
    ResourceStorage = new ResourceStorage(Path.Combine(Environment.CurrentDirectory, "Resources"))
});

builder.Services.AddCors();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
//app.UseCors(MyAllowSpecificOrigins);
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
