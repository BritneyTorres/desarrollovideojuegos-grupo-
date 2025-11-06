using UnityEngine;

/// <summary>
/// Controlador principal de la IA. Gestiona el estado actual y las transiciones
/// </summary>
public class AIController : MonoBehaviour
{
    private AIState _currentState;

    private void Awake()
    {
        // El estado inicial
        ChangeState(new PatrolState(this));
    }

    private void Update()
    {
        // Delega la lógica de actualización al estado actual
        // Principio de Responsabilidad Única
        _currentState?.UpdateState();
    }

    public void ChangeState(AIState newState)
    {
        _currentState?.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
}