using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject openDoorButton;
    public GameObject openCloseButtons;

    public Image waterBar;
    public Image oxygenBar;

    public GameObject creditsPanel;
    public Slider soundSlider;
    public AudioSource mainMenuAS;

    public GameObject pausePanel;
    public GameObject endPanel;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("soundvolume") == 0.0f)
            PlayerPrefs.SetFloat("soundvolume", 0.2f);

        if (mainMenuAS != null)
        {
            mainMenuAS.volume = PlayerPrefs.GetFloat("soundvolume");
            soundSlider.value = PlayerPrefs.GetFloat("soundvolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CloseDoorButton()
    {
        Managers.instance.gameplayManager.doorOpen = !Managers.instance.gameplayManager.doorOpen;

        if (Managers.instance.gameplayManager.doorOpen)
        {
            Managers.instance.gameplayManager.doors[0].SetTrigger("open");
            Managers.instance.gameplayManager.doors[1].SetTrigger("open");
            Managers.instance.soundManager.PlayOneShotSound(1, Managers.instance.soundManager.effect2as);
        }
        else
        {
            openDoorButton.SetActive(false);
            Managers.instance.gameplayManager.doors[0].SetTrigger("close");
            Managers.instance.gameplayManager.doors[1].SetTrigger("close");
            Managers.instance.soundManager.PlayOneShotSound(2, Managers.instance.soundManager.effect2as);
        }
    }
    public void CloseButton()
    {
        Managers.instance.soundManager.PlayOneShotSound(4, Managers.instance.soundManager.effect3as);
        switch (Managers.instance.gameplayManager.actionId)
        {
            case 0:
                Managers.instance.gameplayManager.waterPipesBroken = true;
                break;
            case 1:
                Managers.instance.gameplayManager.oxygenTankBroken = true;
                break;
            case 2:
                Managers.instance.gameplayManager.waterTankBroken = true;
                break;
        }
    }
    public void OpenButton()
    {
        Managers.instance.soundManager.PlayOneShotSound(3, Managers.instance.soundManager.effect3as);
        switch (Managers.instance.gameplayManager.actionId)
        {
            case 0:
                Managers.instance.gameplayManager.waterPipesBroken = false;
                break;
            case 1:
                Managers.instance.gameplayManager.oxygenTankBroken = false;
                break;
            case 2:
                Managers.instance.gameplayManager.waterTankBroken = false;
                break;
        }
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void GotoMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void CreditsButton(bool act)
    {
        creditsPanel.SetActive(act);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void SoundVolume()
    {
        PlayerPrefs.SetFloat("soundvolume", soundSlider.value);
        mainMenuAS.volume = soundSlider.value;
    }
}

/*
 Music by Eric Matyas

www.soundimage.org
 */