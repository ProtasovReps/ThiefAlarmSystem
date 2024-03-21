using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            StartCoroutine(IncreaseAlarmVolume());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            StartCoroutine(DecreaseAlarmVolume());
    }

    private IEnumerator IncreaseAlarmVolume()
    {
        float step = 0.001f;

        while (_audioSource.volume != _audioSource.maxDistance)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, step);
            yield return null;
        }
    }

    private IEnumerator DecreaseAlarmVolume()
    {
        float step = -0.001f;

        while (_audioSource.volume != _audioSource.minDistance)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.minDistance, step);
            yield return null;
        }
    }
}
