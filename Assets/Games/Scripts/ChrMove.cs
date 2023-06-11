using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrMove : MonoBehaviour
{
    public static ChrMove instance;
    public GameObject character;
    public Animator anim;
    public float speed = 1.0f;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
    }
    private void MoveUpdate()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            //if (!Managers.instance.gameplayManager.cameraInside) return;

            if (transform.position.z >= -8.799999) return;
            Run();
            transform.Translate(0, 0, speed * Time.deltaTime);
            character.transform.eulerAngles = Vector3.MoveTowards(character.transform.eulerAngles, new Vector3(character.transform.eulerAngles.x, 0, character.transform.eulerAngles.z), 500 * Time.deltaTime);
            Managers.instance.soundManager.PlayOneShotSound(0, Managers.instance.soundManager.effect1as);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //if (!Managers.instance.gameplayManager.cameraInside) return;

            if (transform.position.z <= -81.1f) return;
            Run();
            transform.Translate(0, 0, -speed * Time.deltaTime);
            character.transform.eulerAngles = Vector3.MoveTowards(character.transform.eulerAngles, new Vector3(character.transform.eulerAngles.x, 180, character.transform.eulerAngles.z), 500 * Time.deltaTime);
            Managers.instance.soundManager.PlayOneShotSound(0, Managers.instance.soundManager.effect1as);
        }
        else
        {
            FalseAllAnim();
        }

        //Positions
        if(Vector3.Distance(transform.position, Managers.instance.gameplayManager.doorPos.position) <= 8)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(Managers.instance.gameplayManager.doorOpen)
                Managers.instance.uiManager.CloseDoorButton();
            }

            if (Managers.instance.gameplayManager.doorOpen)
                Managers.instance.uiManager.openDoorButton.SetActive(true);
        }
        else
        {
            Managers.instance.uiManager.openDoorButton.SetActive(false);
        }

        Debug.Log("water tank: " + Vector3.Distance(transform.position, Managers.instance.gameplayManager.waterTank.position));
        //Water Tank
        if (Vector3.Distance(transform.position, Managers.instance.gameplayManager.waterTank.position) <= 8)
        {
            Managers.instance.gameplayManager.actionId = 2;

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!Managers.instance.gameplayManager.waterTankBroken)
                    Managers.instance.uiManager.CloseButton();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Managers.instance.gameplayManager.waterTankBroken)
                    Managers.instance.uiManager.OpenButton();
            }


            if (true || Managers.instance.gameplayManager.waterTankBroken)
            {
                Managers.instance.uiManager.openCloseButtons.SetActive(true);
                return;
            }
        }
        else
        {
            Managers.instance.uiManager.openCloseButtons.SetActive(false);
        }

        //Oxygen Tank
        if (Vector3.Distance(transform.position, Managers.instance.gameplayManager.oxygenTank.position) <= 8)
        {
            Managers.instance.gameplayManager.actionId = 1;

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!Managers.instance.gameplayManager.oxygenTankBroken)
                    Managers.instance.uiManager.CloseButton();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Managers.instance.gameplayManager.oxygenTankBroken)
                    Managers.instance.uiManager.OpenButton();
            }


            if (true || Managers.instance.gameplayManager.oxygenTankBroken)
            {
                Managers.instance.uiManager.openCloseButtons.SetActive(true);
                return;
            }
        }
        else
        {
            Managers.instance.uiManager.openCloseButtons.SetActive(false);
        }

        //Oxygen Pipes
        if (Vector3.Distance(transform.position, Managers.instance.gameplayManager.oxygenPipes.position) <= 8)
        {
            Managers.instance.gameplayManager.actionId = 0;

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!Managers.instance.gameplayManager.waterPipesBroken)
                    Managers.instance.uiManager.CloseButton();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Managers.instance.gameplayManager.waterPipesBroken)
                    Managers.instance.uiManager.OpenButton();
            }


            if (true || Managers.instance.gameplayManager.waterPipesBroken)
            {
                Managers.instance.uiManager.openCloseButtons.SetActive(true);
                return;
            }
        }
        else
        {
            Managers.instance.uiManager.openCloseButtons.SetActive(false);
        }
    }
    IEnumerator Move(int turn)
    {
        while (true)
        {
            if (turn == 1)
            {

            }
            else if (turn == 2)
            {

            }

            yield return null;
        }
    }
    public void FalseAllAnim()
    {
        anim.SetBool("run", false);
    }
    private void Run()
    {
        anim.SetBool("run", true);
    }
    public void Die()
    {
        FalseAllAnim();
        anim.SetBool("die", true);
    }
}
