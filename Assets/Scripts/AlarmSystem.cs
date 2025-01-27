using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;
    private float _volumeChangeSpeed = 0.001f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    public void Play(bool isEnter)
    {
        TryStopVolumeChanging();
        _coroutine = StartCoroutine(ChangeVolumeSmoothly(isEnter));
    }

    private void TryStopVolumeChanging()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ChangeVolumeSmoothly(bool isEnter)
    {
        float targetVolume = _maxVolume;
        float volumeChangeSpeed = _volumeChangeSpeed;

        if (isEnter == false)
        {
            volumeChangeSpeed = -_volumeChangeSpeed;
            targetVolume = _minVolume;
        }

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _audioSource.maxDistance, volumeChangeSpeed);
            yield return null;
        }
    }
}
