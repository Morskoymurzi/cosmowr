using UnityEngine;
using UnityEngine.Events;

public class PlayerBullet : MonoBehaviour
{
   [SerializeField] private int _damage;
   [SerializeField] private float _speed;

    private Transform _transform;

    public int Damage { get; set; }
    public static UnityEvent<int> _Playerdamage = new UnityEvent<int>();

    private void Start()
    { 
        Damage = _damage;
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D enemys)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
