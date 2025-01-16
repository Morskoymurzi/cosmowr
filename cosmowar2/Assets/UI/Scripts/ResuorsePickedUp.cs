using UnityEngine;
using UnityEngine.Events;

public class ResuorsePickedUp : MonoBehaviour
{
    [SerializeField] private string _rsName;

    public static UnityEvent<string> CreateRsUI = new UnityEvent<string>();
    public string rsName { get; set; }

    private void Start()
    {
        rsName = _rsName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreateRsUI.Invoke(rsName);
        Debug.Log(rsName);
    }
}
