using UnityEngine;

/// <summary>
/// Controlador principal de la IA. Gestiona el estado actual y las transiciones.
/// </summary>
public class AIController : MonoBehaviour
{
    // Configuración de la IA, visible en el Inspector de Unity
    [Header("AI Settings")]
    public Transform[] waypoints; // Para que el Diseñador asigne la ruta
    public float patrolSpeed = 2f; // Velocidad de patrullaje
    public float chaseSpeed = 5f;  // Velocidad de persecución
    public float detectionRadius = 10f; // Radio de detección
    public float loseSightRadius = 15f; // Radio de pérdida de vista

    // Referencia al estado actual de la IA
    private AIState _currentState;

    // Método Awake: Se ejecuta al inicializar el script, asignando el estado inicial.
    private void Awake()
    {
        // El estado inicial
        ChangeState(new PatrolState(this));
    }

    // Método Update: Se ejecuta cada frame, delegando la lógica de actualización al estado actual.
    // Principio de Responsabilidad Única
    private void Update()
    {
        _currentState?.UpdateState();
    }

    // Cambia el estado actual de la IA
    public void ChangeState(AIState newState)
    {
        // Si hay un estado actual, ejecuta OnExit
        _currentState?.OnExit();

        // Cambia al nuevo estado y ejecuta OnEnter
        _currentState = newState;
        _currentState.OnEnter();
    }
}
