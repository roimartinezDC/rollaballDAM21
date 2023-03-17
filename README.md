# rollaballDAM21

---

## PlayerController.cs

Este script es el principal del juego, y el que lleva el control de 
la mayoría de las cosas importantes. 
Está asignado al objeto "Player", de ahí su nombre, pero también controla 
el movimiento de la cámara y varios trigger. Yendo por partes, lo que hace 
es lo siguiente:

### Control del jugador

La función principal de este script es que controla los movimientos del 
jugador mediante el método ``MovimientoPersonaje()``, el cual luego es llamado
en el método reservado de Unity ``Update()``.

Lo que hace ``MovimientoPersonaje()``, es recoger los valores del movimiento
_"X"_ y _"Z"_ que le damos al juego mediante las teclas flechas o _"WASD"_. Según
estos valores puede crear una variable llamada *movimiento*, la cual es multiplicada 
por una variable serializada llamada *velocidadMovimiento*.

Además de todo esto, este método también permite saltar al jugador, detecta si
pulsamos la tecla espacio, y si lo hacemos eleva la posición del jugador un 0.7 en el 
eje _"Y"_.

### Control de la cámara

Este script, también controla el comportamiento de la cámara, en primer lugar explicar
que en el juego, la cámara está asignada como "hija" del objeto jugador, por que ya
de por sí esta va a seguir siempre al jugador.

Independientemente de esto, el método ``MovimientoCamara()`` establece la posición de la 
cámara dentro del jugador, por lo que pasa a ser un juego en primera persona. El método también
recoge los movimientos del ratón como controladores de la cámara.

El método está codificado de tal manera que al mover el ratón no solo gira la cámara, si no que
tambiém rota al jugador, de modo que te puedes desplazar por el mapa pulsando sólamente la 
tecla avanzar, y moviendo la cámara para virar. También existen movimientos laterales, pero estos 
simularían como cuando te mueves lateralmente en la vida real.

### Triggers

El método ``OnTriggerEnter()``, es un método reservado de Unity, y controla todas las interacciones
del jugador con los demás objetos del juego.

Si el jugador interactúa con un elemento de etiqueta _"pickup"_ (que son las monedas), la moneda 
desaparece y se suma 1 a la puntuación del jugador.

Si resuelves el laberinto, encontrarás un círculo violeta en el suelo, es un elemento con la etiqueta
"_teleport_", y si interactúas con él pueden pasar dos cosas:

  * Si has recogido al menos tres monedas antes, te teletransporta al inicio del juego, y se abre una
compuerta detrás tuya que te permite ingresar a un túnel.

  * Si no has recogido por lo menos tres monedas, también te teletransporta al inicio del juego, pero 
no abre ninguna compuerta secreta y te establece la puntuación a 0, además de volver a mostrar todas las 
monedas que habían desaparecido.