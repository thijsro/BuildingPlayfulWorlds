using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_manager_02 : MonoBehaviour
{
    bool openBridge = false;
    bool bridgeOpened = false;
    public Flag[] flags;
    public Transform bridge;
    public FlagController flag;

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
                Debug.Log("Flag added");
            }
            else
            {
                Debug.Log("Need Flag");
            }
        }
    }
}
