using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("����")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopinterval = 0.2f;
    public Effect effect;

    [Header("������")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus = 0.25f;
 
    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;
    public float GameOverYHeight = -7f;
    public float minJumpPower = 300f;
    public float maxJumpPower = 500f;

    [Header("�÷���")]
    [Tooltip("ū �÷��� Preb")] public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷��� Preb")] public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷��� Preb")] public Platform[] SmallPlatformArr;
    [Tooltip("�÷��� ��ġ Preb")] public PlatformManager.Data[] DataArr;


    [Tooltip("�÷��� �ּ� ����")] public float GapIntervaIMin = 1.0f;
    [Tooltip("�÷��� �ִ� ����")] public float GapIntervalMax = 2.0f;
    [Tooltip("���ʽ� �߰� ����")] public float BonusValue = 0.05f;
    public int remainPlatformCount = 5;

    [Header("ī�޶�")]
    public float follwSpeed = 5;

    [Header("����")]
    public SfxData[] sfxDataArr;
    public BgmData[] bgmDataArr;
    private Dictionary<Define.SfxType, SfxData> sfxDataDic;
    private Dictionary<Define.BgmType, BgmData> bgmDataDic;

    public void Init()
    {
        Instance = this;

        sfxDataDic = new Dictionary<Define.SfxType, SfxData>();
        foreach (SfxData data in sfxDataArr)
        {
            sfxDataDic.Add(data.sfxType, data);
        }

        bgmDataDic = new Dictionary<Define.BgmType, BgmData>();
        foreach (BgmData data in bgmDataArr)
        { 
            bgmDataDic.Add(data.bgmType, data);
        }
        
    }

    public SfxData GetSfxData(Define.SfxType type)
    {
        return sfxDataDic[type];
    }

    public BgmData GetBgmData(Define.BgmType type)
    {
        return bgmDataDic[type];
    }
    [System.Serializable]
    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1f;
    }

    [System.Serializable]
    public class SfxData : SoundData
    {
        public Define.SfxType sfxType;
    }

    [System.Serializable]
    public class BgmData : SoundData
    {
        public Define.BgmType bgmType;
    }
}
