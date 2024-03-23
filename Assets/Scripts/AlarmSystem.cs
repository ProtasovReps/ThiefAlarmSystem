using System.Collections;
using TMPro;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    public void IncreaseVolume()
    {
        StartCoroutine(ChangeAlarmVolume(_volumeChangeSpeed, _maxVolume));
    }

    public void DecreaseVolume() 
    {
        StartCoroutine(ChangeAlarmVolume(-_volumeChangeSpeed, _minVolume));
    }

    private IEnumerator ChangeAlarmVolume(float volumeChangeSpeed, float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, volumeChangeSpeed);
            yield return null;
        }
    }
}
