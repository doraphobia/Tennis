using UnityEngine;

public class DisappearAfterTime : MonoBehaviour
{
    public float disappearTime = 5f; // Time 

    void Start()
    {
        // Destroy
        Destroy(gameObject, disappearTime);
    }
}
