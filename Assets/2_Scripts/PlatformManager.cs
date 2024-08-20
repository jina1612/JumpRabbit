using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [SerializeField] private float LargePercent;
        [SerializeField] private float MiddlePercent;
        [SerializeField] private float SmallPercent;

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
    [SerializeField] private Platform[] LargePlatformArr;
    [SerializeField] private Platform[] MiddlePlatformArr;
    [SerializeField] private Platform[] SmallPlatformArr;
    [SerializeField] private Data[] DataArr;
    private int platformNum = 0;

    [SerializeField] private float GapIntervaIMin = 1.0f;
    [SerializeField] private float GapIntervalMax = 2.0f;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();

    internal void Init()
    {
        PlatformArrDic.Add(0, LargePlatformArr);
        PlatformArrDic.Add(1, MiddlePlatformArr);
        PlatformArrDic.Add(2, SmallPlatformArr);
    }
    internal void Active()
    {
        Vector3 pos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataArr)
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

        if (platformNum != 0)
            pos = pos + Vector3.right * platform.HalfSizeX;

        platform.Active(pos);

        float gap = Random.Range(GapIntervaIMin, GapIntervalMax);
        pos = pos + Vector3.right * (platform.HalfSizeX + gap);
        return pos;
    }
}
