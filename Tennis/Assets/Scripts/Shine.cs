using UnityEngine;
using System.Collections;

public class ShineEffect : MonoBehaviour
{
    public Color shineColor = Color.yellow; 
    public int sparkCount = 5;              // Number of times the object should spark
    public float sparkInterval = 0.2f;      // Time between 
    public float fadeSpeed = 2f;          

    private SpriteRenderer spriteRenderer;  
    private Color originalColor;           

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            return; 
        }

        // Store the original color of the object
        originalColor = spriteRenderer.color;

        StartCoroutine(SparkEffect());
    }

    private IEnumerator SparkEffect()
    {
        for (int i = 0; i < sparkCount; i++)
        {
            // Change the color to the shine color (spark)
            spriteRenderer.color = shineColor;

            // Wait 
            yield return new WaitForSeconds(sparkInterval / 2);

            spriteRenderer.color = originalColor;

            // Wait 
            yield return new WaitForSeconds(sparkInterval / 2);
        }

        float fadeAmount = 0f;
        while (fadeAmount < 1f)
        {
            fadeAmount += Time.deltaTime * fadeSpeed;
            spriteRenderer.color = Color.Lerp(shineColor, originalColor, fadeAmount);
            yield return null;
        }

        spriteRenderer.color = originalColor;
    }
}
