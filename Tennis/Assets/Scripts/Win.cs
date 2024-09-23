using UnityEngine;
using System.Collections;

public class ShowCanvasAfterTime : MonoBehaviour
{
    public Canvas canvasToShow;     // The canvas 
    public float delayTime = 42f;   // Time to wait 

    void Start()
    {
        // Hide 
        if (canvasToShow != null)
        {
            canvasToShow.gameObject.SetActive(false);  
        }
        else
        {
            Debug.LogError("No canvas");
        }

        StartCoroutine(ShowCanvasAfterDelay());
    }

    IEnumerator ShowCanvasAfterDelay()
    {
        // Wait 
        yield return new WaitForSeconds(delayTime);

        // Show 
        if (canvasToShow != null)
        {
            canvasToShow.gameObject.SetActive(true);   
        }
        else
        {
            Debug.LogError(" missing !");
        }
    }
}
