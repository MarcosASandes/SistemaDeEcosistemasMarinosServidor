
using EcoMarino.AccesoDatos.EntityFramework.SQL;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.CasosDeUso;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApi.xml");
            builder.Services.AddSwaggerGen(opciones =>
            {

                opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Description = "Autorización estándar mediante esquema Bearer.",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                opciones.OperationFilter<SecurityRequirementsOperationFilter>();

                opciones.IncludeXmlComments(rutaArchivo);
                opciones.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MundoMarino",
                    Description = "Documentación con todos los endpoints de MundoMarino.Api",
                    Contact = new OpenApiContact
                    {
                        Email = "agustin0818sandes@gmail.com"
                    },
                    Version = "1.0"
                });
            });

            #region Repositorios SQL
            //INICIALIZACION DE REPOSITORIOS EN BASE DE DATOS
            builder.Services.AddScoped<IRepositorioAmenaza, AmenazaRepoSQL>();
            builder.Services.AddScoped<IRepositorioCambios, ControlCambiosRepoSQL>();
            builder.Services.AddScoped<IRepositorioEcosistema, EcosistemaRepoSQL>();
            builder.Services.AddScoped<IRepositorioEspecie, EspecieRepoSQL>();
            builder.Services.AddScoped<IRepositorioEstadoConservacion, EstadoConservacionRepoSQL>();
            builder.Services.AddScoped<IRepositorioPais, PaisRepoSQL>();
            builder.Services.AddScoped<IRepositorioUsuario, UsuarioRepoSQL>();
            builder.Services.AddScoped<IRepositorioConfiguracion, ConfiguracionRepoSQL>();
            #endregion

            #region Casos de uso
            //CASOS DE USO
            //Ecosistema
            builder.Services.AddScoped<IAddEcosistemaCU, AddEcosistemaCU>();
            builder.Services.AddScoped<IGetEcosistemasCU, GetEcosistemasCU>();
            builder.Services.AddScoped<IGetEcosistemasInadecuadosCU, GetEcosistemasInadecuadosCU>();
            builder.Services.AddScoped<IGetEcosistemaPorIdCU, GetEcosistemaPorIdCU>();
            builder.Services.AddScoped<IAsociarAmenazaEcosistemaCU, AsociarAmenazaEcosistemaCU>();
            builder.Services.AddScoped<IGetEspeciesSegunEcosistemaCU, GetEspeciesSegunEcosistemaCU>();
            builder.Services.AddScoped<IEditEcosistemaCU, EditEcosistemaCU>();
            builder.Services.AddScoped<IRemoveEcosistemaCU, RemoveEcosistemaCU>();
            builder.Services.AddScoped<ICambiarNombreImagenEcoCU, CambiarNombreImagenEcoCU>();
            builder.Services.AddScoped<IGetTodasLasImagenesPorEcoCU, GetTodasLasImagenesPorEcoCU>();
            builder.Services.AddScoped<IGetPrimerImagenEcoCU, GetPrimerImagenEcoCU>();

            //Especie
            builder.Services.AddScoped<IAddEspecieCU, AddEspecieCU>();
            builder.Services.AddScoped<IAsociarEspecieCU, AsociarEspecieCU>();
            builder.Services.AddScoped<IGetEspeciePorNomCU, GetEspeciePorNomCU>();
            builder.Services.AddScoped<IGetEspeciesDeEcosistemasCU, GetEspeciesDeEcosistemasCU>();
            builder.Services.AddScoped<IGetEspeciesEnPeligroCU, GetEspeciesEnPeligroCU>();
            builder.Services.AddScoped<IGetEspeciesPorPesoCU, GetEspeciesPorPesoCU>();
            builder.Services.AddScoped<IGetTodasLasEspeciesCU, GetTodasLasEspeciesCU>();
            builder.Services.AddScoped<IGetEspeciePorIdCU, GetEspeciePorIdCU>();
            builder.Services.AddScoped<IAsociarAmenazaEspecieCU, AsociarAmenazaEspecieCU>();
            builder.Services.AddScoped<IGetEspeciesPorPesoYNombreCU, GetEspeciesPorPesoYNombreCU>();
            builder.Services.AddScoped<IGetEcosistemasSegunEspecieCU, GetEcosistemasSegunEspecieCU>();
            builder.Services.AddScoped<IAddEcoHabitableCU, AddEcoHabitableCU>();
            builder.Services.AddScoped<IGetEcosistemasHabitablesCU, GetEcosistemasHabitablesCU>();
            builder.Services.AddScoped<ICambiarNombreImagenEspecieCU, CambiarNombreImagenEspecieCU>();
            builder.Services.AddScoped<IGetTodasLasImagenesPorEspCU, GetTodasLasImagenesPorEspCU>();
            builder.Services.AddScoped<IGetPrimerImagenEspCU, GetPrimerImagenEspCU>();
            builder.Services.AddScoped<IEditEspecieCU, EditEspecieCU>();
            builder.Services.AddScoped<IGetEspeciesEnPeligroCU, GetEspeciesEnPeligroCU>();
            builder.Services.AddScoped<IGetEcosistemasInadecuadosCU, GetEcosistemasInadecuadosCU>();

            //Usuario
            builder.Services.AddScoped<ILoginUserCU, LoginUserCU>();
            builder.Services.AddScoped<IRegistroUserCU, RegistroUserCU>();
            builder.Services.AddScoped<IObtenerUserPorAliasCU, ObtenerUserPorAliasCU>();

            //Paises
            builder.Services.AddScoped<IGetPaisesCU, GetPaisesCU>();
            builder.Services.AddScoped<IGetPaisPorIdCU, GetPaisPorIdCU>();
            builder.Services.AddScoped<IAddPaisCU, AddPaisCU>();

            //Estado de conservacion
            builder.Services.AddScoped<IGetEstadoConservacionPorNivelCU, GetEstadoConservacionPorNivelCU>();
            builder.Services.AddScoped<IGetEstadoPorIdCU, GetEstadoPorIdCU>();

            //Amenazas
            builder.Services.AddScoped<IGetAllAmenazasCU, GetAllAmenazasCU>();
            builder.Services.AddScoped<IGetAmenazaPorIdCU, GetAmenazaPorIdCU>();
            builder.Services.AddScoped<IGetAmenazasSegunEcosistemaCU, GetAmenazasSegunEcosistemaCU>();
            builder.Services.AddScoped<IGetAmenazasSegunEspecieCU, GetAmenazasSegunEspecieCU>();

            //ControlCambios
            builder.Services.AddScoped<IAddControlCambioCU, AddControlCambioCU>();
            builder.Services.AddScoped<IGetTodosLosCambiosCU, GetTodosLosCambiosCU>();

            //Configuracion
            builder.Services.AddScoped<IGetConfiguracionesCU, GetConfiguracionesCU>();
            builder.Services.AddScoped<IEditConfiguracionCU, EditConfiguracionCU>();
            builder.Services.AddScoped<IGetConfiguracionPorNombreCU, GetConfiguracionPorNombreCU>();
            #endregion
           

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });

            builder.Services.AddCors(opciones =>
            {
                opciones.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            builder.Services.AddAuthorization(opt =>
            {
                opt.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowOrigin");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }       
    }

}