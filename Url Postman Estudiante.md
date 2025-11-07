# API Estudiante

| Método HTTP | URL | Descripción | Body (si aplica) |
|------------|-----|------------|-----------------|
| GET | http://localhost:5261/api/estudiante | Listar todos los estudiantes | — |
| GET | http://localhost:5261/api/estudiante/{id} | Obtener un estudiante por Id | — |
| POST | http://localhost:5261/api/estudiante | Crear un estudiante | `{ "Nombre": "Juan" }` |
| PUT | http://localhost:5261/api/estudiante/{id} | Actualizar estudiante | `{ "Id": 1, "Nombre": "Juan Actualizado" }` |
| DELETE | http://localhost:5261/api/estudiante/{id} | Eliminar estudiante | — |





