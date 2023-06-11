using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject openDoorButton;
    public GameObject openCloseButtons;
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
        }
        else
        {
            Managers.instance.gameplayManager.doors[0].SetTrigger("close");
            Managers.instance.gameplayManager.doors[1].SetTrigger("close");
        }
    }
    public void CloseButton()
    {
        switch(Managers.instance.gameplayManager.actionId)
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
    public void OpenButton()
    {
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
}
