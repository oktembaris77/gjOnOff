using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RobotAI : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent nav;
    [SerializeField] int patrolPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.hasPath)
            Walk();

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
}
