using UnityEngine;
using TMPro;

public class CountResuorse : MonoBehaviour
{
    private int _count = 1; 

    public string CountName { get; set; }

    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private string _name;

    private void Awake()
    {
        CreateResuorseUI.OnName.AddListener(Naming);
        CheakeUIResuorse.ChangeRs.AddListener(ChangeReasuorseUI);
    }

    private void Naming(string Name)
    {
        _name = Name;
       Debug.Log(_name);
       CountName = _name;
        _textName.text = _name;
        CreateResuorseUI.OnName.RemoveListener(Naming);
    }
    private void ChangeReasuorseUI(string Name)
    {
        if(Name == _name)
        _count++;
        _textCount.text = _count.ToString();
    }
}
