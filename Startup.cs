using Microsoft.OpenApi.Models;
using AdventOfCode.Controllers;
using AdventOfCode.Services;

namespace AdventOfCode
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdventOfCode", Version = "v1" });
                c.ParameterFilter<ParameterFilter>();  
            });

            services.AddScoped<ISolutionService, SolutionService>();
            services.AddScoped<ISolutionDayService, Solution2015_01Service>();
            services.AddScoped<ISolutionDayService, Solution2015_02Service>();
            services.AddScoped<ISolutionDayService, Solution2015_03Service>();
            services.AddScoped<ISolutionDayService, Solution2015_04Service>();
            services.AddScoped<ISolutionDayService, Solution2015_05Service>();
            services.AddScoped<ISolutionDayService, Solution2015_06Service>();
            services.AddScoped<ISolutionDayService, Solution2015_07Service>();
            services.AddScoped<ISolutionDayService, Solution2015_08Service>();
            services.AddScoped<ISolutionDayService, Solution2015_09Service>();
            services.AddScoped<ISolutionDayService, Solution2015_10Service>();
            services.AddScoped<ISolutionDayService, Solution2015_11Service>();
            services.AddScoped<ISolutionDayService, Solution2015_12Service>();
            services.AddScoped<ISolutionDayService, Solution2015_13Service>();
            services.AddScoped<ISolutionDayService, Solution2015_14Service>();
            services.AddScoped<ISolutionDayService, Solution2015_15Service>();
            services.AddScoped<ISolutionDayService, Solution2015_16Service>();
            services.AddScoped<ISolutionDayService, Solution2015_17Service>();
            services.AddScoped<ISolutionDayService, Solution2015_18Service>();
            services.AddScoped<ISolutionDayService, Solution2015_19Service>();
            services.AddScoped<ISolutionDayService, Solution2015_20Service>();
            services.AddScoped<ISolutionDayService, Solution2015_21Service>();
            services.AddScoped<ISolutionDayService, Solution2015_22Service>();
            services.AddScoped<ISolutionDayService, Solution2015_23Service>();
            services.AddScoped<ISolutionDayService, Solution2015_24Service>();
            services.AddScoped<ISolutionDayService, Solution2015_25Service>();
            services.AddScoped<ISolutionDayService, Solution2016_01Service>();
            services.AddScoped<ISolutionDayService, Solution2016_02Service>();
            services.AddScoped<ISolutionDayService, Solution2016_03Service>();
            services.AddScoped<ISolutionDayService, Solution2016_04Service>();
            services.AddScoped<ISolutionDayService, Solution2016_05Service>();
            services.AddScoped<ISolutionDayService, Solution2016_06Service>();
            services.AddScoped<ISolutionDayService, Solution2016_07Service>();
            services.AddScoped<ISolutionDayService, Solution2016_08Service>();
            services.AddScoped<ISolutionDayService, Solution2016_09Service>();
            services.AddScoped<ISolutionDayService, Solution2016_10Service>();
            services.AddScoped<ISolutionDayService, Solution2016_11Service>();
            services.AddScoped<ISolutionDayService, Solution2016_12Service>();
            services.AddScoped<ISolutionDayService, Solution2016_13Service>();
            services.AddScoped<ISolutionDayService, Solution2016_14Service>();
            services.AddScoped<ISolutionDayService, Solution2016_15Service>();
            services.AddScoped<ISolutionDayService, Solution2016_16Service>();
            services.AddScoped<ISolutionDayService, Solution2016_17Service>();
            services.AddScoped<ISolutionDayService, Solution2016_18Service>();
            services.AddScoped<ISolutionDayService, Solution2016_19Service>();
            services.AddScoped<ISolutionDayService, Solution2016_20Service>();
            services.AddScoped<ISolutionDayService, Solution2016_21Service>();
            services.AddScoped<ISolutionDayService, Solution2016_22Service>();
            services.AddScoped<ISolutionDayService, Solution2016_23Service>();
            services.AddScoped<ISolutionDayService, Solution2016_24Service>();
            services.AddScoped<ISolutionDayService, Solution2016_25Service>();
            services.AddScoped<ISolutionDayService, Solution2017_01Service>();
            services.AddScoped<ISolutionDayService, Solution2017_02Service>();
            services.AddScoped<ISolutionDayService, Solution2017_03Service>();
            services.AddScoped<ISolutionDayService, Solution2017_04Service>();
            services.AddScoped<ISolutionDayService, Solution2017_05Service>();
            services.AddScoped<ISolutionDayService, Solution2017_06Service>();
            services.AddScoped<ISolutionDayService, Solution2017_07Service>();
            services.AddScoped<ISolutionDayService, Solution2017_08Service>();
            services.AddScoped<ISolutionDayService, Solution2017_09Service>();
            services.AddScoped<ISolutionDayService, Solution2017_10Service>();
            services.AddScoped<ISolutionDayService, Solution2017_11Service>();
            services.AddScoped<ISolutionDayService, Solution2017_12Service>();
            services.AddScoped<ISolutionDayService, Solution2017_13Service>();
            services.AddScoped<ISolutionDayService, Solution2017_14Service>();
            services.AddScoped<ISolutionDayService, Solution2017_15Service>();
            services.AddScoped<ISolutionDayService, Solution2017_16Service>();
            services.AddScoped<ISolutionDayService, Solution2017_17Service>();
            services.AddScoped<ISolutionDayService, Solution2017_18Service>();
            services.AddScoped<ISolutionDayService, Solution2017_19Service>();
            services.AddScoped<ISolutionDayService, Solution2017_20Service>();
            services.AddScoped<ISolutionDayService, Solution2017_21Service>();
            services.AddScoped<ISolutionDayService, Solution2017_22Service>();
            services.AddScoped<ISolutionDayService, Solution2017_23Service>();
            services.AddScoped<ISolutionDayService, Solution2017_24Service>();
            services.AddScoped<ISolutionDayService, Solution2017_25Service>();
            services.AddScoped<ISolutionDayService, Solution2018_01Service>();
            services.AddScoped<ISolutionDayService, Solution2018_02Service>();
            services.AddScoped<ISolutionDayService, Solution2018_03Service>();
            services.AddScoped<ISolutionDayService, Solution2018_04Service>();
            services.AddScoped<ISolutionDayService, Solution2018_05Service>();
            services.AddScoped<ISolutionDayService, Solution2018_06Service>();
            services.AddScoped<ISolutionDayService, Solution2018_07Service>();
            services.AddScoped<ISolutionDayService, Solution2018_08Service>();
            services.AddScoped<ISolutionDayService, Solution2018_09Service>();
            services.AddScoped<ISolutionDayService, Solution2018_10Service>();
            services.AddScoped<ISolutionDayService, Solution2018_11Service>();
            services.AddScoped<ISolutionDayService, Solution2018_12Service>();
            services.AddScoped<ISolutionDayService, Solution2018_13Service>();
            services.AddScoped<ISolutionDayService, Solution2018_14Service>();
            services.AddScoped<ISolutionDayService, Solution2018_15Service>();
            services.AddScoped<ISolutionDayService, Solution2018_16Service>();
            services.AddScoped<ISolutionDayService, Solution2018_17Service>();
            services.AddScoped<ISolutionDayService, Solution2018_18Service>();
            services.AddScoped<ISolutionDayService, Solution2018_19Service>();
            services.AddScoped<ISolutionDayService, Solution2018_20Service>();
            services.AddScoped<ISolutionDayService, Solution2018_21Service>();
            services.AddScoped<ISolutionDayService, Solution2018_22Service>();
            services.AddScoped<ISolutionDayService, Solution2018_23Service>();
            services.AddScoped<ISolutionDayService, Solution2018_24Service>();
            services.AddScoped<ISolutionDayService, Solution2018_25Service>();
            services.AddScoped<ISolutionDayService, Solution2019_01Service>();
            services.AddScoped<ISolutionDayService, Solution2019_02Service>();
            services.AddScoped<ISolutionDayService, Solution2019_03Service>();
            services.AddScoped<ISolutionDayService, Solution2019_04Service>();
            services.AddScoped<ISolutionDayService, Solution2019_05Service>();
            services.AddScoped<ISolutionDayService, Solution2019_06Service>();
            services.AddScoped<ISolutionDayService, Solution2019_07Service>();
            services.AddScoped<ISolutionDayService, Solution2019_08Service>();
            services.AddScoped<ISolutionDayService, Solution2019_09Service>();
            services.AddScoped<ISolutionDayService, Solution2019_10Service>();
            services.AddScoped<ISolutionDayService, Solution2019_11Service>();
            services.AddScoped<ISolutionDayService, Solution2019_12Service>();
            services.AddScoped<ISolutionDayService, Solution2019_13Service>();
            services.AddScoped<ISolutionDayService, Solution2019_14Service>();
            services.AddScoped<ISolutionDayService, Solution2019_15Service>();
            services.AddScoped<ISolutionDayService, Solution2019_16Service>();
            services.AddScoped<ISolutionDayService, Solution2019_17Service>();
            services.AddScoped<ISolutionDayService, Solution2019_18Service>();
            services.AddScoped<ISolutionDayService, Solution2019_19Service>();
            services.AddScoped<ISolutionDayService, Solution2019_20Service>();
            services.AddScoped<ISolutionDayService, Solution2019_21Service>();
            services.AddScoped<ISolutionDayService, Solution2019_22Service>();
            services.AddScoped<ISolutionDayService, Solution2019_23Service>();
            services.AddScoped<ISolutionDayService, Solution2019_24Service>();
            services.AddScoped<ISolutionDayService, Solution2019_25Service>();
            services.AddScoped<ISolutionDayService, Solution2020_01Service>();
            services.AddScoped<ISolutionDayService, Solution2020_02Service>();
            services.AddScoped<ISolutionDayService, Solution2020_03Service>();
            services.AddScoped<ISolutionDayService, Solution2020_04Service>();
            services.AddScoped<ISolutionDayService, Solution2020_05Service>();
            services.AddScoped<ISolutionDayService, Solution2020_06Service>();
            services.AddScoped<ISolutionDayService, Solution2020_07Service>();
            services.AddScoped<ISolutionDayService, Solution2020_08Service>();
            services.AddScoped<ISolutionDayService, Solution2020_09Service>();
            services.AddScoped<ISolutionDayService, Solution2020_10Service>();
            services.AddScoped<ISolutionDayService, Solution2020_11Service>();
            services.AddScoped<ISolutionDayService, Solution2020_12Service>();
            services.AddScoped<ISolutionDayService, Solution2020_13Service>();
            services.AddScoped<ISolutionDayService, Solution2020_14Service>();
            services.AddScoped<ISolutionDayService, Solution2020_15Service>();
            services.AddScoped<ISolutionDayService, Solution2020_16Service>();
            services.AddScoped<ISolutionDayService, Solution2020_17Service>();
            services.AddScoped<ISolutionDayService, Solution2020_18Service>();
            services.AddScoped<ISolutionDayService, Solution2020_19Service>();
            services.AddScoped<ISolutionDayService, Solution2020_20Service>();
            services.AddScoped<ISolutionDayService, Solution2020_21Service>();
            services.AddScoped<ISolutionDayService, Solution2020_22Service>();
            services.AddScoped<ISolutionDayService, Solution2020_23Service>();
            services.AddScoped<ISolutionDayService, Solution2020_24Service>();
            services.AddScoped<ISolutionDayService, Solution2020_25Service>();
            services.AddScoped<ISolutionDayService, Solution2021_01Service>();
            services.AddScoped<ISolutionDayService, Solution2021_02Service>();
            services.AddScoped<ISolutionDayService, Solution2021_03Service>();
            services.AddScoped<ISolutionDayService, Solution2021_04Service>();
            services.AddScoped<ISolutionDayService, Solution2021_05Service>();
            services.AddScoped<ISolutionDayService, Solution2021_06Service>();
            services.AddScoped<ISolutionDayService, Solution2021_07Service>();
            services.AddScoped<ISolutionDayService, Solution2021_08Service>();
            services.AddScoped<ISolutionDayService, Solution2021_09Service>();
            services.AddScoped<ISolutionDayService, Solution2021_10Service>();
            services.AddScoped<ISolutionDayService, Solution2021_11Service>();
            services.AddScoped<ISolutionDayService, Solution2021_12Service>();
            services.AddScoped<ISolutionDayService, Solution2021_13Service>();
            services.AddScoped<ISolutionDayService, Solution2021_14Service>();
            services.AddScoped<ISolutionDayService, Solution2021_15Service>();
            services.AddScoped<ISolutionDayService, Solution2021_16Service>();
            services.AddScoped<ISolutionDayService, Solution2021_17Service>();
            services.AddScoped<ISolutionDayService, Solution2021_18Service>();
            services.AddScoped<ISolutionDayService, Solution2021_19Service>();
            services.AddScoped<ISolutionDayService, Solution2021_20Service>();
            services.AddScoped<ISolutionDayService, Solution2021_21Service>();
            services.AddScoped<ISolutionDayService, Solution2021_22Service>();
            services.AddScoped<ISolutionDayService, Solution2021_23Service>();
            services.AddScoped<ISolutionDayService, Solution2021_24Service>();
            services.AddScoped<ISolutionDayService, Solution2021_25Service>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdventOfCode"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
