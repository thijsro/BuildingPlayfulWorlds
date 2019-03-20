using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    public bool isDangerous;
    public bool isLastOne;
    public bool isFirstOne;
    Material DeathTrapMaterial;
    public Transform deathTrap;
    public Material DeathTrap_0;
    public Material DeathTrap_1;
    public Material DeathTrap_2;
    public GameObject Wall;
    DeathTrapManager Manager;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DeathTrapMaterial = deathTrap.gameObject.GetComponent<Renderer>().sharedMaterial;
        Manager = GetComponentInParent<DeathTrapManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (Manager.isDead) { return; }
        if (isDangerous == true)
        {
            //Tell manager to make all tiles red.
            Debug.Log("You died!");
            Manager.DeathPuzzle();
        }
        else
        {
            
            deathTrap.gameObject.GetComponent<Renderer>().sharedMaterial = DeathTrap_2;
            if (isLastOne == true)
            {
                //Create next way to walk
                Debug.Log("Wall destroyed");
                Destroy(Wall);
                Manager.PuzzleSolved();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
