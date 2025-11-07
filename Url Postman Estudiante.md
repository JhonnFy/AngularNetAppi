# API de Estudiantes

## EstudianteController

| Método HTTP | URL | Descripción | Body (si aplica) |
|------------|-----|------------|----------------|
| GET | `http://localhost:5261/api/estudiante` | Listar todos los estudiantes | — |
| GET | `[/api/estudiante/{id}](http://localhost:5261/api/estudiante/9997)` | Obtener un estudiante por Id {id}| — |
| POST | `/api/estudiante` | Crear un estudiante | `{ "Nombre": "Juan", "Edad": 20, "Curso": "Matematicas" }` |
| PUT | `/api/estudiante/{id}` | Actualizar estudiante | `{ "Nombre": "Juan", "Edad": 21, "Curso": "Fisica" }` |
| DELETE | `/api/estudiante/{id}` | Eliminar estudiante | — |


