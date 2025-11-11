**Manual De Instalación**

Bienvenido al manual de instalación de la aplicación.

En este documento, encontrará una guía detallada y paso a paso para instalar correctamente la aplicación, desde la preparación del entorno hasta la puesta en marcha del sistema.

El desarrollo de este procedimiento se realiza considerando un equipo limpio, es decir, sin herramientas o dependencias previamente instaladas. Por ello, se recomienda seguir cada paso cuidadosamente para asegurar que la instalación se realice de manera correcta y sin inconvenientes.

## 1. Clonar el repositorio

Para obtener el código fuente del proyecto, abra una terminal y ejecute:

```bash
git clone https://github.com/JhonnFy/AngularNetAppi.git
```

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/f54cef06-9dbc-49a0-b42d-f1e7d5819ea0" />
  <br>
  <sub>Figura 1: Recomendado: usar **Git Bash** para los comandos de Git.</sub>
</p>


  

  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/efb3f320-42c8-4c99-9a24-1e49d9646629" />


2-Crear y poblar la base de datos.
En el repositorio consulte. D:\AngularNetAppi\db.sql En este enlace se le suministyra el script.

  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/0fd22e28-031f-447c-9f08-f899c1a0317c" />

  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/0134ac0a-e215-4bad-be02-8af27b9096f8" />

  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/07842ab7-af13-421c-856a-f44472fdcc4d" />


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


 <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/760a8032-b188-4ff9-af1b-716a47982b14" />

  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/74067adb-8543-4aa4-a072-ff86fe14dcd7" />













