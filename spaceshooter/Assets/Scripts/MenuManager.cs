using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [Header("Menu")]
    public GameObject menuUI;
    public CanvasGroup canvasGroup;

    [Header("Animation")]
    public float animDuration = 0.25f;

    private bool isOpen = false;
    private Tween currentTween;

    void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       
        if (SceneManager.GetActiveScene().name == "Menu")
            OpenMenuInstant();
        else
            CloseMenuInstant();
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isOpen)
                CloseMenu();
            else
                OpenMenu();
        }
    }

  
    public void OpenMenu()
    {
        currentTween?.Kill();

        menuUI.SetActive(true);
        isOpen = true;

      
        if (SceneManager.GetActiveScene().name != "Menu")
            Time.timeScale = 0f;

        canvasGroup.alpha = 0f;
        menuUI.transform.localScale = Vector3.one * 0.5f;

        currentTween = DOTween.Sequence()
            .SetUpdate(true)
            .Append(canvasGroup.DOFade(1f, animDuration))
            .Join(menuUI.transform.DOScale(0.5f, animDuration).SetEase(Ease.OutBack));
    }

   
    public void CloseMenu()
    {
        currentTween?.Kill();

        isOpen = false;

        currentTween = DOTween.Sequence()
            .SetUpdate(true)
            .Append(canvasGroup.DOFade(0f, animDuration))
            .Join(menuUI.transform.DOScale(0.5f, animDuration).SetEase(Ease.InBack))
            .OnComplete(() =>
            {
                menuUI.SetActive(false);
                Time.timeScale = 1f;
            });
    }

   
    void OpenMenuInstant()
    {
        menuUI.SetActive(true);
        canvasGroup.alpha = 1f;
        menuUI.transform.localScale = Vector3.one * 0.5f;
        Time.timeScale = 1f;
        isOpen = true;
    }

   
    void CloseMenuInstant()
    {
        menuUI.SetActive(false);
        canvasGroup.alpha = 0f;
        menuUI.transform.localScale = Vector3.one * 0.5f;
        Time.timeScale = 1f;
        isOpen = false;
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {       
        Application.Quit();
    }
}