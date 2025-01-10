using UnityEngine;

public class EnemyShip : Enemy
{
    [SerializeField] private float _speed;

    protected override void Update()
    {
        base.Update();
    }

    private void Move()
    {
        if (_radius <= _radiusMax)
        {
            if (_radius > 5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.fixedDeltaTime);
            }
            else if (_radius < 3f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.position, -_speed * Time.fixedDeltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();   
    }
}
