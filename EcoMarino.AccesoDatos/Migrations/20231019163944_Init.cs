using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMarino.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoPeligro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuraciones",
                columns: table => new
                {
                    NombreAtributo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopeInferior = table.Column<int>(type: "int", nullable: false),
                    TopeSuperior = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuraciones", x => x.NombreAtributo);
                });

            migrationBuilder.CreateTable(
                name: "ControlCambios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreResponsable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEntidad = table.Column<int>(type: "int", nullable: false),
                    TipoEntidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCambios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosDeConservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosDeConservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    CodigoAlpha = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.CodigoAlpha);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassNormal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassEncriptada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoLong_Peso = table.Column<double>(type: "float", nullable: false),
                    PesoLong_Longitud = table.Column<double>(type: "float", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    NivelConservacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_EstadosDeConservacion_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "EstadosDeConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ecosistemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ubicacion_Latitud = table.Column<double>(type: "float", nullable: false),
                    Ubicacion_Longitud = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    CodigoAlpha = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    NivelConservacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadosDeConservacion_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "EstadosDeConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_Paises_CodigoAlpha",
                        column: x => x.CodigoAlpha,
                        principalTable: "Paises",
                        principalColumn: "CodigoAlpha",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspecieAmenaza",
                columns: table => new
                {
                    idEspecie = table.Column<int>(type: "int", nullable: false),
                    idAmenaza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieAmenaza", x => new { x.idEspecie, x.idAmenaza });
                    table.ForeignKey(
                        name: "FK_EspecieAmenaza_Amenazas_idAmenaza",
                        column: x => x.idAmenaza,
                        principalTable: "Amenazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecieAmenaza_Especies_idEspecie",
                        column: x => x.idEspecie,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspecieImagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEspecie = table.Column<int>(type: "int", nullable: false),
                    ruta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecieImagen", x => new { x.Id, x.IdEspecie });
                    table.ForeignKey(
                        name: "FK_EspecieImagen_Especies_IdEspecie",
                        column: x => x.IdEspecie,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaAmenaza",
                columns: table => new
                {
                    EcosistemaId = table.Column<int>(type: "int", nullable: false),
                    AmenazaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaAmenaza", x => new { x.EcosistemaId, x.AmenazaId });
                    table.ForeignKey(
                        name: "FK_EcosistemaAmenaza_Amenazas_AmenazaId",
                        column: x => x.AmenazaId,
                        principalTable: "Amenazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaAmenaza_Ecosistemas_EcosistemaId",
                        column: x => x.EcosistemaId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaEspecie",
                columns: table => new
                {
                    idEcosistema = table.Column<int>(type: "int", nullable: false),
                    idEspecie = table.Column<int>(type: "int", nullable: false),
                    LoHabita = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaEspecie", x => new { x.idEcosistema, x.idEspecie, x.LoHabita });
                    table.ForeignKey(
                        name: "FK_EcosistemaEspecie_Ecosistemas_idEcosistema",
                        column: x => x.idEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EcosistemaEspecie_Especies_idEspecie",
                        column: x => x.idEspecie,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaImagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEcosistema = table.Column<int>(type: "int", nullable: false),
                    ruta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaImagen", x => new { x.Id, x.IdEcosistema });
                    table.ForeignKey(
                        name: "FK_EcosistemaImagen_Ecosistemas_IdEcosistema",
                        column: x => x.IdEcosistema,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaAmenaza_AmenazaId",
                table: "EcosistemaAmenaza",
                column: "AmenazaId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaEspecie_idEspecie",
                table: "EcosistemaEspecie",
                column: "idEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaImagen_IdEcosistema",
                table: "EcosistemaImagen",
                column: "IdEcosistema");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_CodigoAlpha",
                table: "Ecosistemas",
                column: "CodigoAlpha");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_IdEstado",
                table: "Ecosistemas",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_Nombre",
                table: "Ecosistemas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EspecieAmenaza_idAmenaza",
                table: "EspecieAmenaza",
                column: "idAmenaza");

            migrationBuilder.CreateIndex(
                name: "IX_EspecieImagen_IdEspecie",
                table: "EspecieImagen",
                column: "IdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_IdEstado",
                table: "Especies",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre",
                table: "Paises",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Alias",
                table: "Usuarios",
                column: "Alias",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuraciones");

            migrationBuilder.DropTable(
                name: "ControlCambios");

            migrationBuilder.DropTable(
                name: "EcosistemaAmenaza");

            migrationBuilder.DropTable(
                name: "EcosistemaEspecie");

            migrationBuilder.DropTable(
                name: "EcosistemaImagen");

            migrationBuilder.DropTable(
                name: "EspecieAmenaza");

            migrationBuilder.DropTable(
                name: "EspecieImagen");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "EstadosDeConservacion");
        }
    }
}
