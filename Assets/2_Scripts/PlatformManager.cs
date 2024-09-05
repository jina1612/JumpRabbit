using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        [Tooltip("ÇÃ·§Æû ±×·ì °¹¼ö")]public int GroupCount;
        [Tooltip("Å« ÇÃ·§Æû ºñÀ²(0~1.0"), Range(0,1f)][SerializeField] private float LargePercent;
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
    
    private int platformNum = 0;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();

    internal void Init()
    {
        PlatformArrDic.Add(0, DataBaseManager.Instance.LargePlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.SmallPlatformArr);
    }
    internal void Active()
    {
        Vector3 pos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;

            while (platformNum < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                pos = ActiveOne(pos, platformID);
                platformNum++;
            }
        }
    }

    private Vector3 ActiveOne(Vector3 pos, int platformID)
    {
        Platform[] Platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, Platforms.Length);
        Platform randomPlatform = Platforms[randID];
        Debug.Log($"Platform [{platformID}, {randID}]");

        Platform platform = Instantiate(randomPlatform);

        bool isFirstFrame = platformNum == 0;
        if (isFirstFrame ==  false)
            pos = pos + Vector3.right * platform.HalfSizeX;

        platform.Active(pos, isFirstFrame);

        float gap = Random.Range(DataBaseManager.Instance.GapIntervaIMin, DataBaseManager.Instance.GapIntervalMax);
        pos = pos + Vector3.right * (platform.HalfSizeX + gap);
        return pos;
    }
}
