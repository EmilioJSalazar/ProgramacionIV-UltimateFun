# ProgramacionIV-UltimateFun
PASO A PASO PARA ACCEDER CORRECTAMENTE A LA APLICACION "UltimateFun"

Integrantes: Emilio Salazar, Domenica Rueda & Patricia Zurita

Clonar el proyecto 

  1. Copiar el link de github que corresponde al proyecto (https://github.com/EmilioJSalazar/ProgramacionIV-UltimateFun)
  2. Abrir Visual Studio
  3. Seleccionar "Clonar repositorio"



  ![image](https://user-images.githubusercontent.com/62667937/147863026-6921142e-c050-4830-9c50-51ba600dd50a.png)
  
  4. Pegar el link


  
  ![image](https://user-images.githubusercontent.com/62667937/147863050-5d1cbb4d-9021-472d-a093-e9fbd38472ed.png)
  
  5. Seleccionar "Clonar"

  ![image](https://user-images.githubusercontent.com/62667937/147863054-91a71418-c23c-4198-9b80-803400f6ee95.png)


Para abrir el proyecto deberá copiar el link de github para poder clonar el mismo


Una vez abierto la API y La aplicacion universal de windows deberá relizar lo siguiente:

  1. En el Explorador de soluciones dirigirse al archivo Package.appxmanifest y abrirlo
  
  ![image](https://user-images.githubusercontent.com/62667937/147863086-fa544799-d67c-4e5c-b517-d3f1a673a7b1.png)

  
  2. Seleccionar "Empaquetado" del menú superior que se muestra en pantalla
  
  ![image](https://user-images.githubusercontent.com/62667937/147863098-7dd00dd4-36e9-4a67-acaa-5531ab86659e.png)

  
  3.Seleccionar "Elegir certificado"
  
  ![image](https://user-images.githubusercontent.com/62667937/147863122-2822a653-8237-4910-8fb1-20cc08033aec.png)

  
  4. Seleccionar el botón "Seleccionar de archivo" y elegir el archivo "UltimateFunUWP_TemporaryKey"
     el cual se debio descargar previamnete en el equipo(el archivo se encuentra adjuntado en la 
     carpeta de la entrega).
     
     ![image](https://user-images.githubusercontent.com/62667937/147863126-e686629d-ed2b-4e4b-b3c4-35b40f45cb1a.png)
     ![image](https://user-images.githubusercontent.com/62667937/147863128-bcc7a6c6-b13d-4277-8fde-31cb9fe1197a.png)

     
  5. Abrir el archivo y poner aceptar
  
  ![image](https://user-images.githubusercontent.com/62667937/147863131-5177dea2-0117-464f-8fc2-791af0b74473.png)

  
  6. Dirigirse al menú superior de Visual estudio y dar clic en "Proyecto"
  
  ![image](https://user-images.githubusercontent.com/62667937/147863145-fe5b632d-edfd-4153-8d29-530905e43d6b.png)

  
  7. Abrir "Propieedades de UltimateFun"
  
  ![image](https://user-images.githubusercontent.com/62667937/147863180-96e33bf8-1cc5-4cb7-9fb0-50a98d457724.png)

  
  8. Seleccionar "Firma"
  
  ![image](https://user-images.githubusercontent.com/62667937/147863197-51cbe1de-bf95-4191-92a5-089d01077fdd.png)

  
  9. Activar el visto de "Firmar el esamblado"
  
  ![image](https://user-images.githubusercontent.com/62667937/147863199-8489c780-f745-4b9b-a01b-3abe12c91576.png)

  
  10. Elegir el archivo "UltimateFunUWP_TemporaryKey" nuevamente aunque ya se encuentre seleccionado.
  11. Recompilar solucion 
  12. Dirigirse al Explorador de soluciones  y dar un clic en el archivo "UltimateFunUWP_TemporaryKey"
  13. Verificar que el archivo ya NO contenga una "X"
  
  ![image](https://user-images.githubusercontent.com/62667937/147863213-9e24bcb1-60a0-4d02-8336-d7afac42fdff.png)

  
  14. Dirigirse a la consola del administrador de paquetes
  
  ![image](https://user-images.githubusercontent.com/62667937/147863232-f6de5746-80d6-47a1-9a54-57cbfd8995f7.png)

  
  15. Introducir la siguiente linea: Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
  
  ![image](https://user-images.githubusercontent.com/62667937/147891985-bf61b768-2aa7-49b1-8365-14a3caf52f59.png)

  
  16. Abrir los archivos dentro de la API y dirigirse al archivo Webconfig y dentro de el, cambiar el nombre
      del servidor (colocar el nombre se su servidor e instancia).
      
  ![image](https://user-images.githubusercontent.com/62667937/147863251-05714edc-5792-4447-b064-bd8803c02de3.png)
  ![image](https://user-images.githubusercontent.com/62667937/147863255-f16e465e-3c01-41a9-a691-c5ee41f9ad29.png)
  ![image](https://user-images.githubusercontent.com/62667937/147863257-964fb445-d045-4c55-9a1c-ed5f1ab36d3e.png)


Abrir el Script de la aplicacion:
   
  1. Abrir el script de la base de datos de la aplicacion mediante el Microsoft SQL Server managmente studio y 
     ejecutarlo (el script se encuentra adjunto en la carpeta de la entrega del proyecto.)

Ejecutar soluciones:


 1. Ejecutar la API, dando clic derecho sobre la solucion, seleccionar Depurar y finalmente nueva instancia 
 2. Ejecutar la aplicacion UWP, dando clic derecho sobre la solucion, seleccionar Depurar y finalmente nueva instancia 
 3. Los usuarios válidos dentro de la base de datos son:
    Usuario: Patty
    Contraseña: 123
    Usuario: Dome
    Contraseña: 123
    Usuario: Emilio
    Contraseña: 123
    Usuario: Juan
    Contraseña: 123
 
 
 ![image](https://user-images.githubusercontent.com/62667937/147863290-f614b3a5-c298-4fe3-b1f0-3aec3db66960.png)
 ![image](https://user-images.githubusercontent.com/62667937/147863294-c3a65f10-48c1-492e-97c0-373822507d62.png)
 ![image](https://user-images.githubusercontent.com/62667937/147863295-8b392e2f-4412-40a9-ba56-59d658d39aa5.png)


