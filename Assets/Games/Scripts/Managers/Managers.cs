using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers instance;

    public GameplayManager gameplayManager;
    public UIManager uiManager;
    public SoundManager soundManager;

    private void Awake()
    {
        instance = this;

        TryGetComponent(out gameplayManager);
        TryGetComponent(out uiManager);
        TryGetComponent(out soundManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
