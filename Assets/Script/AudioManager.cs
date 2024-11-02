using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioSource background;

    public AudioSource SFX;

    public GameSFX gameSFX;

    private void Start()
    {
        PlayMusic(gameSFX.BgMusic);
    }

    public void PlayMusic(AudioClip music) {

        background.clip = music;

        background.Play();
    }

    public void PlaySFX(AudioClip music)
    {

        SFX.PlayOneShot(music);
    }


}
