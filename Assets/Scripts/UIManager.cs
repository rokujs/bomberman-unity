using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject settingMenu;
    [SerializeField] GameObject tutorialMenu;
    [SerializeField] Dropdown dropdownMenu;
    [SerializeField] Toggle btnScreen;
    [SerializeField] Dropdown levelShadow;
    [SerializeField] Dropdown levelAntialiasing;
    [SerializeField] Toggle btnProcessing;
    [SerializeField] Text levelQuality;
    [SerializeField] PostProcessLayer postGame;

    private void Start()
    {
        startMenu.SetActive(true);
        settingMenu.SetActive(false);
        tutorialMenu.SetActive(false);

        btnScreen.isOn = Screen.fullScreen;

        btnProcessing.isOn = postGame.enabled;

        levelQuality.text = "" + QualitySettings.GetQualityLevel();

        Screen.SetResolution(1280, 720, false);
    }

    // Bottons of start menu

    public void btnStart()
    {
        SceneManager.LoadScene("Menu_inicio");
    }
    public void btnTutorial()
    {
        startMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }
    public void btnSetting()
    {
        startMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
    public void btnExit()
    {
        Application.Quit();
    }

    // tutorial

    public void backTutorial()
    {
        tutorialMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    // Setting

    public void backSetting()
    {
        settingMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void screenResolution()
    {
        switch (dropdownMenu.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(800, 450, Screen.fullScreen);
                break;
        }
    }

    public void btnFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void dropdownShadow()
    {
        switch (levelShadow.value)
        {
            case 0:
                QualitySettings.shadows = ShadowQuality.All;
                break;
            case 1:
                QualitySettings.shadows = ShadowQuality.HardOnly;
                break;
            case 2:
                QualitySettings.shadows = ShadowQuality.Disable;
                break;
        }
    }

    public void dropdownAntialiasing()
    {
        switch (levelAntialiasing.value)
        {
            case 0:
                QualitySettings.antiAliasing = 0;
                break;
            case 1:
                QualitySettings.antiAliasing = 2;
                break;
            case 2:
                QualitySettings.antiAliasing = 4;
                break;
            case 3:
                QualitySettings.antiAliasing = 8;
                break;
        }
    }

    public void btnQualityUp()
    {
        QualitySettings.IncreaseLevel();
        levelQuality.text = "" + QualitySettings.GetQualityLevel();
    }

    public void btnQualityDown()
    {
        QualitySettings.DecreaseLevel();
        levelQuality.text = "" + QualitySettings.GetQualityLevel();
    }
    public void btnPostProcessing()
    {
        postGame.enabled = !postGame.enabled;
    }
}
