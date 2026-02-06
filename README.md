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
- 🎯 **Recolectar** - Encuentra y recoge objetos importantes
- 🚪 **Escapar** - Encuentra la salida del área designada

## 🛠️ Implementación Técnica

El sistema multijugador se está desarrollando utilizando las siguientes herramientas de Unity:

### Tecnologías Utilizadas

- **[Netcode for GameObjects](https://docs.unity3d.com/Packages/com.unity.netcode.gameobjects@latest/)** - Sistema de red principal
- **[Multiplayer Play Mode](https://docs.unity3d.com/Packages/com.unity.multiplayer.playmode@latest/)** - Testing multijugador
- **[Unity Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest/)** - Sistema de entrada moderno
- **[Universal Render Pipeline (URP)](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest/)** - Pipeline de renderizado

## ✨ Características Implementadas

### Sistema de Red

✅ **Arquitectura Cliente-Servidor**
- Host y cliente pueden conectarse mediante UI
- Sincronización automática de jugadores
- Gestión de propietarios de objetos en red

✅ **NetworkBehaviour Base**
```csharp
// Todos los componentes de red heredan de NetworkBehaviour
public class PlayerMovement : NetworkBehaviour
```

### Sistema de Jugadores

✅ **Movimiento Multijugador**
- Control de movimiento con WASD
- Validación de propietario (`IsOwner`)
- Sincronización mediante `ServerRpc`
- Velocidad configurable

✅ **Identificación Visual**
- Colores únicos por jugador (verde para host, rojo para clientes)
- Sincronización de apariencia mediante `NetworkVariable<Color>`
- Actualización automática en todos los clientes

### Sistema de Recolección

✅ **Objetos Coleccionables**
- Detección por proximidad (tecla E)
- Estado sincronizado en red (`NetworkVariable<bool>`)
- Desaparición visual al ser recolectados
- Despawn automático del objeto en red

✅ **Sistema de Spawn**
- Generación de objetos en el servidor
- Sincronización automática con clientes
- Prefabs configurables

## 🔁 Arquitectura de Red

### Patrón de Comunicación

```csharp
// Cliente → Servidor
[ServerRpc]
void MoveServerRPC(Vector3 move)
{
    transform.Translate(move);
}

// Servidor → Todos los clientes
[Rpc(SendTo.Server)]
public void CollectServerRpc()
{
    if (isCollected.Value) return;
    isCollected.Value = true;
}
```

### Variables de Red

```csharp
// Sincronización automática de estado
private NetworkVariable<Color> playerColor = 
    new NetworkVariable<Color>(
        Color.cyan,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server
    );
```

### Sistema de Validación

- ✅ **Verificar propietario** - Solo el dueño puede controlar su jugador
- ✅ **Control exclusivo** - Prevención de inputs duplicados
- ✅ **Autoridad del servidor** - Validación server-side de acciones
- ✅ **Sincronización de estado** - Callbacks automáticos en cambios

## 📁 Estructura del Proyecto

```
Assets/
├── Prefabs/
│   └── Collectible.prefab      # Objeto coleccionable
├── Scenes/
│   └── SampleScene.unity       # Escena principal
├── Scripts/
│   ├── PlayerMovement.cs       # Control de movimiento
│   ├── PlayerApperence.cs      # Apariencia del jugador
│   ├── CollectibleItem.cs      # Lógica de coleccionables
│   ├── Spawner.cs              # Generador de objetos
│   └── Network UI.cs           # Interfaz de conexión
└── Settings/                   # Configuración URP
```

## 🚀 Cómo Ejecutar

1. Abre el proyecto en Unity (versión recomendada: 2022.3 LTS o superior)
2. Abre la escena `Assets/Scenes/SampleScene.unity`
3. Presiona Play
4. Usa los botones de la UI para:
   - **Iniciar Host** - Crea una sesión y actúa como servidor
   - **Iniciar Cliente** - Conecta a una sesión existente

### Controles

- **WASD** - Movimiento del jugador
- **E** - Recolectar objetos cercanos

## 🚧 Estado del Proyecto

> **Fase:** Prototipo Funcional

El proyecto cuenta con un sistema multijugador funcional con mecánicas básicas de movimiento y recolección.

### Próximos Pasos

- [ ] Implementar mecánicas de terror (enemigos, sustos)
- [ ] Desarrollar sistema de supervivencia (vida, stamina)
- [ ] Crear mapas y escenarios más complejos
- [ ] Añadir sistema de objetivos y escape
- [ ] Implementar inventario
- [ ] Añadir efectos de sonido y música
- [ ] Mejorar la UI y feedback visual

---

**Desarrollado con ❤️ usando Unity**
