using UnityEngine;
using System.Collections;

/// <summary>
/// Controlador principal de la IA. Gestiona el estado actual y las transiciones.
/// </summary>
public class AIController : MonoBehaviour
{
    // Configuraci�n de la IA, visible en el Inspector de Unity
    [Header("AI Settings")]
    public Transform[] waypoints; // Para que el Dise�ador asigne la ruta
    public float patrolSpeed = 2f; // Velocidad de patrullaje
    public float chaseSpeed = 5f;  // Velocidad de persecuci�n
    public float detectionRadius = 10f; // Radio de detecci�n
    public float loseSightRadius = 15f; // Radio de p�rdida de vista
    public float stunDuration = 3f; // Duraci�n del estado de stun

    // Referencia al estado actual de la IA
    private AIState _currentState;

    // M�todo Awake: Se ejecuta al inicializar el script, asignando el estado inicial.
    private void Awake()
    {
        // El estado inicial
        ChangeState(new PatrolState(this));
    }

    // M�todo Update: Se ejecuta cada frame, delegando la l�gica de actualizaci�n al estado actual.
    // Principio de Responsabilidad �nica
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

    // Inicia la corrutina de stun
    public void StartStunCoroutine()
    {
        StartCoroutine(StunCoroutine());
    }

    private IEnumerator StunCoroutine()
    {
        yield return new WaitForSeconds(stunDuration);
        ChangeState(new PatrolState(this));
    }
}
