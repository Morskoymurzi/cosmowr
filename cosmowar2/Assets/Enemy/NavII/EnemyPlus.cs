using UnityEngine.AI;

public class EnemyPlus : Enemy
{ 
    private NavMeshAgent agent;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    protected override void Update()
    {
        base.Update();
        agent.SetDestination(_player.position);
    }
}
