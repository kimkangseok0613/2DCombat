using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using UnityEngine;

public class SoundManager : SingleTon<SoundManager>
{
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource bgmAudioSource;

    public void PlaySfxClip(AudioClip clip, float volume)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.volume = volume;
        sfxAudioSource.PlayOneShot(clip);
    }
    
    public void PlaySFXFromString(string soundClipName,float volume)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Sound/Enemy/Hurt/{soundClipName}");
        sfxAudioSource.clip = clip;
        sfxAudioSource.volume = volume;
        sfxAudioSource.PlayOneShot(clip);
    }

}
