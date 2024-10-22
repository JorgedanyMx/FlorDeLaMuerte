using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameEvent pauseEnable;
    [SerializeField] private GameEvent pauseDisable;
    private GameObject pauseCanvasObj;
    private GameObject pausePanelObj;
    private GameObject SettingsPanelObj;
    private GameObject ConfirmPanelObj;
    private PauseState pauseState = PauseState.Resume;
    AudioSource audioSource;

    private enum PauseState : int 
    {
        Pause = 0,
        Settings = 1,
        Confirm = 2,
        Resume = 3
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InitOBJ();
        SetPanel();
        pauseCanvasObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) )
        {
            if(pauseState == PauseState.Resume)PauseGame();
            else if (pauseState == PauseState.Pause) ResumeGame();
        }

    }

    public void OnClickContinue()
    {
        Debug.Log("Continue");
        ResumeGame();
    }

    public void OnClickSettings()
    {
        Debug.Log("Settings");
        SettingsGame();
    }

    public void OnClickHome()
    {
        Debug.Log("Home");
        ConfirmGame();
    }

    public void OnClickYes()
    {
        Debug.Log("Yes");
        ExitGame();
    }

    public void OnClickNo()
    {
        Debug.Log("No");
        PauseGame();
    }

    public void OnSlideSFXVolume(Slider slider)
    {
        Debug.Log("SFX Volume: " + slider.value);
    }

    public void OnSlideMusicVolume(Slider slider)
    {
        Debug.Log("Music Volume: " + slider.value);
    }

    private void InitOBJ()
    {
        pauseCanvasObj = transform.Find("PauseCanvas").gameObject;
        pausePanelObj = pauseCanvasObj.transform.Find("PausePanel").gameObject;
        SettingsPanelObj = pauseCanvasObj.transform.Find("SettingsPanel").gameObject;
        ConfirmPanelObj = pauseCanvasObj.transform.Find("ConfirmPanel").gameObject;
    }

    private void PauseGame()
    {
        pauseState = PauseState.Pause;
        Time.timeScale = 0;
        pauseCanvasObj.SetActive(true);
        pauseEnable.Raise();
        audioSource.UnPause();
        SetPanel();     
    }

    private void SettingsGame()
    {
        pauseState = PauseState.Settings;
        SetPanel();
    }

    private void ConfirmGame()
    {
        pauseState = PauseState.Confirm;
        SetPanel();
    }
    private void ResumeGame()
    {
        pauseState = PauseState.Resume;
        SetPanel();
        pauseCanvasObj.SetActive(false);
        Time.timeScale = 1;
        pauseDisable.Raise();
    }

    private void SetPanel()
    {	
        switch(pauseState)
        {
            case PauseState.Pause:
                pausePanelObj.SetActive(true);
                SettingsPanelObj.SetActive(false);
                ConfirmPanelObj.SetActive(false);
                break;
            case PauseState.Settings:
                pausePanelObj.SetActive(false);
                SettingsPanelObj.SetActive(true);
                ConfirmPanelObj.SetActive(false);
                break;
            case PauseState.Confirm:
                pausePanelObj.SetActive(false);
                SettingsPanelObj.SetActive(false);
                ConfirmPanelObj.SetActive(true);
                break;
            case PauseState.Resume:
                pausePanelObj.SetActive(false);
                SettingsPanelObj.SetActive(false);
                ConfirmPanelObj.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void PlaySoundSFX()
    {
        audioSource.Play();
    }

    private void ExitGame()
    {
        Application.Quit();
        SceneManager.LoadScene(0);
    }
}
