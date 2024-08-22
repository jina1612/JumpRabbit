using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        dataBaseManager.Init();

        player.Init();
        platformManager.Init();
        cameraManager.Init();
        scoreManager.Init();

    }

    private void Start()
    {
        platformManager.Active();

        int a = 123456;
        Debug.Log("Extension Test int : " + a.ToString());

        float b = 123456.789f;
        Debug.Log("Extension Test float : " + b.ToFormatString(1));
        Debug.Log("Extension Test float : " + b.ToFormatString(2));
        Debug.Log("Extension Test float : " + b.ToFormatString(3));
    }
}
