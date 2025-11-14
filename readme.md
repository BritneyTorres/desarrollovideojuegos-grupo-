# 🏰 README — Práctica #12: La Chispa de Vida — IA con Máquinas de Estado

## 🎮 Nombre del Estudio
**Eclipse Forge Studio**

---

## 👥 Miembros del Equipo y Roles
| Integrante | Rol en el Estudio |
|-----------|-------------------|
| **Taquiri Rojas Phol Edwin** | Arquitecto de IA |
| **Torres Sanabria Britney Elizabeth** | Diseñadora de Comportamiento |
| **Tovar Payano Diego Marc** | Integrador y QA |

---

## 🧩 Descripción del Hito
En este hito construimos la primera inteligencia artificial completa del proyecto, basada en una máquina de estados modular. El trabajo del estudio permitió levantar el entorno de navegación, estructurar el “cerebro” del enemigo mediante clases derivadas de `AIState` y configurar comportamientos como patrulla, persecución y aturdimiento.  
También creamos y ajustamos los puntos de recorrido, definimos transiciones coherentes entre estados y ajustamos los parámetros expuestos para que la IA respondiera al jugador de forma natural dentro del mundo del juego.  
El resultado es un enemigo que detecta, persigue, pierde de vista y puede ser aturdido, aportando vida y riesgo al escenario.

---

## 🧠 Reflexión del Estudio

### ⭐ 1. Sinergia y Fricción
**Mayor beneficio:**  
La ventaja principal fue poder avanzar en paralelo gracias a roles definidos. Mientras el arquitecto implementaba la lógica del sistema, la diseñadora ajustaba la personalidad del enemigo desde el editor y el integrador validaba su comportamiento dentro del entorno real del nivel. Esta coordinación permitió avanzar sin bloqueos.

**Mayor desafío y cómo lo resolvimos:**  
Uno de los obstáculos fue la inconsistencia en la transición entre persecución y patrulla: el enemigo detectaba bien al jugador, pero a veces no retornaba a su ruta. Cada rol tenía una percepción distinta del problema, así que realizamos una revisión conjunta del NavMesh, parámetros y controlador. Esto reveló un desbalance entre `detectionRadius` y `loseSightRadius`. Ajustar esos valores y probar juntos estabilizó el comportamiento.

---

### ⚙️ 2. El Alma de la Máquina
El parámetro que más influyó en que la IA se percibiera “viva” fue la relación entre **`detectionRadius`** y **`loseSightRadius`**.  
Cuando estos valores estaban desbalanceados, el enemigo reaccionaba de manera exagerada o demasiado torpe. Ajustarlos en equilibrio permitió que la IA mostrara un comportamiento más creíble: detecta al jugador cuando corresponde y regresa a patrullar con naturalidad.

Un segundo parámetro de gran impacto fue **`stunDuration`**, que define cuánto tiempo el enemigo queda inmovilizado en el nuevo estado de aturdimiento antes de retomar su comportamiento normal.

---

## 🗂️ Tecnologías y Conceptos Implementados
- Patrón de diseño **State**
- Agentes autónomos con **NavMeshAgent**
- Estados principales:
  - `PatrolState`
  - `ChaseState`
  - `StunState`
- Parámetros configurables mediante `[SerializeField]`
- Preparación del entorno:
  - Horneado de NavMesh
  - Configuración de waypoints
  - Creación de prefab del enemigo
- Pruebas funcionales e integración final en equipo

---

## 🏁 Resultado Final
El enemigo ahora puede:
- Patrullar rutas definidas
- Detectar al jugador dentro de un rango configurado
- Perseguirlo usando navegación
- Perderlo de vista y retomar su patrulla
- Ser aturdido temporalmente y recuperarse después

