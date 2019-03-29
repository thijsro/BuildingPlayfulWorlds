using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEndGame : MonoBehaviour
{
    public GameObject endGameText;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        endGameText.SetActive(true);
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.MouseLook>().lockCursor = false;
        Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
    }



}
