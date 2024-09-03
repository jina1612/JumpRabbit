using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataBaseManager;

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
        DataBaseManager.SfxData sfxdata = DataBaseManager.Instance.GetSfxData(sfxType);
        sfxAudioSource.volume = sfxdata.volume;
        sfxAudioSource.PlayOneShot(sfxdata.clip);
    }
    public void PlayBgm(Define.BgmType bgmType)
    {
        DataBaseManager.BgmData bgmdata = DataBaseManager.Instance.GetBgmData(bgmType);
        bgmAudioSource.clip = bgmdata.clip;
        bgmAudioSource.volume = bgmdata.volume;
        bgmAudioSource.Play();
    }
}
