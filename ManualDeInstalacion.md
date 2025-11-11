# Bienvenido al manual de instalación de la aplicación

> En este documento encontrará una **guía detallada y paso a paso** para instalar correctamente la aplicación, desde la preparación del entorno hasta la puesta en marcha del sistema.

> Este procedimiento está pensado para un **equipo limpio**, es decir, sin herramientas o dependencias previamente instaladas. Por ello, se recomienda seguir cada paso cuidadosamente para garantizar que la instalación se realice de manera correcta y sin inconvenientes.


## Paso 1: [Clonar el repositorio]

> Para obtener el código fuente del proyecto, abra una terminal y ejecute:

```bash
git clone https://github.com/JhonnFy/AngularNetAppi.git
```

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/f54cef06-9dbc-49a0-b42d-f1e7d5819ea0" />
  <br>
  <sub>Figura 1: Instrucción:: usar git bash para los comandos de Git.</sub>
</p>

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/260e4d23-0b49-4f4f-bfcc-98cbce2c9743" />
  <br>
  <sub>Figura 2: ✔️ `git clone` Completado con éxito.</sub>
</p>

## Paso 2: [Crear la base de datos]
Para consultar el script de la base de datos, diríjase al repositorio y localice el siguiente archivo:
```bash
D:\AngularNetAppi\db.sql
```
<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/40c9002b-7efc-411e-b673-4605ae397d9b" />
  <br>
  <sub>Figura 3: Instrucción: Copie el script y ejecútelo en su motor de base de datos..</sub>
</p>

En este enlace se le proporcionará el script necesario para la configuración de la base de datos.


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



























