using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapManager : MonoBehaviour
{
    DeathTrap[] DeathTraps;
    public bool isResetting;
    public bool resetDone;
    public bool doOnce1;
    public bool doOnce2;
    public Material DeathTrap_0;
    public Material DeathTrap_1;
    public Material DeathTrap_2;

    // Start is called before the first frame update
    void Start()
    {
        DeathTraps = GetComponents<DeathTrap>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isResetting == true){
            if (!doOnce1)
            {
                DeathPuzzle();
                doOnce1 = true;
            }

        }
        if (resetDone == true)
        {
            if (!doOnce2)
            {
                ResetPuzzle();
                doOnce2 = true;
            }

        }
    }
    
    void DeathPuzzle()
    {
        for (int i = 0; i < DeathTraps.Length; i++)
        {
            DeathTraps[i].gameObject.GetComponent<Renderer>().sharedMaterial = DeathTrap_1;
        }
        Debug.Log("deathtrap_1 new material");
    }

    void ResetPuzzle()
    {
        for (int i = 0; i < DeathTraps.Length; i++)
        {
            DeathTraps[i].gameObject.GetComponent<Renderer>().sharedMaterial = DeathTrap_0;
        }

    }
}
