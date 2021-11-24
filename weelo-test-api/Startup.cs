using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ServiceGrpcTest.Services;
using Services.Interfaces;
using System;
using UnitOfWork.Interfaces;
using UnitOfWork.SqlServer;

namespace weelo_test_api
{
    public class Startup
    {

        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string front_url = _configuration.GetValue<string>("AppSettings:FrontUrl");

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(front_url).AllowAnyHeader()
                                                  .AllowAnyMethod();
                });
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddTransient<IUnitOfWork, UnitOfWorkSqlServer>();
            services.AddScoped<IOwnerService, OwnerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(x => x.MapControllers());

        }
    }
}
