using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float follwSpeed = 5;
    public static CameraManager Instance;

    public void Init()
    {
        Instance = this;
    }

    public void OnFollow(Vector2 targetPos)
    {
        StartCoroutine(OnFollowCor(targetPos));
    }
  
    private IEnumerator OnFollowCor(Vector2 targetPos)
    {
        while (0.1f < Vector3.Distance(transform.position, targetPos))
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * follwSpeed);
            yield return null;
        }
    }
}
