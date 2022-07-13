
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json.Converters;
using System.Configuration;
using PhoneCatalog.Services;


  
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
            }); ;
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

       


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        