using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;
    [System.Serializable]
    public class Data
    {
        [Tooltip("ÇÃ·§Æû ±×·ì °¹¼ö")] public int GroupCount;
        [Tooltip("Å« ÇÃ·§Æû ºñÀ²(0~1.0"), Range(0, 1f)][SerializeField] private float LargePercent;
        [Tooltip("Áß°£ ÇÃ·§Æû ºñÀ²(0~1.0"), Range(0, 1f)][SerializeField] private float MiddlePercent;
        [Tooltip("ÀÛÀº ÇÃ·§Æû ºñÀ²(0~1.0"), Range(0, 5f)][SerializeField] private float SmallPercent;

        public int GetPlatformID()
        {
            float randVal = Random.value;
            int platformID;
            if (randVal <= LargePercent)
            {
                platformID = 0;
            }
            else if (randVal <= LargePercent + MiddlePercent)
            {
                platformID = 1;
            }
            else
            {
                platformID = 2;
            }

            return platformID;
        }

    }

    [SerializeField] private Transform spawnPosTrf;
    private Vector3 spawnPos;
    private int platformNum = 0;
    private Data LastData;
    public int LandingPlatformNum;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();

    internal void Init()
    {
        instance = this;

        PlatformArrDic.Add(0, DataBaseManager.Instance.LargePlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.SmallPlatformArr);
    }

    public void Update()
    {
        Debug.Log($"platformNum:{platformNum}, LandingPlatformNum:{LandingPlatformNum}, remainPlatformCount:{DataBaseManager.Instance.remainPlatformCount}");
        if (platformNum - LandingPlatformNum < DataBaseManager.Instance.remainPlatformCount)
        {
            int lastIndex = DataBaseManager.Instance.DataArr.Length - 1;
            Data lastData = DataBaseManager.Instance.DataArr[lastIndex];

            for (int i = 0; i < lastData.GetPlatformID(); i++)
            {
                int platformID = lastData.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }
    internal void Active()
    {
        spawnPos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;
            while (platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }

    private void ActiveOne(int platformID)
    {
        platformNum++;
        Platform[] Platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, Platforms.Length);
        Platform randomPlatform = Platforms[randID];
        Debug.Log($"Platform [{platformID}, {randID}]");

        Platform platform = Instantiate(randomPlatform);

        if (platformNum > 1)
            spawnPos = spawnPos + Vector3.right * platform.HalfSizeX;

        platform.Active(spawnPos, platformNum);

        float gap = Random.Range(DataBaseManager.Instance.GapIntervaIMin, DataBaseManager.Instance.GapIntervalMax);
        spawnPos = spawnPos + Vector3.right * (platform.HalfSizeX + gap);
        return;
    }
}
