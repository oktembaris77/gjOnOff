using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject cameraObj;
    public Transform outsideCameraPos;
    public Transform insideCameraPos;

    public bool cameraSide = false;
    public bool cameraInside = false;

    public GameObject outsideLights;

    public GameObject shalterCeil;

    //Robot patrol points
    public Transform patrolPointParent;

    //Door
    public Transform doorPos;
    public Animator[] doors;
    public bool doorOpen = false;

    //Positions
    public Transform waterTank;
    public Transform oxygenTank;
    public Transform oxygenPipes;

    //Repair
    public bool waterPipesBroken = false; //no water pipes!! -> Electric fuse !!
    public bool oxygenTankBroken = false;
    public bool waterTankBroken = false;

    public float waterPipesTime = 0.0f;
    public float oxygenTankTime = 0.0f;
    public float waterTankTime = 0.0f;

    public float doorTime = 0.0f;
    public int actionId = -1;
    public GameObject[] warnings;
    public float time = 0.0f;

    //

    private bool killSound = false;

    public float water = 100;
    public float oxygen = 100;

    public bool gameOver = false;

    public bool pauseGame = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        StartCoroutine("WaterPipesBroken");
        StartCoroutine("OxygenBroken");
        StartCoroutine("WaterTankBroken");
        StartCoroutine("DoorBroken");

        shalterCeil.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOver) return;

            pauseGame = !pauseGame;

            if (pauseGame) Time.timeScale = 0;
            else Time.timeScale = 1;
            Managers.instance.uiManager.pausePanel.SetActive(pauseGame);
        }
        if (gameOver)
        {
            ChrMove.instance.Die();

            if (!killSound )
            {
                Managers.instance.soundManager.PlayOneShotSound(5, Managers.instance.soundManager.effect4as);
                killSound = true;
            }

            Managers.instance.uiManager.endPanel.SetActive(true);
            Managers.instance.uiManager.timeText.text = "Time: " + Mathf.FloorToInt(time);
            Time.timeScale = 0;
        }

        time += Time.deltaTime;

        EndGame();

        if (gameOver) return;
        CameraPosControl();
        WarningsActivity();
        ResourceUpdate();
        BarUpdate();

        if(Input.GetKeyDown(KeyCode.M))
        {
            oxygen = 100;
            water = 100;

        }
    }
    private void CameraPosControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraSide = !cameraSide;

            StopCoroutine("CameraPosUpdate");
            StartCoroutine("CameraPosUpdate");
        }
    }
    private void WarningsActivity()
    {
        warnings[0].SetActive(waterPipesBroken);
        warnings[1].SetActive(oxygenTankBroken);
        warnings[2].SetActive(waterTankBroken);
    }
    private void ResourceUpdate()
    {
            if (!waterTankBroken && !waterPipesBroken)
                water += Time.deltaTime * 7;
            else water -= Time.deltaTime * 7;

            if (!oxygenTankBroken && !waterPipesBroken)
                oxygen += Time.deltaTime * 7;
            else oxygen -= Time.deltaTime * 7;
    }
    private void BarUpdate()
    {
        Managers.instance.uiManager.waterBar.GetComponent<RectTransform>().sizeDelta = new Vector2(22.168f, water * 269.7f / 100);
        Managers.instance.uiManager.oxygenBar.GetComponent<RectTransform>().sizeDelta = new Vector2(22.168f, oxygen * 269.7f / 100);
    }
    private void EndGame()
    {
        if(water >= 180 || oxygen >= 180 || water <= 0 || oxygen <= 0)
        {
            gameOver = true;
        }
    }
    IEnumerator CameraPosUpdate()
    {
        while (true)
        {
            if (cameraSide)
            {
                cameraObj.transform.position = Vector3.MoveTowards(cameraObj.transform.position, insideCameraPos.position, 80 * Time.deltaTime);
                cameraObj.transform.eulerAngles = Vector3.MoveTowards(cameraObj.transform.eulerAngles, insideCameraPos.eulerAngles, 80 * Time.deltaTime);
            }
            else
            {
                shalterCeil.SetActive(false);
                cameraInside = false;
                outsideLights.SetActive(true);
                cameraObj.transform.position = Vector3.MoveTowards(cameraObj.transform.position, outsideCameraPos.position, 80 * Time.deltaTime);
                cameraObj.transform.eulerAngles = Vector3.MoveTowards(cameraObj.transform.eulerAngles, outsideCameraPos.eulerAngles, 80 * Time.deltaTime);
            }

            if ((cameraSide && Vector3.Distance(cameraObj.transform.position, insideCameraPos.position) <= 1) || (!cameraSide && Vector3.Distance(cameraObj.transform.position, outsideCameraPos.position) <= 1))
            {
                if (cameraSide)
                {
                    cameraInside = true;
                    outsideLights.SetActive(false);
                    shalterCeil.SetActive(true);
                }
                else
                {

                }


                StopCoroutine("CameraPosUpdate");
            }

            yield return null;
        }
    }

    //Repair
    IEnumerator WaterPipesBroken()
    {
        while (true)
        {
            Debug.Log("zaten bozuk");
            if (waterPipesBroken)
            {
                yield return null;
                continue;
            }

            waterPipesTime = Random.Range(5, 10);
            yield return new WaitForSeconds(waterPipesTime);
            Debug.Log("bozuldu " + waterPipesTime);
            waterPipesBroken = true;

            yield return null;
        }
    }
    IEnumerator OxygenBroken()
    {
        while (true)
        {
            if (oxygenTankBroken)
            {
                yield return null;
                continue;
            }

            oxygenTankTime = Random.Range(5, 10);
            yield return new WaitForSeconds(oxygenTankTime);
            oxygenTankBroken = true;

            yield return null;
        }
    }
    IEnumerator WaterTankBroken()
    {
        while (true)
        {
            if (waterTankBroken)
            {
                yield return null;
                continue;
            }

            waterTankTime = Random.Range(5, 10);
            yield return new WaitForSeconds(waterTankTime);
            waterTankBroken = true;

            yield return null;
        }
    }
    IEnumerator DoorBroken()
    {
        while (true)
        {
            if (doorOpen)
            {
                yield return null;
                continue;
            }

            doorTime = Random.Range(5, 15);
            yield return new WaitForSeconds(doorTime);

            if (!Managers.instance.gameplayManager.doorOpen)
                Managers.instance.uiManager.CloseDoorButton();

            yield return null;
        }
    }
}
