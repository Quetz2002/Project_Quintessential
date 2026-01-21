# 🎮 Project Quintessential

> Un videojuego multijugador de terror y supervivencia desarrollado en Unity

Project Quintessential es un proyecto de videojuego multijugador en línea enfocado en el terror y la supervivencia. La idea principal es que varios jugadores cooperen (o sobrevivan individualmente) para escapar de una zona específica, enfrentándose a amenazas y situaciones de alto riesgo.

## 🎯 Concepto del Juego

| Aspecto | Descripción |
|---------|-------------|
| **Género** | Terror / Supervivencia |
| **Modalidad** | Multijugador en línea |
| **Plataforma** | Unity 3D |

### Objetivos Principales

- 🏃‍♂️ **Sobrevivir** - Mantente con vida ante las amenazas
- 🔍 **Explorar** - Descubre los secretos del área
- 🚪 **Escapar** - Encuentra la salida del área designada

## 🛠️ Implementación Técnica

El sistema multijugador se está desarrollando utilizando las siguientes herramientas de Unity:

### Tecnologías Utilizadas

- **[Netcode for GameObjects](https://docs.unity3d.com/Packages/com.unity.netcode.gameobjects@latest/)** - Sistema de red principal
- **[Multiplayer Play Mode](https://docs.unity3d.com/Packages/com.unity.multiplayer.playmode@latest/)** - Testing multijugador

### Características del Sistema

✅ Instanciar dos o más jugadores independientes  
✅ Compartir un mismo código base  
✅ Manejar correctamente la lógica de red  

## 🔁 Lógica de Red

### Arquitectura de Red

Para el manejo del multijugador se implementa:

```csharp
// Cambio de herencia base
MonoBehaviour → NetworkBehaviour
```

### Sistema de Validación

El sistema incluye validación para:

- ✅ **Verificar propietario** - Qué jugador es el propietario del objeto
- ✅ **Control exclusivo** - Solo el jugador correcto puede moverse o ejecutar acciones  
- ✅ **Prevención de conflictos** - Evitar conflictos de control entre instancias

## 🚧 Estado del Proyecto

> **Fase:** Desarrollo Temprano

Este es todo el progreso realizado hasta el momento. El proyecto se encuentra en fase temprana de desarrollo y continuará expandiéndose en futuras iteraciones.

### Próximos Pasos

- [ ] Implementar mecánicas de terror
- [ ] Desarrollar sistema de supervivencia
- [ ] Crear mapas y escenarios
- [ ] Añadir elementos de escape

---

**Desarrollado con ❤️ usando Unity**
