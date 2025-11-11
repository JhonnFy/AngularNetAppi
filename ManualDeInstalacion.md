<h3>Bienvenido al manual de instalación de la aplicación</h3>

> En este documento encontrará una **guía detallada y paso a paso** para instalar correctamente la aplicación, desde la preparación del entorno hasta la puesta en marcha del sistema.

<h3>Stack tecnológico requerido</h3>

> Para que la aplicación funcione correctamente, se requiere contar con las siguientes herramientas instaladas:
SQL Server 2022 | Visual Studio 2022 | Node.js & npm | Angular CLI | Visual Studio Code | Git | Postman

<h6>Se recomienda seguir cada paso cuidadosamente para garantizar que la instalación se realice de manera correcta</h6>


<small>➤ [Clonar el repositorio]</small>

> Para obtener el código fuente del proyecto, abra una terminal y ejecute:

```bash
git clone https://github.com/JhonnFy/AngularNetAppi.git
```

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/f54cef06-9dbc-49a0-b42d-f1e7d5819ea0" />
  <br>
  <sub>Figura 1: Instrucción: Clone el repositorio utilizando el comando git clone.</sub>
</p>

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/260e4d23-0b49-4f4f-bfcc-98cbce2c9743" />
  <br>
  <sub>Figura 2: ✔️ `git clone` Completado con éxito.</sub>
</p>


<small>➤ [Crear la base de datos]</small>

> Para consultar el script de la base de datos, diríjase al repositorio y localice el siguiente archivo:
```bash
D:\AngularNetAppi\db.sql
```
<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/40c9002b-7efc-411e-b673-4605ae397d9b" />
  <br>
  <sub>Figura 3: Instrucción: Copie el script y ejecútelo en su motor de base de datos</sub>
</p>

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/b7255670-372f-4d71-85ca-218a3a679177" />
  <br>
  <sub>Figura 4: ✔️ Base de datos creada correctamente</sub>
</p>


<small>➤ [Poblar la tabla Estudiante]</small>
> Para consultar el script que contiene las sentencias INSERT, diríjase al repositorio y localice el siguiente archivo:
```bash
D:\AngularNetAppi\OrigenDatos\Generar Nombres\InsertInto\Estudiante.xlsx
```

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/9e7dcb16-3949-43e9-af01-13109c14111b" />
  <br>
  <sub>Figura 5: Instrucción: Copie el script [Estudiante] y ejecútelo en su motor de base de datos</sub>
</p>

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/258e84fd-f319-47c8-974d-5472a40db623" />
  <br>
  <sub>Figura 6: Instrucción: Copie el script [Sin FK] y ejecútelo en su motor de base de datos</sub>
</p>

> La hoja Estudiante permite la creación de registros que posteriormente serán asociados a la tabla Notas. Estos registros no podrán ser eliminados.

> La hoja Sin FK permite crear registros independientes, los cuales pueden eliminarse al no estar asociados a ninguna nota.


<small>➤ [Poblar la tabla Profesor]</small>
> Para consultar el script que contiene las sentencias INSERT, diríjase al repositorio y localice el siguiente archivo:
```bash
D:\AngularNetAppi\OrigenDatos\Generar Nombres\InsertInto\Profesor.xlsx
```

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/1d99c92b-abe6-47bb-8441-4c0ca9b9ca8b" />
  <br>
  <sub>Figura 7: Instrucción: Copie el script [Profesor] y ejecútelo en su motor de base de datos</sub>
</p>

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/120c8c6c-b6fc-4ace-aea5-adb0b40996f9" />
  <br>
  <sub>Figura 8: Instrucción: Copie el script [Sin FK] y ejecútelo en su motor de base de datos</sub>
</p>

> La hoja Profesor permite la creación de registros que posteriormente serán asociados a la tabla Notas. Estos registros no podrán ser eliminados.

> La hoja Sin FK permite crear registros independientes, los cuales pueden eliminarse al no estar asociados a ninguna nota.


<small>➤ [Poblar la tabla Notas]</small>
> Para consultar el script que contiene las sentencias INSERT, diríjase al repositorio y localice el siguiente archivo:
```bash
D:\AngularNetAppi\OrigenDatos\Generar Nombres\InsertInto\Nota.xlsx
```

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/92433a99-0828-406f-9540-1bd16c43273f" />
  <br>
  <sub>Figura 9: Instrucción: Copie el script y ejecútelo en su motor de base de datos</sub>
</p>

> Con estas acciones se da por concluido el proceso de configuración y carga de información en la base de datos.

<small>➤ [Backend: Preparar el entorno]</small>
> En este apartado del manual, le guiaremos en las pruebas del backend correspondientes a **consulta de rutas utilizando Postman**.

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/aa395218-575e-4e8f-821e-8fad02105746" />
  <br>
  <sub>Figura 10: Instrucción: Abrir la solución desde Visual Studio</sub>
</p>


<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/4f611fa7-75b3-4011-88d0-5b8a5133183c" />
  <br>
  <sub>Figura 11: Instrucción: Presione Ctrl + F5 para ejecutar la aplicación sin depuración.</sub>
</p>


<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/5dff234e-30bd-4d44-9741-664b73953031" />
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/6e90a96a-63a5-48ff-9a21-609c75d8684a" />
  <br>
  <sub>Figura 13: ✔️ Respuesta HTTP con los datos del Estudiante</sub>
</p>

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/9018bfed-d945-427a-ae8f-ce9ca6c1d235" />
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/7b2754b4-1157-4ce0-8374-bfd8f31be583" />
  <br>
  <sub>Figura 14: ✔️ Respuesta HTTP con los datos del Profesor</sub>
</p>

<p align="center">
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/3d5cf8cb-1d9e-4f1f-a32f-f7ce3db92d2f" />
  <img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/e44d841b-fbc7-43c8-ad21-c8fd1bc6aa17" />
  <br>
  <sub>Figura 15: ✔️ Respuesta HTTP con los datos de Notas</sub>
</p>

<small>➤ [Front: Preparar el entorno]</small>
> En este apartado del manual, le guiaremos en las pruebas del Front. 

<img width="1360" height="768" alt="image" src="https://github.com/user-attachments/assets/152b3e9d-5056-4ec0-b23a-37126a4be58a" />





