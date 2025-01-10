using UnityEngine;

public class Ckamikadze : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private int _Daamage;

    private bool atack;

    protected override void Update()
    {
        _radius = Vector2.Distance(transform.position, _player.position);
        if (_radius <= _radiusMax)
        {
            var direction = (_player.position - transform.position).normalized;
            transform.up = direction;
            atack = true;
        }
    }

    private void Move()
    {
      transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        if (atack)
        {
            Move();
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Destroy(gameObject);
        collision.gameObject.SetActive(false);
    }
}
