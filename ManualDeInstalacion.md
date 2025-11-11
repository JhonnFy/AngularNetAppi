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

2-Crear la DB

2.1 En el repositorio encontrara el script para crear la db
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/80e616f7-cceb-44c7-8322-4f56215501fc" />
</figure>

<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/dfd63726-e35b-456d-bb65-dbd551eea811" />
</figure>

2.2 Ejecute el script:
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/aa567876-11dc-41dd-a144-da0038c24aec" />
</figure>

2.3 Poblar la base de datos.
En el respositorio encontrara una 3 archivos con instrucciones insert, que le permitiran poblar las tablas. 
Consulte la url. D:\AngularNetAppi\OrigenDatos\Generar Nombres\InsertInto
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/d2ca0e86-97f1-470b-9ef7-ce97aca5ed8d" />
</figure>

2.4 Poblar la tabla Estudiante:
Importante :
1-Los nombres y cc de los registros fue genereado por script en powershell no son datos reales.
2-En el archivo Estudiantes encontrara dos hojas Estudiantes 'Registros que me permite poblar el id de notas', 
sin FK 'Registros que no tienen una Foreing key con notas y podran ser eliminados'. 

<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/4df56e9a-54f1-45a9-bd75-7d70d74a76cb" />
</figure>

Inciaremos poblando los registros que asociaremos a tabla notas, para ello copiar la columana G, de la hoja Estudiante

<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/9cb19323-bc37-42c6-9d71-d5e295b3a6a0" />
</figure>




