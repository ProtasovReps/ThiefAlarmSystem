using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private bool _isEnter;

    private void OnTriggerEnter(Collider other)
    {
        _isEnter = true;

        if (other.TryGetComponent<Thief>(out _))
            _alarmSystem.Play(_isEnter);
    }

    private void OnTriggerExit(Collider other)
    {
        _isEnter = false;

        if (other.TryGetComponent<Thief>(out _))
            _alarmSystem.Play(_isEnter);
    }
}
