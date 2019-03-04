using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    public bool isDangerous;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        }
    }
}
