using UnityEngine;

public class CameraMov : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector3 _posSmoth, _posEnd;

    private void Update()
    {
        _posEnd = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);

        _posSmoth = Vector3.Lerp(transform.position, _posEnd, 1);

        transform.position = _posSmoth;
    }

}
