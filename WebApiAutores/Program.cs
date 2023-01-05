using WebApiAutores;

var builder = WebApplication.CreateBuilder(args);

//instanciamos la clase StartUP

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);


var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
