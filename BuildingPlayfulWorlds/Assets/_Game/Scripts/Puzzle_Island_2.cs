using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Island_2 : MonoBehaviour
{
    public Transform player;
    public Transform respawnposition;


    // Start is called before the first frame update
    void Start()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Died");
        player.gameObject.transform.position = respawnposition.position;

    }
}
