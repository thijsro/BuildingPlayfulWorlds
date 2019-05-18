using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_01_Manager : MonoBehaviour
{
    bool openBridge = false;
    bool bridgeOpened = false;
    public ButtonScript[] buttons;
    public Transform bridge;
    Material bridgeMaterial;
    public Material sand_02;
    public AudioSource audioSource;
    [FMODUnity.EventRef]
    public string BridgeSound;

    // Start is called before the first frame update
    void Start()
    {
        bridgeMaterial = bridge.gameObject.GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (allOpen())
        {
            if (bridgeOpened == false)
            {
                bridgeOpened = true;

                Debug.Log("bridge open");
                openBridge = true;
                if (sand_02 != null)
                {
                    bridge.gameObject.GetComponent<Renderer>().sharedMaterial = sand_02;
                }
                bridge.transform.Translate(4, 0, 0);
                bridge.transform.localScale = new Vector3(12,bridge.transform.localScale.y, bridge.transform.localScale.z);
                audioSource.Play();
                FMODUnity.RuntimeManager.PlayOneShot(BridgeSound, bridge.transform.position);


            }


        }

    }

    bool allOpen()
    {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].buttonPressed == false)
                {
                    return false;
                }
            }

            return true;   

    }
}
