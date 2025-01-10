using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour 
{
    [SerializeField] private GameObject _spawnPrefab;
    [SerializeField] private float _spawnTime;
    [SerializeField] private Transform _mob;
    [SerializeField, Min(1f)] private float _damage;
    [SerializeField] private float _attackRadius;

    public float Damage { get; private set; }
    private float _radius;
    private bool _isAttack;

    private void Start()
    {  
        Damage = _damage;
        _mob = FindObjectOfType<Player>().transform;
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        _radius = Vector2.Distance(transform.position, _mob.position);
        if (_radius <= _attackRadius)
        {
            _isAttack = true;
        }      
        else
        {
            _isAttack = false;
        }
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitUntil(predicate:() => _isAttack == true);
            yield return new WaitForSeconds(_spawnTime);
            Instantiate(_spawnPrefab, transform.position, transform.rotation);
        }

    }
}
