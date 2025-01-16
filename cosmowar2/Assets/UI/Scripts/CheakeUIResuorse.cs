using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CheakeUIResuorse : MonoBehaviour
{
    public static UnityEvent<string> ChangeRs = new UnityEvent<string>();
    public static UnityEvent<string> CreateRsUI = new UnityEvent<string>();

    public CountResuorse rs;

   [SerializeField] private List<string> _gameobj = new List<string>();
    private void Awake()
    { 
        ResuorsePickedUp.CreateRsUI.AddListener(ChakeResourse);
        CreateResuorseUI.OnName.AddListener(AddNameMassive);
    }
    private void AddNameMassive(string Name)
    {
       _gameobj.Add(Name);
    }
    private void ChakeResourse(string Name)
    {     
        var index = _gameobj.Contains(Name);
        if (!index)
        {
            Debug.Log(index);
            CreateRsUI.Invoke(Name);
        }
        else 
        {
            ChangeRs.Invoke(Name);
        }

    }
  
}
