using UnityEngine;

public class ArmorBaff : MonoBehaviour
{
    [SerializeField] private float _hp;

    private Bullet _bull;
    private PlayerBullet _Pbull;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>())
        {
            OnDamage(_bull.DamageBullet);
        }
        else if (collision.gameObject.GetComponent<PlayerBullet>())
        {
            OnDamage(_Pbull.Damage);
        }
    }

    private void OnDamage(float damage)
    {
        if (damage <= 0)
            damage = 1;

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
