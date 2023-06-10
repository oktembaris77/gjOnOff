using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrMove : MonoBehaviour
{
    public GameObject character;
    public Animator anim;
    public float speed = 1.0f;
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
            if (transform.position.z >= 35.68f) return;
            Run();
            transform.Translate(0, 0, speed * Time.deltaTime);
            character.transform.eulerAngles = Vector3.Lerp(character.transform.eulerAngles, new Vector3(character.transform.eulerAngles.x, 0, character.transform.eulerAngles.z), 5 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.z <= -35.81f) return;
            Run();
            transform.Translate(0, 0, -speed * Time.deltaTime);
            character.transform.eulerAngles = Vector3.Lerp(character.transform.eulerAngles, new Vector3(character.transform.eulerAngles.x, 180, character.transform.eulerAngles.z), 5 * Time.deltaTime);
        }
        else
        {
            FalseAllAnim();
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
    private void FalseAllAnim()
    {
        anim.SetBool("run", false);
    }
    private void Run()
    {
        anim.SetBool("run", true);
    }
}
