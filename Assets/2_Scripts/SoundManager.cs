using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    public void Init()
    {
        instance = this;
    }

    public void PlaySfx(Define.SfxType sfxType)
    {
        AudioClip audioClip = DataBaseManager.Instance.GetSfxAudioClip(sfxType);
        sfxAudioSource.PlayOneShot(audioClip);
    }
}
