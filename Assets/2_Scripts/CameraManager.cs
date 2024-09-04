using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public static CameraManager Instance;

    [SerializeField] private SpriteRenderer bgSrdr;
    float cameraWidth;

    public void Init()
    {
        Instance = this;
        Camera camera = Camera.main;
        float cameraHeigh = camera.orthographicSize * 2f;
        cameraWidth = cameraHeigh * camera.aspect;
    }

    public void OnFollow(Vector2 targetPos)
    {
        StartCoroutine(OnFollowCor(targetPos));
    }
  
    private IEnumerator OnFollowCor(Vector2 targetPos)
    {
        while (0.1f < Vector3.Distance(transform.position, targetPos))
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * DataBaseManager.Instance.follwSpeed);

            float bgRightX = bgSrdr.transform.position.x + bgSrdr.size.x;
            float cmaerRightX = Camera.main.transform.position.x + cameraWidth / 2;

            if(bgRightX < cmaerRightX)
            {
                bgSrdr.size = new Vector2 (bgSrdr.size.x + cameraWidth, bgSrdr.size.y);
            }
            yield return null;
        }
    }
}
