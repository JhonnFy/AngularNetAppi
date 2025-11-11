# Bienvenido al manual de instalación de la aplicación

> En este documento encontrará una **guía detallada y paso a paso** para instalar correctamente la aplicación, desde la preparación del entorno hasta la puesta en marcha del sistema.

Se recomienda seguir cada paso cuidadosamente para garantizar que la instalación se realice de manera correcta y sin inconvenientes.

## Stack tecnológico requerido
Para que la aplicación funcione correctamente, se requiere contar con las siguientes herramientas recomendadas:

> 💾 SQL Server 2022  |  🖥️ Visual Studio 2022  |  ⚡ Node.js & npm  |  🅰️ Angular CLI  |  📝 VS Code  |  🔧 Git  |  📬 Postman


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

> La hoja Estudiante permite la creación de registros que posteriormente serán asociados a la tabla Notas. Estos registros no podrán ser eliminados.

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


















