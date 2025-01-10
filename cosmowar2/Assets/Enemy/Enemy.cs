using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform _player;
    [SerializeField] private int _hp;  
    [SerializeField] protected float _radiusMax;
    [SerializeField] private int _damage;

    private PlayerBullet _bull;

    protected float _radius;

    public int Damage { get; set; }
   
    protected virtual void Start()
    {
        Damage = _damage;
        _player = FindObjectOfType<Player>().transform;
        PlayerBullet._Playerdamage.AddListener(OnDamage);
    }

    protected virtual void Update()
    {
        _radius = Vector2.Distance(transform.position, _player.position);
        if (_radius <= _radiusMax)
        {
            var direction = (_player.position - transform.position).normalized;
            transform.up = direction;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBullet>())
        {
            _bull = GameObject.FindFirstObjectByType<PlayerBullet>();
            OnDamage(_bull.Damage);
        }
    }
    protected virtual void OnDamage(int damag)
    {
        _hp -= damag;
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
