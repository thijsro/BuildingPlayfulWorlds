using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diediedie : MonoBehaviour
{
    public GameObject Player;
    public GameObject respawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log(" GAME OVER");
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Player.transform.position = respawnPosition.transform.position;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        }

    }
}
