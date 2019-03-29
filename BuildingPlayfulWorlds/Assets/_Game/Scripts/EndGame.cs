using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public ParticleSystem[] ps;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].gameObject.GetComponent<ParticleSystem>().Stop();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].gameObject.GetComponent<ParticleSystem>().Play();

        }
    }
}
