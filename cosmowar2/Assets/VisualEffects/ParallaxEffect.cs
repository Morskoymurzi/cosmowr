using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] private float _parallaxStrenght = 0.1f;
    [SerializeField] private bool disableParallax;

    private Vector3 _targetPreviousPosition;

    private void Start()
    {
        if(!_followingTarget)
            _followingTarget = Camera.main.transform;

        _targetPreviousPosition = _followingTarget.position;
    }

    private void Update()
    {
        var delta = _followingTarget.position - _targetPreviousPosition;

        if (disableParallax)
            delta.y = 0f;

        _targetPreviousPosition = _followingTarget.position;

        transform.position += delta * _parallaxStrenght;
    }
}
