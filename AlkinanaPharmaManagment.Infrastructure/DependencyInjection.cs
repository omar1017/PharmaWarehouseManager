﻿using AlkinanaPharmaManagment.Application.Abstractions.Email;
using AlkinanaPharmaManagment.Application.Models.Email;
using AlkinanaPharmaManagment.Domain.Repositoryies;
using AlkinanaPharmaManagment.Infrastructure.Database;
using AlkinanaPharmaManagment.Infrastructure.EmailService;
using AlkinanaPharmaManagment.Infrastructure.Repositoryies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace AlkinanaPharmaManagment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddDatabase(configuration)
            //.AddAuthenticationInternal(configuration)
            .AddAuthorizationInternal()
            .AddEmailSetting(configuration);

    private static IServiceCollection AddEmailSetting(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        return services;
    }
    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Database");

       
        services.AddDbContext<ApplicationDbContext>(
            options => options
                    .UseSqlServer(connectionString));

        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }

    //private static IServiceCollection AddAuthenticationInternal(
    //    this IServiceCollection services,
    //    IConfiguration configuration)
    //{
    //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //        .AddJwtBearer(o =>
    //        {
    //            o.RequireHttpsMetadata = false;
    //            o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    //            {
    //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)),
    //                ValidIssuer = configuration["Jwt:Issuer"],
    //                ValidAudience = configuration["Jwt:Audience"],
    //                ClockSkew = TimeSpan.Zero
    //            };
    //        });

    //    services.AddHttpContextAccessor();
    //    return services;
    //}

    private static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();

        return services;
    }
}
