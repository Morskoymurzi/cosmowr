using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _offset;
    [SerializeField] private float _hp;
    
    private float x;
    private float y;
    private Bullet bullet;
     
    private void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);
    }

    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");   
        y = Input.GetAxis("Vertical");
        transform.position = new Vector2(transform.position.x + (_speed * x) * Time.fixedDeltaTime,
            transform.position.y + (_speed * y) * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.GetComponent<Bullet>()) ;
            OnDamage(bullet.DamageBullet);
    }

    private void OnDamage(float damage)
    {
        _hp -= damage;
        if (_hp < 0)
        {
            _hp = 0;
        }
        if (_hp == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
