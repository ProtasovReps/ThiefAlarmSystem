using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;

    private float _speed = 3f;
    private int _currentIndex = 0;

    private void Update()
    {
        FollowTargets();
    }

    private void FollowTargets()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targets[_currentIndex].position, _speed * Time.deltaTime);
        transform.LookAt(_targets[_currentIndex].position);

        if (transform.position == _targets[_currentIndex].position)
            _currentIndex = (_currentIndex + 1) % _targets.Length;
    }
}