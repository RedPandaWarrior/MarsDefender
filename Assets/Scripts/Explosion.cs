using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(OnAudioEnd());
    }
    private IEnumerator OnAudioEnd()
    {
        yield return new WaitWhile(() => _audioSource.isPlaying);
        Destroy(this.gameObject);
    }
}
