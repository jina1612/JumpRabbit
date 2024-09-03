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

    [Header("������")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBonus = 0.25f;
 
    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;

    [Header("�÷���")]
    [Tooltip("ū �÷��� Preb")] public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷��� Preb")] public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷��� Preb")] public Platform[] SmallPlatformArr;
    [Tooltip("�÷��� ��ġ Preb")] public PlatformManager.Data[] DataArr;


    [Tooltip("�÷��� �ּ� ����")] public float GapIntervaIMin = 1.0f;
    [Tooltip("�÷��� �ִ� ����")] public float GapIntervalMax = 2.0f;
    [Tooltip("���ʽ� �߰� ����")] public float BonusValue = 0.05f;

    [Header("ī�޶�")]
    public float follwSpeed = 5;

    [Header("����")]
    public SfxData[] sfxDataArr;
    private Dictionary<Define.SfxType, SfxData> sfxDataDic = new Dictionary<Define.SfxType, SfxData>();

    public void Init()
    {
        Instance = this;

        foreach (SfxData data in sfxDataArr)
        {
            sfxDataDic.Add(data.sfxType, data);
        }
    }

    public SfxData GetSfxData(Define.SfxType type)
    {
        return sfxDataDic[type];
    }


    [System.Serializable]
    public class SfxData
    {
        public Define.SfxType sfxType;
        public AudioClip clip;
    }
}
