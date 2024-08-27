using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("¿¬Ãâ")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopinterval = 0.2f;

    [Header("ÇÃ·¹ÀÌ¾î")]
    public float JumpPowerIncrease = 1;

    [Header("ÇÃ·§Æû")]
    [Tooltip("Å« ÇÃ·§Æû Preb")]public Platform[] LargePlatformArr;
    [Tooltip("Áß°£ ÇÃ·§Æû Preb")] public Platform[] MiddlePlatformArr;
    [Tooltip("ÀÛÀº ÇÃ·§Æû Preb")] public Platform[] SmallPlatformArr;
    [Tooltip("ÇÃ·§Æû ¹èÄ¡ Preb")] public PlatformManager.Data[] DataArr;


    [Tooltip("ÇÃ·§Æû ÃÖ¼Ò °£°Ý")] public float GapIntervaIMin = 1.0f;
    [Tooltip("ÇÃ·§Æû ÃÖ´ë °£°Ý")] public float GapIntervalMax = 2.0f;
    [Tooltip("º¸³Ê½º Ãß°¡ Á¡¼ö")] public float BonusValue = 0.05f;

    public float follwSpeed = 5;


    public void Init()
    {
        Instance = this;
    }
}
