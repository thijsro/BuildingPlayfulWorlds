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
        if (isDangerous == true)
        {
            //Destroy(player);
            Debug.Log("You died!");
            Manager.isResetting = true;
        }
        else
        {
            if (isFirstOne == true)
            {
                Manager.resetDone = true;

            }
            deathTrap.gameObject.GetComponent<Renderer>().sharedMaterial = DeathTrap_2;
            if (isLastOne == true)
            {
                Debug.Log("Wall destroyed");
                Destroy(Wall);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isFirstOne == true)
        {
            Manager.resetDone = false;
        }
    }

}
