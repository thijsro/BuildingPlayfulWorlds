using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Bridge_01_Manager mgr;
    public bool buttonPressed = false;
    public Transform button;
    public Material DeathTrap_1;
    AudioSource audioSource;
    [FMODUnity.EventRef]
    public string Button;

    private void Start()
    {
        mgr = FindObjectOfType<Bridge_01_Manager>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            buttonPressed = true;
            Debug.Log("Button pressed");
            audioSource.Play();
            FMODUnity.RuntimeManager.PlayOneShot(Button, transform.position);
            button.gameObject.GetComponent<Renderer>().material = DeathTrap_1;
        }
    }

}
