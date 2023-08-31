using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {

        if (musicClips.Length > 0)
        {
            PlayRandomClip();
        }
        else
        {
            Debug.LogError("No se han asignado clips de audio al MusicManager.");
        }
    }

    private void PlayRandomClip()
    {
        int randomIndex = Random.Range(0, musicClips.Length);
        AudioClip randomClip = musicClips[randomIndex];

        audioSource.clip = randomClip;
        audioSource.Play();

        StartCoroutine(WaitForClipEnd(randomClip.length));
    }

    private IEnumerator WaitForClipEnd(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);

        PlayRandomClip();
    }

}
