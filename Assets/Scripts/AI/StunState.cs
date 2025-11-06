using UnityEngine;

public class StunState : AIState
{
    public StunState(AIController controller) : base(controller) { }

    public override void OnEnter()
    {
        Debug.Log("Entrando en estado de Stun.");
        m_agent.isStopped = true;
        m_controller.StartStunCoroutine();
    }

    public override void UpdateState()
    {
        // No necesita lógica, la corrutina maneja el tiempo
    }

    public override void OnExit()
    {
        m_agent.isStopped = false;
    }
}
