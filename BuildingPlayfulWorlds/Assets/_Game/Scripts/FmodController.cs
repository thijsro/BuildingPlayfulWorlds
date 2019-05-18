using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string Button;

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(Button, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
