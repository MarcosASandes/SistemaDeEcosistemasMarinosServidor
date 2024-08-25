using EcoMarino.AccesoDatos.EntityFramework.SQL;
using EcoMarino.AccesoDatos.InMemory;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.CasosDeUso;
using EcoMarino.LogicaAplicacion.InterfacesCU;

namespace IUWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



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

            #region Repositorios Memoria
            //INICIALIZACION DE REPOSITORIOS EN MEMORIA
            //builder.Services.AddScoped<IRepositorioAmenaza, AmenazaRepoMemoria>();
            //builder.Services.AddScoped<IRepositorioCambios, ControlCambiosRepoMemoria>();
            //builder.Services.AddScoped<IRepositorioEcosistema, EcosistemaRepoMemoria>();
            //builder.Services.AddScoped<IRepositorioEspecie, EspecieRepoMemoria>();
            //builder.Services.AddScoped<IRepositorioEstadoConservacion, EstadoConservacionRepoMemoria>();
            //builder.Services.AddScoped<IRepositorioPais, PaisRepoMemoria>();
            //builder.Services.AddScoped<IRepositorioUsuario, UsuarioRepoMemoria>();
            //builder.Services.AddScoped<IRepositorioConfiguracion, ConfigRepoMemoria>();
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
            builder.Services.AddScoped<IGetEspeciesEnPeligroCU,  GetEspeciesEnPeligroCU>();
            builder.Services.AddScoped<IGetEcosistemasInadecuadosCU, GetEcosistemasInadecuadosCU>();

            //Usuario
            builder.Services.AddScoped<ILoginUserCU, LoginUserCU>();
            builder.Services.AddScoped<IRegistroUserCU, RegistroUserCU>();

            //Paises
            builder.Services.AddScoped<IGetPaisesCU, GetPaisesCU>();
            builder.Services.AddScoped<IGetPaisPorIdCU, GetPaisPorIdCU>();

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

            builder.Services.AddSession();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}