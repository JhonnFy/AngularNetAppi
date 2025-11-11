Bienvenido al manual de instalacion.

En este manual le guiaremos en el paso a paso para realizar la instalacion de la App

El desarrollo de este ejercicio se realizara en una unidad externa simulando un equipo que no tiene los medios instalados, le recomendamos seguir el paso a pasao para la correcta ejecucion.

1-clonar el repositorio: git --version  https://github.com/JhonnFy/AngularNetAppi.git

<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/f54cef06-9dbc-49a0-b42d-f1e7d5819ea0" />
</figure>

<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/efb3f320-42c8-4c99-9a24-1e49d9646629" />
</figure>


2-Crear y poblar la base de datos.
En el repositorio consulte. D:\AngularNetAppi\db.sql En este enlace se le suministyra el script.

<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/0fd22e28-031f-447c-9f08-f899c1a0317c" />
</figure>

<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/0134ac0a-e215-4bad-be02-8af27b9096f8" />
</figure>

<figure align="center">  
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/07842ab7-af13-421c-856a-f44472fdcc4d" />
</figure>


3-Poblar las tablas estudiante, profesor, nit.
Importante:
  Los registros fueron creados por un script en powershel no son datos reales.
  Si requiere consultar los .ps1, consultelos en las url: 
    D:\AngularNetAppi\OrigenDatos\Generar Nombres\GenerarCc.ps1
    D:\AngularNetAppi\OrigenDatos\Generar Nombres\GenerarNombres.ps1

Encontrara los insert a las tablas organizadas en archivos xlsx
 +Estudiante.xlsx
 +Profesor.xlsx
 +Notas.xlsx

 Para las tablas estidiante y profesor, se crea una hoja de onbre Sin FK, permite insertar registros que no se encuentran asociados
 a foreing key notas, y por tanto podran ser eliminados.

 En este apartado del manual le guiaremos en el proceso para insertar registros de la tabla estudiante, se recomienda seguir la secunecia de las imagenes:

<figure align="center">  
 <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/760a8032-b188-4ff9-af1b-716a47982b14" />
</figure>

<figure align="center">  
 <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/760a8032-b188-4ff9-af1b-716a47982b14" />
</figure>


