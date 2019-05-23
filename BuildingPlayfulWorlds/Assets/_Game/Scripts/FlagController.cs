using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    public Transform flagPosition;

    public Flag currentFlag = null;

    public bool hasFlag = false;

    [FMODUnity.EventRef] public string FlagPickedUpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        //pick up the flag
        Flag flag = col.gameObject.GetComponent<Flag>();
        if (hasFlag == false)
        {
            if (flag != null)
            {
                currentFlag = flag;
                currentFlag.OnPickup(flagPosition);
                currentFlag.GetComponent<SphereCollider>().enabled = false;
                hasFlag = true;
                Debug.Log("Picked up flag");
                FMODUnity.RuntimeManager.PlayOneShot(FlagPickedUpSound, transform.position);

            }
        }
        else
        {
            Debug.Log("Already has flag");
        }
    }
}
