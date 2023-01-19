using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject tempAudioPrefab;
    [SerializeField] AudioField audioShoot;
    [SerializeField] AudioField audioKill;
    [SerializeField] AudioField audioHit;
    [SerializeField] AudioField audioDamage;
    [SerializeField] AudioField audioMusic;
    Actions input;

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
    private void Awake()
    {
        input = new Actions();
    }
    private void OnEnable()
    {
        //+= PlayKIll;
        //+= PlayHit;
        //+= PlayDamage;
        input.Player.Fire.performed += PlayShoot;
        //+= PlayMusic;
        input.Player.Enable();
    }

    private void OnDisable()
    {
        //-= PlayKIll;
        //-= PlayHit;
        //-= PlayDamage;
        input.Player.Fire.performed -= PlayShoot;
        //-= PlayMusic;
        input.Player.Disable();

    }

    private void PlayShoot(InputAction.CallbackContext context)
    {
        PlayAudioEffect(audioShoot);
    }

    private void PlayKill(InputAction.CallbackContext context)
    {
        PlayAudioEffect(audioKill);
    }

    private void PlayDamage(InputAction.CallbackContext context)
    {
        PlayAudioEffect(audioDamage);
    }

    private void PlayHit(InputAction.CallbackContext context)
    {
        PlayAudioEffect(audioHit);
    }

    private void PlayMusic(InputAction.CallbackContext context)
    {
        PlayAudioEffect(audioMusic);
    }
}
