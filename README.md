PRUEBA TECNICA OPAIN


****************************************
* Requisitos para ejecutar el proyecto
***************************************
    .Net core 8.0
    Amgular 19
    Sql Server


1- Eejcutar los siguiente Scripts en Sql-Server
    
    create database OPAIN_DB;
    use OPAIN_DB;
    GO


    CREATE TABLE PRODUCTS(
    ID int primary key identity(1,1) not null,
    NAME NVARCHAR(100) NOT NULL,
    DESCRIPTION NVARCHAR(MAX) NULL,
    PRICE DECIMAL(18,2) NOT NULL,
    CREATEDAT DATETIME  NOT NULL
    );

2- Abrir OPAIN_PRUEBA.sln con Visual Studio 2022, que está en la carpeta (repositorio) OPAIN_PRUEBA
      
    OPAIN_PRUEBA
    |-OPAIN_PRUEBA.sln
    
3- Cuando se ha cargado la solución, se encontrará 2 proyectos generados por Angular y .net core.

    opain_prueba.client
    opain_prueba.Server

4- Verificar que  la solición que tenga varios proyectos de inicio ste habilitados y con el estado en inicio:
   
    clic derecho sobre la solición > propiedades > ConfigurarProyectos de inicio > Varios proyectos de inicio

5- Verificar la cadena de conexión en opain_prueba.Server, sea acorde al acceso de Sql-Server

    opain_prueba.Server > appsettings.json > "ConexionOPAIN": "Data Source=localhost;Initial Catalog=OPAIN_DB;Integrated Security=True;TrustServerCertificate=True"

6- Iniciar:
  
    1. Se inicia el navegador con las API en swagger.
    2. Se inicia el navegador con el Front  
    
  


