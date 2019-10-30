# biblioteca
Este Proyecto es una Biblioteca, toda la parte del backend esta construida bajo netcore version 2.2, se desarrollo con visual studio community 
2019.

# Componentes
modelo de base de datos generado atravez de codefirst.
Swagger UI  -- Swashbuckle.AspNetCore 4.0.1
EntityFrameworkCore  --  Microsoft.EntityFrameworkCore 2.2.4
EntityFrameworkCore.SqlServer -- Microsoft.EntityFrameworkCore.SqlServer 2.2.4
log4net 2.0.8

# Que se encesita para que funcione

Tener instalado en framework o sdk para netcore version 2.2 - 2.4 - 2.6, lo puedes descargar ingresado al siguiente link:
https://dotnet.microsoft.com/download/dotnet-core/2.2

Una vez comprobado o instalado el framework procederemos con el siguiente paso.

Modificar la cadena de conexion ubicada en el appsettings.json de nuestra aplicacion.

Una vez descargado el proyecto , procederemos abrirlo en visual studio community, en mi caso tengo instalado el 2019.
Necesitamos compilarlo para que nos restaure los paquetes y podamos correr nuestro proyecto y no genere errores.

# Migraciones package nuget
Abrimos nuestra consola de administracion de paquetes, que esta ubicada en la parte inferior de nuestro proyecto visual studio.
o lo podemos encontrar en Herramientas -> Administrador de paquetes Nuget -> Consola del administrador de paquetes.

Vamos a generar nuestra base de datos, en mi caso no tengo que correr el add-migration BibliotecaCreate porque ya se encuentra en este proyecto.

como ya el modelo de migracion existe, solamente debemos agregar el siguiente comando.

Update-database

Aca te dejare unos ejemplos de como generarlo desde cero.

add-migration <migration name>	Add <migration name>	Creates a migration by adding a migration snapshot.
Remove-migration	Remove	Removes the last migration snapshot.
Update-database	Update	Updates the database schema based on the last migration snapshot.
Script-migration	Script	Generates a SQL script using all the migration snapshots.

Eso es todo amigos.

Gracias.
