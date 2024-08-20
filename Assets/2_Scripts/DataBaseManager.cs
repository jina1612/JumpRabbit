using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("�÷��̾�")]
    public float JumpPowerIncrease = 1;

    [Header("�÷���")]
    [Tooltip("ū �÷��� Preb")]public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷��� Preb")] public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷��� Preb")] public Platform[] SmallPlatformArr;
    [Tooltip("�÷��� ��ġ Preb")] public PlatformManager.Data[] DataArr;


    [Tooltip("�÷��� �ּ� ����")] public float GapIntervaIMin = 1.0f;
    [Tooltip("�÷��� �ִ� ����")] public float GapIntervalMax = 2.0f;

    public float follwSpeed = 5;


    public void Init()
    {
        Instance = this;
    }
}
