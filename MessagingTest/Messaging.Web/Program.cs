using Messaging.Configuration;
using Messaging.Web.Listeners;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// config
var _config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
var messagingOptions = new MessagingOptions();
_config.GetSection(nameof(MessagingOptions)).Bind(messagingOptions);

builder.Services.AddMessaging("Test", options =>
{
    options.HostUrl = messagingOptions.HostUrl;
    options.Port = messagingOptions.Port;
    options.Username = messagingOptions.Username;
    options.Password = messagingOptions.Password;
    options.VHost = messagingOptions.VHost;
})
.AddConsumer<MessageListener>()
// .AddConsumer<MoreConsumer>()
// .AddConsumer<SomeMoreConsumer>()
.StartListening();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
