# ===============================
# Script ultra-optimizado: 179,326 CC �nicos
# ===============================

# Carpeta de destino
$carpetaDestino = "C:\Developer\AngularNetAppi\OrigenDatos\Generar Nombres\NombresGenerados"
if (!(Test-Path -Path $carpetaDestino)) { New-Item -ItemType Directory -Path $carpetaDestino }

# Archivo de salida
$archivo = "$carpetaDestino\cc_179326.txt"

# Hashset para asegurar unicidad
$ccUnicos = @{}

$i = 1
while ($i -le 179326) {
    # Generar CC Unico: 8 a 10 digitos
    $cc = Get-Random -Minimum 1111 -Maximum 9999

    if (-not $ccUnicos.ContainsKey($cc)) {
        $ccUnicos[$cc] = $true
        $cc | Out-File -FilePath $archivo -Append -Encoding UTF8
        $i++
    }
}

Write-Output "Archivo generado con 179,326 CC �nicos en $archivo"
