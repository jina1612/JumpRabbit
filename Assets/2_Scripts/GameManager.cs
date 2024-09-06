using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject retryBtnObj;

    private void Awake()
    {
        instance = this;
        dataBaseManager.Init();

        player.Init();
        platformManager.Init();
        cameraManager.Init();
        scoreManager.Init();
        soundManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
        scoreManager.Active();
        soundManager.PlayBgm(Define.BgmType.Main);
    }

    public void CallBtnRetry()
    {
        SceneManager.LoadScene(0);
    }
    public void OnGameOver()
    {
        retryBtnObj.SetActive(true);
    }
}
