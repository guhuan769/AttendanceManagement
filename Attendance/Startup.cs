using Attendance.core.Common;
using Attendance.core.Common.Redis;
using Attendance.Repository.suger;
using Attendance.SetUp;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendance
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
            //���ݿ�����
            BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;

            //ע��Redis
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();

            //ע��AppSettings ��ȡ��
            services.AddSingleton(new AppSettings(Configuration));
            
            #region ����AppSettings�Ƿ�ע��ɹ�
#if false 
            var text = AppSettings.app(new string[] { "AppSettings", "ConnectionString" });
            Console.WriteLine($"ConnectionString:{text}");
            Console.ReadLine(); 
#endif 
            #endregion
            //ע��Swagger
            services.AddSwaggerSetup();
            //jwt��Ȩ��֤
            services.AddAuthorizationSetup();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                //�쳣��Ϣ��ʾҳ��
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", "WebApi.Core V1");

                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger
                //�Ƿ��ʲ����ģ�ȥlaunchSettings.json
                //��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });

            //app.UseHttpsRedirection();

            //ע���м����˳��UseRouting������ǰ�ߣ�UseAuthentication��UseAuthorizationǰ��
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }

        /// <summary>
        /// ��������Autofac ��������
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModuleRegister());
        }
    }
}
