using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapManager : MonoBehaviour
{
    public DeathTrap[] DeathTraps;
    public Material DeathTrap_0;
    public Material DeathTrap_1;
    public Material DeathTrap_2;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        DeathTraps = GetComponentsInChildren<DeathTrap>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void DeathPuzzle()
    {
        if (isDead) { return; }
        isDead = true;
        //All tiles in array to red texture
        for (int i = 0; i < DeathTraps.Length; i++)
        {
            DeathTraps[i].gameObject.GetComponent<Renderer>().material = DeathTrap_1;
        }
        Debug.Log("deathtrap_1 new material");
    }

    void ResetPuzzle()
    {
        // All tiles in array to standard texture
        for (int i = 0; i < DeathTraps.Length; i++)
        {
            DeathTraps[i].gameObject.GetComponent<Renderer>().material = DeathTrap_0;
        }
        isDead = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            ResetPuzzle();
        }
       
    }

    public void PuzzleSolved()
    {
        for (int i = 0; i < DeathTraps.Length; i++)
        {
            DeathTraps[i].GetComponent<BoxCollider>().enabled = false;
        }
        GetComponent<Collider>().enabled = false;
    }
}
