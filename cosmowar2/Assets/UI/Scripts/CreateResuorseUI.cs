using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class CreateResuorseUI : MonoBehaviour
{
    [SerializeField] private Image _imageResuorseUI;
    public static UnityEvent<string> OnName = new UnityEvent<string>();
    private Transform _parent;

    private CountResuorse _rs;

    private void Awake()
    {
        _parent = transform;
        CheakeUIResuorse.CreateRsUI.AddListener(TryCreateResuorse);
    }
    private void Start()
    {
        _parent = transform;
    }

    private void TryCreateResuorse(string Name)
    {
        Instantiate(_imageResuorseUI, _parent.parent).GetComponent<CountResuorse>();
        OnName.Invoke(Name);
        
    }
}
