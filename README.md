# ProgramacionIV-UltimateFun
PASO A PASO PARA ACCEDER CORRECTAMENTE A LA APLICACION "UltimateFun"

Integrantes: Emilio Salazar, Domenica Rueda & Patricia Zurita



Una vez abierto la API y La aplicacion universal de windows deberá relizar lo siguiente:

  1. En el Explorador de soluciones dirigirse al archivo Package.appxmanifest y abrirlo
  2. Seleccionar "Empaquetado" del menú superior que se muestra en pantalla
  3.Seleccionar "Elegir certificado"
  4. Seleccionar el botón "Seleccionar de archivo" y elegir el archivo "UltimateFunUWP_TemporaryKey"
     el cual se debio descargar previamnete en el equipo(el archivo se encuentra adjuntado en la 
     carpeta de la entrega).
  5. Abrir el archivo y poner aceptar
  6. Dirigirse al menú superior de Visual estudio y dar clic en "Proyecto"
  7. Abrir "Propieedades de UltimateFun"
  8. Seleccionar "Firma"
  9. Activar el visto de "Firmar el esamblado"
  10. Elegir el archivo "UltimateFunUWP_TemporaryKey" nuevamente aunque ya se encuentre seleccionado.
  11. Recompilar solucion 
  12. Dirigirse al Explorador de soluciones  y dar un clic en el archivo "UltimateFunUWP_TemporaryKey"
  13. Verificar que el archivo ya NO contenga una "X"
  14. Dirigirse a la consola del administrador de paquetes
  15. Introducir la siguiente linea: Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
  16. Abrir los archivos dentro de la API y dirigirse al archivo Webconfig y dentro de el, cambiar el nombre
      del servidor (colocar el nombre se su servidor e instancia).

Abrir el Script de la aplicacion:
   
  1. Abrir el script de la base de datos de la aplicacion mediante el Microsoft SQL Server managmente studio y 
     ejecutarlo (el script se encuentra adjunto en la carpeta de la entrega del proyecto.)

Ejecutar soluciones:


 1. Ejecutar la API, dando clic derecho sobre la solucion, seleccionar Depurar y finalmente nueva instancia 
 2. Ejecutar la aplicacion UWP, dando clic derecho sobre la solucion, seleccionar Depurar y finalmente nueva instancia 
