# TechTest

Project that manage tasks and users

1.Como primer paso se deben ejecutar los comando de base datos que se encuentran en la carpeta BD. Ya estan numerados y deben ser ejecutados en orden ascendente (desde el 1 hasta el 4)
NOTA: Para mi caso especifico cree un nuevo usuario y tambien un nuevo esquema.
Adjunto ejemplos de consumo de los sp:

CALL `enterprise`.`sp_consultar_tareas`(<{IN p_usuario_id INT}>, <{IN p_estado VARCHAR(20)}>, <{IN p_ordenado BOOLEAN}>, <{IN p_meta_key VARCHAR(100)}>, <{-- Nombre de la clave dentro del JSON
    IN p_meta_value VARCHAR(255)  -- Valor esperado para esa clave}>);
CALL `enterprise`.`sp_consultar_tareas`(null, null, null, 'jefe', '1');

CALL `enterprise`.`sp_actualizar_metadata_tarea`(<{IN p_tarea_id INT}>, <{IN p_meta_key VARCHAR(100)}>, <{IN p_meta_value VARCHAR(255)}>);
CALL `enterprise`.`sp_actualizar_metadata_tarea`(1, 'canal', 'baja');

El procedimiento de actualizar metadata también permite la inserción de nuevas etiquetas, es decir, si existe solo "prioridad" y se llama al procedimiento con la etiqueta "horario" este añadirá esta nueva propiedad.

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
