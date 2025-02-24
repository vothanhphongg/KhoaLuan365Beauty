var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxyCommand"))
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxyQuery")); ;
var app = builder.Build();

app.UseHttpsRedirection();
app.UseForwardedHeaders();
app.UseAuthorization();
app.MapReverseProxy();
app.Run();
