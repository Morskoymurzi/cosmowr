using UnityEngine.AI;

public class EnemyShipPlus : Enemy
{
    private NavMeshAgent agent;

    protected override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        base.Start();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    protected override void Update()
    {
        base.Update();

        if (_radius <= _radiusMax)
        {
            if (_radius > 5f)
            {
                agent.isStopped = false;
                agent.SetDestination(_player.position);
            }
            else
            {
                agent.isStopped = true;
            }
        }
    }
}
