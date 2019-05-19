using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_manager_02 : MonoBehaviour
{
    bool openBridge = false;
    bool bridgeOpened = false;
    bool firstFlagAdded = false;
    bool secondFlagAdded = false;
    bool thirdFlagAdded = false;
    public Flag[] flags;
    public Transform bridge;
    public FlagController flag;
    public Transform flagPosition2;
    public Transform flagPosition3;
    public Transform flagPosition4;
    public Material material;
    public AudioSource audioSource;
    [FMODUnity.EventRef]
    public string BridgeSound;
    [FMODUnity.EventRef]
    public string FlagAddedSound;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.FindGameObjectWithTag("Player").GetComponent<FlagController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (flag.hasFlag == true)
            {   
                if (firstFlagAdded == false)
                {
                    Debug.Log("Flag added");
                    firstFlagAdded = true;
                    flag.currentFlag.OnPickup(flagPosition2);                   
                    flag.hasFlag = false;
                    FMODUnity.RuntimeManager.PlayOneShot(FlagAddedSound, transform.position);
                }
                else
                {
                    if (secondFlagAdded == false)
                    {
                        secondFlagAdded = true;
                        flag.currentFlag.OnPickup(flagPosition3);
                        flag.hasFlag = false;
                        FMODUnity.RuntimeManager.PlayOneShot(FlagAddedSound, transform.position);
                    }
                    else
                    {
                        if (thirdFlagAdded == false)
                        {
                            thirdFlagAdded = true;
                            flag.currentFlag.OnPickup(flagPosition4);
                            bridge.transform.Translate(4, 0, 0);
                            bridge.transform.localScale = new Vector3(12, bridge.transform.localScale.y, bridge.transform.localScale.z);
                            bridge.gameObject.GetComponent<Renderer>().material = material;
                            flag.hasFlag = false;
                            bridgeOpened = true;
                            audioSource.Play();
                            FMODUnity.RuntimeManager.PlayOneShot(FlagAddedSound, transform.position);
                            FMODUnity.RuntimeManager.PlayOneShot(BridgeSound, transform.position);
                        }
                    }
                }

            }
            else
            {
                Debug.Log("Need Flag");
            }
        }
    }
}
