using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            _alarmSystem.IncreaseVolume();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            _alarmSystem.DecreaseVolume();
    }
}
