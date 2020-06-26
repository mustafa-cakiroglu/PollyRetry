using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace CircuitBreaker.Weather.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IAsyncPolicy<HttpResponseMessage> retryPolicy =
                   Policy
                   .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                   //.OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                   .RetryAsync(3);

            services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(retryPolicy);

            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:6001/")
            };
            services.AddSingleton<HttpClient>(httpClient);

            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
