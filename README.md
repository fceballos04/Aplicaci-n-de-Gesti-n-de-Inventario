<h1 align="center">"AntHive Stock"</h1> 

__Sistema de Gestión de Inventario__

Esta aplicación permite controlar entradas, salidas y stock en tiempo real de empresas y negocios.

Este proyecto consiste en el diseño y desarrollo de una aplicación para la gestión de inventarios, orientada a optimizar el control de productos en tiempo real. La plataforma surge como una solución tecnológica para digitalizar procesos que tradicionalmente son propensos a errores manuales, permitiendo una administración más eficiente, segura y centralizada de los recursos.

El enfoque principal está en garantizar la integridad de los datos durante las operaciones de entrada y salida, así como en la creación de una interfaz intuitiva que facilite la toma de decisiones estratégicas mediante el monitoreo constante del stock. Estamos construyendo una herramienta escalable que no solo registre movimientos, sino que aporte valor operativo a través de la automatización y la transparencia informativa.

<h1 align="start">Reglas para el Equipo (Git Workflow)</h1> 

__Para mantener el código limpio y evitar que el main se rompa, todos seguimos este flujo de trabajo:__

- Crea una rama (branch) personal
- Cada miembro subira los avances que se le indique a su rama (branch) personal
- Los commits deben ser claros, concisos y en tercera persona por ejemplo: "Se agrega un nuevo boton", "Se arregla el error del Login"
- Todos los avances que se integrean al __main__ seran previamente aceptados por un Pull Request (PR)
- En el Pull Request (PR) Describe qué cambiaste y espera la revisión del creador del repositorio.
- Una vez aprobado, se fusiona a la rama main.
  
[!IMPORTANTE]
Nunca hagas push directo a la rama main. ¡EL MAIN NO SE TOCA! (por seguridad)

<h1 align="start">Pasos para subir avances</h1> 
Primero antes de subir cualquier avance hay que verificar que tenemos las ultimas actualizaciones del main

Para eso hacemos lo siguiente:
- Abrimos la terminal de __git__ donde hicimos el __git clone__ e inicializamos con __git init__
- Luego le hacemon un __pull__ con __git pull origin main__ (El origin es para hacerle pull al main del repositorio remoto y no el local)
  
Con eso ya tenemos lo ultimo del main ahora toca subir los avances a nuestra rama

Después de haber avanzado algo en el proyecto lo subimos a nuestra rama (branch):
- __git branch__ para verificar que estamos en nuestra rama (branch) personal y no en el main u otra rama (branch)
- Si llegamos a estar en otra rama (branch) hacemos __git checkout nombre-de-tu-rama__
- __git add .__ (el punto es para subir todos los cambios si quieres subir el de un archivo o carpeta en especifico solo pones el nombre del archivo o carpeta)
- __git commit -m "AQUI VA TU COMENTARIO"__
- __git push origin nombre-de-tu-rama__

  <h2 align="start">Arquitectura utilizada</h2>
  Utilizaremos la arquitectura MVVM (Model, View, ViewModel)
  "Actualmente seguimos trabajando en la arquitectura"


<h2 align="start">Equipo de desarollo</h2>

Fernando Ceballos

Jesus

Miguel 

Aldo

_Proyecto desarrollado con fines educativos y profesionales._
