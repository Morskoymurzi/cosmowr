using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class spawnbull : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float reload = 3;
    [SerializeField] private float _damageBreadwinner;

    public static UnityEvent<float> DamageOfBredwinner = new UnityEvent<float>();

    private int _CurrentObj = 0;    
    private bool _isShooting = false;
    private bool _isGun = true;

    public float DamageB { get; set; }
    private void Start()
    {
        StartCoroutine(GunSoot());
        DamageB = _damageBreadwinner;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isGun=!_isGun;
            Debug.Log(_isGun);
        }        
        if (Input.GetMouseButtonDown(0) && _CurrentObj == 0 && _isGun)
        {
            _isShooting = true;
        }
        else if (Input.GetMouseButtonDown(0) &&  !_isGun)
        {
            Breadwinner();
        }
    }
    private IEnumerator GunSoot()
    {
        while (true)
        {
            yield return new WaitUntil(() => _isShooting);
            _isShooting = false;
            Instantiate(_bullet, transform.position, transform.rotation);
            _CurrentObj++;
            yield return new WaitForSeconds(reload);
            _CurrentObj--;
        }
    }

    private void Breadwinner()
    {
        Debug.DrawRay(transform.position, transform.forward,Color.red);
        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit2D = Physics2D.Raycast(ray, Vector2.zero); 

        if (hit2D.transform != null)
        {
            DamageOfBredwinner.Invoke(_damageBreadwinner);
        }
    }
}