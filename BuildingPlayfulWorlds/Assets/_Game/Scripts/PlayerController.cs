using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public GameObject camera;

    public float moveSpeed = 4;

    public Transform myTransform;

    [Header("Camera Settings")]
    public float sensitivityX = 15;
    public float sensitivityY = 15;
    public float maxYAngle = 85f;

    private Rigidbody rb;
    private float camAngleX;
    private float camAngleY;
    private Vector3 velocity;
    private float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            myTransform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            myTransform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            myTransform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            myTransform.position -= transform.right * moveSpeed * Time.deltaTime;
        }


        //Apply rotation and update camera
        float camX = Input.GetAxis("Mouse X");
        float camY = Input.GetAxis("Mouse Y");

        camAngleX += camX * sensitivityX;
        camAngleY += camY * sensitivityY;
        camAngleY = Mathf.Clamp(camAngleY, -maxYAngle, maxYAngle);
        camera.transform.localRotation = Quaternion.Euler(-camAngleY, 0, 0);

        transform.rotation = Quaternion.Euler(0, camAngleX, 0);
    }
}
