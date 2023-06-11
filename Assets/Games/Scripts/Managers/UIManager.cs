using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject openDoorButton;
    public GameObject openCloseButtons;

    public Image waterBar;
    public Image oxygenBar;
    // Start is called before the first frame update
    void Start()
    {
        
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
}

/*
 Music by Eric Matyas

www.soundimage.org
 */