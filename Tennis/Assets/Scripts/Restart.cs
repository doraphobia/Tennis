using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public string sceneToLoad;

    public void OnRestartButtonClick()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Load scene
            SceneManager.LoadScene(sceneToLoad);

        }
        else
        {
            Debug.LogWarning("No!");
        }
    }
}
