using FinalApp_ECommerce_BusinessLayer.Interfaces;
using FinalApp_ECommerce_BusinessLayer.Services;
using FinalApp_ECommerce_DataAccessLayer.Data;
using FinalApp_ECommerce_DataAccessLayer.Interfaces;
using FinalApp_ECommerce_DataAccessLayer.Models;
using FinalApp_ECommerce_DataAccessLayer.Repositories;
using FinalApp_ECommerce_DataAccessLayer.Seeds;
using FinalApp_ECommerce_WebAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Añadir Entity Framework Core al proyecto y configurar opciones de DbContext
builder.Services.AddDbContext<ECommerceDbContext>
    (
        options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
    );

//Añadir Identity al proyecto y configurar opciones de Identity
//Identity es un marco de trabajo de autenticación y autorización para aplicaciones web. Proporciona una forma de administrar usuarios, roles y permisos en una aplicación ASP.NET Core.
//IdentityCore: Agrega los servicios de identidad básicos a la aplicación. Esto incluye la configuración de opciones de identidad y la configuración de los servicios de almacenamiento de identidad.
//AddRoles: Agrega el servicio de roles a la aplicación. Esto permite administrar roles de usuario y asignar roles a los usuarios.
//AddRoleManager: Agrega el administrador de roles a la aplicación. Esto proporciona métodos para administrar roles de usuario, como crear, eliminar y buscar roles.
//AddSignInManager: Agrega el administrador de inicio de sesión a la aplicación. Esto proporciona métodos para iniciar y cerrar sesión en la aplicación.
//AddRoleValidator: Agrega el validador de roles a la aplicación. Esto permite personalizar la validación de roles de usuario.
//AddEntityFrameworkStores: Agrega el almacenamiento de identidad basado en Entity Framework a la aplicación. Esto permite almacenar usuarios, roles y otros datos de identidad en una base de datos.
builder.Services.AddIdentityCore<User>(
    options => 
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireDigit = false;
        options.SignIn.RequireConfirmedEmail = false;
    }
    )
    .AddRoles<IdentityRole<int>>()
    .AddRoleManager<RoleManager<IdentityRole<int>>>()
    .AddSignInManager<SignInManager<User>>()
    .AddRoleValidator<RoleValidator<IdentityRole<int>>>()
    .AddEntityFrameworkStores<ECommerceDbContext>();

//Registro de Servicios
//Inyección de dependencias
//3 tipos de inyección de dependencias
//1. Singleton: Se crea una única instancia del servicio durante toda la vida de la aplicación. Adecuado para servicios que deben mantener un estado global o que son costosos de crear.
//2. Scoped: Se crea una única instancia del servicio por cada solicitud HTTP. Útil para servicios que necesitan mantener datos consistentes durante una solicitud, pero no entre diferentes solicitudes.
//3. Transient: Se crea una nueva instancia del servicio cada vez que se solicita. Ideal para servicios ligeros y sin estado que no necesitan compartir datos entre solicitudes.

/*
Diferencias y Casos de Uso
Transient:
Diferencias: Cada solicitud obtiene una nueva instancia.
Casos de Uso: Servicios sin estado, como validadores o servicios de utilidad.
Scoped:
Diferencias: Una instancia por solicitud HTTP.
Casos de Uso: Servicios que manejan datos de usuario o transacciones que deben ser consistentes durante una solicitud.
Singleton:
Diferencias: Una única instancia para toda la aplicación.
Casos de Uso: Servicios que mantienen un estado global, como cachés en memoria o servicios de configuración.
*/

//Ejemplos de inyección de dependencias
//1. builder.Services.AddSingleton<ICategoryService, CategoryService>();
//2. builder.Services.AddScoped<ICategoryService, CategoryService>();
//3. builder.Services.AddTransient<ICategoryService, CategoryService>();

//Diferences formas de registro un servicio
//Usando interfaz y clase: Esta es la forma más común y recomendada, ya que promueve la separación de responsabilidades y facilita las pruebas unitarias.
//Ej: builder.Services.AddSingleton<ICategoryService, CategoryService>();
//Usando solo la clase: Puedes registrar una clase directamente sin una interfaz. Esto es útil para servicios simples o cuando no necesitas la flexibilidad de una interfaz.
//Ej: builder.Services.AddSingleton<CategoryService>();
//Usando una instancia específica: Puedes registrar una instancia específica de un servicio. Esto es útil cuando tienes una instancia preconfigurada que deseas reutilizar.
//Ej: builder.Services.AddSingleton<ICategoryService>(new CategoryService());
//Usando una fábrica (factory): Puedes registrar una fábrica que crea instancias de un servicio o usar una función lambda para crear la instancia del servicio. Esto es útil cuando necesitas configurar una instancia de servicio de forma dinámica o cuando la creación del servicio requiere lógica adicional.
//Ej: builder.Services.AddSingleton<ICategoryService>(serviceProvider => new CategoryService());

/*
Diferencias y Casos de Uso
Interfaz y Clase:
Diferencias: Promueve la abstracción y facilita las pruebas.
Casos de Uso: Servicios complejos, aplicaciones grandes, y cuando se espera cambiar la implementación en el futuro.
Solo Clase:
Diferencias: Más simple y directo, pero menos flexible.
Casos de Uso: Servicios simples, aplicaciones pequeñas, y cuando no se espera cambiar la implementación.
Instancia Específica:
Diferencias: Reutiliza una instancia preconfigurada.
Casos de Uso: Servicios que requieren configuración previa o que son costosos de crear.
Fábrica:
Diferencias: Permite lógica adicional en la creación del servicio.
Casos de Uso: Servicios que dependen de otros servicios o que requieren inicialización compleja.
*/

//Registro de servicios: Importante el orden
//Si un servicio se comunica con otro, el servicio que depende de otro debe registrarse después del servicio en el que depende.
//Ejemplo: ProductService depende de IProductRepository, por lo que IProductRepository debe registrarse antes que ProductService.
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    setup =>
    {
        setup.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerceApp", Version = "v1" });
        setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            Description = "Input your bearer token in this format - Bearer {your token} to access this API"
        });
        setup.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "Bearer",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new string[] {}
            }
        });
    }    
);

//JWT Configuration. AddAuthentication and AddJwtBearer
//AddAuthentication: Configura la autenticación para la aplicación. Esto incluye la configuración de esquemas de autenticación, como cookies, tokens JWT y otros esquemas personalizados.
//AddJwtBearer: Añade el esquema de autenticación JWT Bearer a la aplicación. Esto permite autenticar las solicitudes HTTP mediante tokens JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            //ValidAudience = builder.Configuration["Jwt:Audience"],
            //ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

//Luego del build, podemos hacer uso de los servicios registrados, como el context, para la carga de datos iniciales
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ECommerceDbContext>();
    //context.Database.EnsureCreated(); // This will create the database if it does not exist
    context.Database.Migrate(); // This will apply any pending migrations

    //Seed the database
    //Movemos las clases seed a un archivo separado, en el proyecto de DataAccessLayer
    SeedUsersAndRoles.Initialize(services);
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors(
    x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    //.WithOrigins("https://mybeautifullpage.com")
    .AllowAnyOrigin()
    //.SetIsOriginAllowed(origin => true)
);

app.UseHttpsRedirection();

//UseAuthentication y UseAuthorization
//UseAuthentication: Agrega el middleware de autenticación a la canalización de solicitudes. Esto permite autenticar las solicitudes HTTP mediante esquemas de autenticación configurados.
//UseAuthorization: Agrega el middleware de autorización a la canalización de solicitudes. Esto permite autorizar las solicitudes HTTP basadas en políticas de autorización configuradas.
//Es importante el orden en el que se agregan estos middlewares, ya que la autorización debe ocurrir después de la autenticación.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();