using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource effect1as;
    public AudioSource effect2as;
    public AudioSource effect3as;

    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayOneShotSound(int clipIndex, AudioSource aus)
    {
        if(!aus.isPlaying)
        {
            aus.PlayOneShot(clips[clipIndex]);
        }
    }
}
