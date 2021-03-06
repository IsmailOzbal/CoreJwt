﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core2_2ApiJwt.BO;
using Core2_2ApiJwt.Context.DbOperation;
using Core2_2ApiJwt.Context.UnitOfWork;
using Core2_2ApiJwt.Helpers;
using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Core2_2ApiJwt
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<DatabaseContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IToken,GetTokenAndAuthentication>();
            services.AddScoped<IGetUser, GetAllUser>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGetChart, GetChartData>();
            services.AddScoped<ISolveExam, GetSolvedExamList>();
            services.AddScoped<IExamScore, GetChartExamScore>();
            services.AddScoped<IAddExam, AddExamScore>();
            services.AddScoped<IQuestions, GetQuestions>();
            services.AddScoped<IAddUser, AddUser>();
            services.AddScoped<IPassword, ChangePassword>();
            services.AddScoped<IGetWord, GetAllWords>();
            services.AddScoped<IAddWord, AddWord>();
            services.AddScoped<IDeleteWord,DeleteWord>();
            services.AddScoped<IUpdateWord, UpdateWord>();
            services.AddScoped<IAddWordDescription, AddWordDescription>();
            services.AddScoped<IWordDetailView, GetWordDetailView>();
            services.AddScoped<IWordDetailViewById, GetWordDetailViewById>();
            services.AddScoped<IAddSentence, AddSentence>();
            services.AddScoped<IWordType, GetWordType>();
            services.AddScoped<IAddWordType, AddWordType>();
            services.AddScoped<ILanguauge, GetAllLanguage>();
            services.AddScoped<IGetNotCompleteWord,GetNotCompleteWord>();
            services.AddScoped<IGetWordLevel, GetWordLevel>();
            services.AddScoped<IGetChartWordLevel, GetChartWordLevel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
