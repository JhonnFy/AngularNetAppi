# ===============================
# Script ultra-optimizado: 179,326 nombres Unicos
# Numerados, sin acentos, sin repeticiones
# Mezcla aleatoria mientras escribe
# ===============================

# Listas de nombres y apellidos sin acentos
$nombres = "Jhon", "Fredy", "Juan","Maria","Luis","Ana","Jose","Laura","Carlos","Camila","David","Gabriela","Miguel","Daniela","Andres","Isabella","Felipe","Valentina","Santiago","Natalia","Jorge","Mariana"
$apellidos = "Rincon", "Pelayo", "Ramirez","Herrera","Lopez","Gomez","Perez","Diaz","Martinez","Torres","Sanchez","Morales","Castro","Rojas","Vargas","Ortiz","Cano","Alvarez","Mendoza","Ruiz","Flores","Gutierrez"

# Carpeta de destino
$carpetaDestino = "C:\Developer\AngularNetAppi\OrigenDatos\Generar Nombres\NombresGenerados"
if (!(Test-Path -Path $carpetaDestino)) { New-Item -ItemType Directory -Path $carpetaDestino }

# Archivo de salida
$archivo = "$carpetaDestino\nombres_179326_rapido.txt"

# Crear hashset para asegurar unicidad sin almacenar millones de combinaciones
$nombresUnicos = @{}

$i = 1
while ($i -le 179326) {
    $nombreCompleto = "$($nombres | Get-Random) $($nombres | Get-Random) $($apellidos | Get-Random) $($apellidos | Get-Random)"
    
    # Verificar unicidad
    if (-not $nombresUnicos.ContainsKey($nombreCompleto)) {
        $nombresUnicos[$nombreCompleto] = $true
        $nombreCompleto | Out-File -FilePath $archivo -Append -Encoding UTF8
        $i++
    }
}

Write-Output "Archivo generado con 179,326 nombres �nicos aleatorizados y sin acentos en $archivo"
