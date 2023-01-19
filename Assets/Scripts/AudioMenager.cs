using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject tempAudioPrefab;
    [SerializeField] AudioField audioShoot;
    [SerializeField] AudioField audioKill;
    [SerializeField] AudioField audioHit;
    [SerializeField] AudioField audioDamage;
    [SerializeField] AudioField audioMusic;


    [System.Serializable]
    public struct AudioField
    {
        public AudioClip clip;
        public float volume;
    }

    private void PlayAudioEffect(AudioField audioField)
    {
        if (audioField.clip == null)
            return;

        GameObject obj = Instantiate(tempAudioPrefab).gameObject;
        obj.GetComponent<AudioSource>().clip = audioField.clip;
        obj.GetComponent<AudioSource>().volume = audioField.volume;
        obj.GetComponent<AudioSource>().Play();
    }

    private void OnEnable()
    {
        += PlayKIll;
        += PlayHit;
        += PlayDamage;
        += PlayShoot;
        += PlayMusic;
    }

    private void OnDisable()
    {
        += PlayKIll;
        += PlayHit;
        += PlayDamage;
        += PlayShoot;
        += PlayMusic;

    }

    private void PlayShoot()
    {
        PlayAudioEffect(audioShoot);
    }

    private void PlayKill()
    {
        PlayAudioEffect(audioKill);
    }

    private void PlayDamage()
    {
        PlayAudioEffect(audioDamage);
    }

    private void PlayHit()
    {
        PlayAudioEffect(audioHit);
    }

    private void PlayMusic()
    {
        PlayAudioEffect(audioMusic);
    }
}
