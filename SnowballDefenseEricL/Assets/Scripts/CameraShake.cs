using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static float shakeDuration = 0;
    public float shakeMagnitude = 0.3f;
    public float damping = 1;
    public Vector3 initalPosition;
    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition = initalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * damping;
        }
        if(shakeDuration <= 0)
        {
            transform.position = initalPosition;
        }
    }
}
