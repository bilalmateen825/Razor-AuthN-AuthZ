using Authentication_Authorization;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region Authentication

builder.Services.AddAuthentication(Constants.CookieSchemeName).
    AddCookie(Constants.CookieSchemeName, options =>
    {
        options.Cookie.Name = Constants.CookieSchemeName;
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromSeconds(30);
    });

#endregion

#region Authorization

builder.Services.AddAuthorization(authorizationOptions =>
{
    authorizationOptions.
    AddPolicy("MustBelongToAdministration"
    , policy =>
    {
        policy.RequireClaim("AdministrationUser", "Admin");
    });
});

builder.Services.AddAuthorization(authorizationOptions =>
{
    authorizationOptions.
    AddPolicy("MustBeAEmployee"
    , policy =>
    {
        // policy.RequireClaim("MustBeAEmployee", "true");
        policy.RequireClaim(Constants.EmployeeUserClaimName, "true");
        policy.AddRequirements(new EmployeeProbationRequirement(6));
    });
    
    authorizationOptions.AddPolicy("AdminAccess", policy =>
    {
        policy.RequireClaim(Constants.AdministrationUserClaimName);
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, EmployeeProbationRequirementHandler>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
