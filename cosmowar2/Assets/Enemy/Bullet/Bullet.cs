using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Transform _transform; 
    private GameObject[] enemy;
    private GameObject closest;
    private Spawner _spawner;
    private float _damage;

    [SerializeField] private float _speed;

    public float DamageBullet { get; private set; }

    private void Start()
    {
        _transform = transform;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        _spawner = FindClosestEnemy().GetComponent<Spawner>();
        _damage = _spawner.Damage;
        DamageBullet = _damage;

    }

    private GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - position;
            float curdist = diff.sqrMagnitude;
            if (curdist < distance)
            {
                closest = go;
                distance = curdist;
            }
        }
        return closest;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        Destroy(gameObject);
    }
}
