Project Quintessential

Project Quintessential es un proyecto de videojuego multijugador en línea enfocado en el terror y la supervivencia.
La idea principal es que varios jugadores cooperen (o sobrevivan individualmente) para escapar de una zona específica, enfrentándose a amenazas y situaciones de alto riesgo.

🎮 Concepto del Juego

Género: Terror / Supervivencia

Modalidad: Multijugador en línea

Objetivo principal:

Sobrevivir

Explorar

Escapar del área designada

🛠️ Implementación Técnica

El sistema multijugador se está desarrollando utilizando las siguientes herramientas de Unity:

Netcode for GameObjects

Multiplayer Play Mode

Estas herramientas permiten:

Instanciar dos o más jugadores independientes

Compartir un mismo código base

Manejar correctamente la lógica de red

🔁 Lógica de Red

Para el manejo del multijugador:

Se cambia la herencia de MonoBehaviour a NetworkBehaviour

Se implementa una lógica de validación para:

Verificar qué jugador es el propietario del objeto

Asegurar que solo el jugador correcto pueda moverse o ejecutar acciones

Evitar conflictos de control entre instancias

🚧 Estado del Proyecto

Este es todo el progreso realizado hasta el momento.
El proyecto se encuentra en fase temprana de desarrollo y continuará expandiéndose en futuras iteraciones.
