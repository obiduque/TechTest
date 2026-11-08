# TechTest

Project that manage tasks and users

1.Como primer paso se deben ejecutar los comando de base datos que se encuentran en la carpeta BD. Ya estan numerados y deben ser ejecutados en orden ascendente (desde el 1 hasta el 4)
NOTA: Para mi caso especifico cree un nuevo usuario y tambien un nuevo esquema.

2.En la carpeta Back, se encuentra la lógica referente al procesamiento de datos. Es importante setear los datos de la cadena de conexion que se encuentra definida en el archivo launchsettings.json dentro de la carpeta Properties
"Server=localhost;Port=3306;Database=enterprise;Uid=techtest;Pwd=TechTest;"
Recordar construir primero el proyecto "dotnet restore" antes de ejecutar para que todas las librerías sean instaladas y posteriromente compilar el proyecto con el comando "dotnet build"

3.Segun corresponda, se debe cambiar en la carpeta Front el archivo enviroments/environment.ts por la url correspondiente antes de construir el proyecto para de ese modo garantizar la comunicación con el backend:
apiUrl: "http://localhost:5248/api"

Importante recordar que para correr la aplicación en "local" se debe ejecutar los siguientes comandos: 
"npm install" para descargar todas las librerías necesarias
"ng serve" para correr el programa

COMENTARIOS:
- Estas instrucciones son hechas pensando en una prueba "local" en el equipo de un desarrollador o evaluador.
- Dentro de los scripts de base datos, se encuentra los sp_consultar_tareas y sp_actualizar_metadata_tarea, ambas funcionalidades dinamicas como requerimientos adicionales de manejo de datos.
- Como un extra y buenas practicas de desarrollo anexo al proyecto pruebas unitarias para el backend.
