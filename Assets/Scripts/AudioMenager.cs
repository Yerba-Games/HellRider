using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject tempAudioPrefab;
    [SerializeField] AudioField audioShoot;
    [SerializeField] AudioField audioKill;
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
        SpawnEarthButton.Clicked += PlayButtonKickoff;
        Star.Collected += PlayCollectedStar;
        KopernikMgr.KickedEarth += PlayEarthKicked;
        Planet.LevelCompleted += PlayLevelCompleted;
        Planet.Exploded += PlayEarthExplosion;
        Draggable.PickedUp += PlayPickedUp;
        Draggable.Dropped += PlayDropped;
        UFO.UfoIn += PlayUfoIn;
        UFO.UfoOut += PlayUfoOut;
    }

    private void OnDisable()
    {
        SpawnEarthButton.Clicked -= PlayButtonKickoff;
        Star.Collected -= PlayCollectedStar;
        KopernikMgr.KickedEarth -= PlayEarthKicked;
        Planet.LevelCompleted -= PlayLevelCompleted;
        Planet.Exploded -= PlayEarthExplosion;
        Draggable.PickedUp -= PlayPickedUp;
        Draggable.Dropped -= PlayDropped;
        UFO.UfoIn -= PlayUfoIn;
        UFO.UfoOut -= PlayUfoOut;
    }

    private void PlayButtonKickoff()
    {
        PlayAudioEffect(audioShoot);
    }

    private void PlayCollectedStar()
    {
        PlayAudioEffect(audioKill);
    }

    private void PlayEarthKicked()
    {
        PlayAudioEffect(audioDamage);
    }

    private void PlayEarthKicked()
    {
        PlayAudioEffect(audioMusic);
    }
}
