using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSwitch : MonoBehaviour
{
    [SerializeField] Transform DirectionalLight0;
    [SerializeField] Transform DirectionalLight1;

    [Space]
    [SerializeField] Collider Trigger;
    [SerializeField] bool doFade; //Should the light change or should it fade with another light?

    [Space]
    [SerializeField] float rotationSpeed = 0.2f;
    [SerializeField] float fadeSpeed = 0.2f;
    float CurrentIntensity0;
    float CurrentIntensity1;

    [Space]
    [SerializeField] float newRotation = 0.0f;

    Vector3 currentRotation0;
    Vector3 currentRotation1;

    Color currentColor;
    [SerializeField] Color newColor;

    private bool isEnabled = false;

    float lerpTime = 0;

    [SerializeField] float newIntensity = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        CurrentIntensity0 = DirectionalLight0.GetComponent<Light>().intensity;
        CurrentIntensity1 = DirectionalLight1.GetComponent<Light>().intensity;
        currentColor = RenderSettings.ambientLight;
    }

    // Update is called once per frame
    void Update()
    {
       if(isEnabled)
            if (doFade)
            {
                StartCoroutine("FadeLights");
            }
            else
            {
                StartCoroutine("ChangeLight");
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        isEnabled = true;
    }

    IEnumerator ChangeLight()
    {
        lerpTime += (Time.deltaTime / fadeSpeed);

        //Changing rotation to new rotation
        currentRotation0 = DirectionalLight0.eulerAngles;
        currentRotation0.x = Mathf.Lerp(currentRotation0.x, newRotation, Time.deltaTime * rotationSpeed);
        DirectionalLight0.eulerAngles = currentRotation0;

        DirectionalLight0.gameObject.GetComponent<Light>().color = Color.Lerp(DirectionalLight0.gameObject.GetComponent<Light>().color, newColor, lerpTime);

        yield return null;
    }

    IEnumerator FadeLights()
    {    
        lerpTime += (Time.deltaTime / fadeSpeed);

        DirectionalLight1.gameObject.SetActive(true);

        DirectionalLight1.GetComponent<Light>().intensity = Mathf.Lerp(CurrentIntensity1, newIntensity, lerpTime);

        DirectionalLight0.GetComponent<Light>().intensity = Mathf.Lerp(CurrentIntensity0, 0.0f, lerpTime);

        RenderSettings.ambientLight = Color.Lerp(currentColor, newColor, lerpTime);
        
        currentRotation1 = DirectionalLight1.eulerAngles;
        currentRotation1.x = Mathf.Lerp(currentRotation1.x, newRotation, Time.deltaTime * rotationSpeed);
        DirectionalLight1.eulerAngles = currentRotation1;

        if(CurrentIntensity0 < 0.2)
        {
            DirectionalLight0.gameObject.SetActive(false);
        }

        yield return null;  
    }
}
