using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RobotAI : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent nav;
    [SerializeField] int patrolPointIndex = 0;

    public float stopDoorTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.hasPath)
            Walk();
        else AllFalseAnim();

        Patrol();
    }
    private void Patrol()
    {
        if (Vector3.Distance(transform.position, Managers.instance.gameplayManager.patrolPointParent.GetChild(patrolPointIndex).position) > 1.0f)
        {
            if (nav.destination != Managers.instance.gameplayManager.patrolPointParent.GetChild(patrolPointIndex).position)
                nav.SetDestination(Managers.instance.gameplayManager.patrolPointParent.GetChild(patrolPointIndex).position);
        }
        else
        {
            if (patrolPointIndex == Managers.instance.gameplayManager.patrolPointParent.childCount - 1) patrolPointIndex = 0;
            else
            {
                patrolPointIndex++;
            }
        }
        if(name =="Robot")
        {
          //  Debug.Log("cc: " + Managers.instance.gameplayManager.patrolPointParent.childCount+  " " + Vector3.Distance(transform.position, Managers.instance.gameplayManager.patrolPointParent.GetChild(patrolPointIndex).position));
        }
        if(patrolPointIndex == Managers.instance.gameplayManager.patrolPointParent.childCount - 2 && Vector3.Distance(transform.position, Managers.instance.gameplayManager.patrolPointParent.GetChild(patrolPointIndex).position) < 10.0f &&
            !Managers.instance.gameplayManager.doorOpen)
        {
            patrolPointIndex = 0;
        }

        if(patrolPointIndex == Managers.instance.gameplayManager.patrolPointParent.childCount - 1)
        {
            stopDoorTime += Time.deltaTime;

            if(stopDoorTime >= 5)
            {
                patrolPointIndex = 0;
            }
        }
    }
    public void AllFalseAnim()
    {
        anim.SetBool("walk", false);
    }
    public void Walk()
    {
        AllFalseAnim();
        anim.SetBool("walk", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndGameTrigger"))
        {
            Managers.instance.gameplayManager.gameOver = true;
        }
    }
}
