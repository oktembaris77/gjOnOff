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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosControl();
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
    IEnumerator CameraPosUpdate()
    {
        while(true)
        {
            if(cameraSide)
            {
                cameraObj.transform.position = Vector3.MoveTowards(cameraObj.transform.position, insideCameraPos.position,50 * Time.deltaTime);
                cameraObj.transform.eulerAngles = Vector3.MoveTowards(cameraObj.transform.eulerAngles, insideCameraPos.eulerAngles, 50 * Time.deltaTime);
            }
            else
            {
                cameraInside = false;
                cameraObj.transform.position = Vector3.MoveTowards(cameraObj.transform.position, outsideCameraPos.position, 50 * Time.deltaTime);
                cameraObj.transform.eulerAngles = Vector3.MoveTowards(cameraObj.transform.eulerAngles, outsideCameraPos.eulerAngles, 50 * Time.deltaTime);
            }

            if((cameraSide && Vector3.Distance(cameraObj.transform.position, insideCameraPos.position) <= 1) || (!cameraSide && Vector3.Distance(cameraObj.transform.position, outsideCameraPos.position) <= 1))
            {
                if (cameraSide) cameraInside = true;

                StopCoroutine("CameraPosUpdate");
            }

            yield return null;
        }
    }
}