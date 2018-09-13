using Itau.SE4.CrossCulting;
using Itau.SE4.Log;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Itau.SE4.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddAuthentication(sharedOptions =>
            //{
            //    sharedOptions.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    sharedOptions.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //})
            //.AddCookie()
            //.AddOpenIdConnect(options =>
            //{
            //    options.ClientId = "{clientId}";
            //    options.ClientSecret = "{clientSecret}";
            //    options.Authority = "https://dev-791533.oktapreview.com/oauth2/default";
            //    options.CallbackPath = "/authorization-code/callback";
            //    options.ResponseType = "code";
            //    options.SaveTokens = true;
            //    options.UseTokenLifetime = false;
            //    options.GetClaimsFromUserInfoEndpoint = true;
            //    options.Scope.Add("openid");
            //    options.Scope.Add("profile");
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        NameClaimType = "name"
            //    };
            //});

            Boostraper.Configure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
                            , IHostingEnvironment env
                            , ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Debug
            }));

            app.UseMvc();

            //app.UseAuthentication();
        }
    }
}
