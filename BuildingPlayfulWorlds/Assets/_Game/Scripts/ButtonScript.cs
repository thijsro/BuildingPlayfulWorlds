using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Bridge_01_Manager mgr;
    public bool buttonPressed = false;

    private void Start()
    {
        mgr = FindObjectOfType<Bridge_01_Manager>();
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            buttonPressed = true;
            Debug.Log("Button pressed");

        }
    }

}
