using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public Light light;
    public bool isFlickering = false;
    public float timeDelay;

    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        light.enabled = false;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        light.enabled = true;
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
