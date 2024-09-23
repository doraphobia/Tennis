using UnityEngine;
using System.Collections;

public class CameraShakeOnAnyKeyPress : MonoBehaviour
{
    public Transform cameraTransform;      

    public float shakeDuration = 0.2f;     
    public float shakeMagnitude = 0.1f;    
    public float dampingSpeed = 1.0f;      

    private Vector3 initialPosition;       
    private bool isShaking = false;        

    void Start()
    {
      
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        initialPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        
        if (Input.anyKeyDown && !isShaking)
        {
            StartCoroutine(Shake());
        }
    }

    // Coroutine
    IEnumerator Shake()
    {
        isShaking = true;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeDuration)
        {
            
            Vector3 randomOffset = new Vector3(
                Random.Range(-1f, 1f) * shakeMagnitude,
                Random.Range(-1f, 1f) * shakeMagnitude,
                initialPosition.z
            );

           
            cameraTransform.localPosition = initialPosition + randomOffset;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Reset 
        cameraTransform.localPosition = initialPosition;
        isShaking = false;
    }
}
