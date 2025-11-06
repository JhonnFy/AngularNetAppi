# API De Estudiantes

| Método HTTP | URL                                                                                    | Descripción                  | Body (si aplica)                                                |
| ----------- | -------------------------------------------------------------------------------------- | ---------------------------- | --------------------------------------------------------------- |
| GET         | [http://localhost:5261/api/estudiante](http://localhost:5261/api/estudiante)           | Listar todos los estudiantes | —                                                               |
| GET         | [http://localhost:5261/api/estudiante/9997](http://localhost:5261/api/estudiante/9997) | Obtener un estudiante por Id | —                                                               |
| POST        | [http://localhost:5261/api/estudiante](http://localhost:5261/api/estudiante)           | Crear un estudiante          | `{ "id": 9998, "Nombre" : JhonFy; }` |
| PUT         | [http://localhost:5261/api/estudiante/9997](http://localhost:5261/api/estudiante/9997) | Actualizar estudiante        | `json { "Nombre": "Juan", "Edad": 21, "Curso": "Fisica" }`      |
| DELETE      | [http://localhost:5261/api/estudiante/9997](http://localhost:5261/api/estudiante/9997) | Eliminar estudiante          | —                                                               |







