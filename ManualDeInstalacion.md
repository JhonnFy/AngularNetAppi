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

3 Poblar la base de datos.
En el respositorio encontrara una 3 archivos con instrucciones insert, que le permitiran poblar las tablas. 
Consulte la url. D:\AngularNetAppi\OrigenDatos\Generar Nombres\InsertInto
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/d2ca0e86-97f1-470b-9ef7-ce97aca5ed8d" />
</figure>

3.1 Poblar la tabla Estudiante:
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

3.2 Insert Los registros en la db
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/ef7b7827-723c-4483-9b79-b9aa0b28e62e" />
</figure>

3.3 Ejecutar el insert
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/e9c49a3c-3013-4d24-bcc4-2a1354e5fce7" />
</figure>

3.4 En el mismo archivo, consulte la hoja SinFk:
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/5a832c3f-acd3-4c23-8fc4-ffdeabed970d" />
</figure>

3.5 Trasladar los registros al motor de base de datos:
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/60d201b6-231f-41db-ae58-4f1a726bf22b" />
</figure>

3.6 Ejecutar el insert:
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/b8888f74-314f-448c-be7c-78b32764006e" />
</figure>

4-Poblar la tabla Profesor
Consulte el archivo Profesor, en el repo la direccion es: D:\AngularNetAppi\OrigenDatos\Generar Nombres\InsertInto\Profesor.xlsx

En este apartado del manual leguiaremos en el insert, seleccione la columna G
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/2a51096c-b622-4bd7-b94e-97bc1f1a2338" />
</figure>

Trasladar los registros al motor de base de datos:
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/31204de4-83e7-4b03-bad0-fc80f41ad9ea" />
</figure>

Ejecutar el insert
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/0a226a9a-4482-4aee-83a1-87c046167ef5" />
</figure>

Seleccionar la hoja Si FK
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/4508e5bd-c3b5-4ea2-8e3a-fbb109dbc8cc" />
</figure>

Trasladar los registros al motor de base de datos:
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/b7003995-2458-4d5e-9e7c-35452b5a9cdd" />
</figure>

Ejecutar el insert
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/878daa15-a360-4d46-85b8-00621be05b83" />
</figure>

5-Poblar la tabla nota:
Consulte el archivo Profesor, en el repo la direccion es: D:\AngularNetAppi\OrigenDatos\Generar Nombres\InsertInto\Nota.xlsx

En este apartado del manual leguiaremos en el insert, seleccione la columna J
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/608740c0-6ebf-4986-9255-5a6846da2275" />
</figure>

Trasladar los registros al motor de base de datos:
<figure align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/fd841640-8803-4f25-9395-b0ee405e60ab" />
</figure>

Ejecutar el insert
<figure align="center">
  
</figure>


