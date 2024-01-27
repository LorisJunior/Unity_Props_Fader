using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fader : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float targetAlpha = 0.45f;
    private float fadeOutSeconds = 0.35f;
    private float fadeInSeconds = 0.25f;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        float currentAlpha = spriteRenderer.color.a;
        float distance = currentAlpha - targetAlpha;
        float v = distance / fadeOutSeconds;

        while (currentAlpha - targetAlpha > 0.01f)
        {
            currentAlpha = currentAlpha - v * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }

        spriteRenderer.color = new Color(1f, 1f, 1f, targetAlpha);
    }

    private IEnumerator FadeInRoutine()
    {
        float currentAlpha = spriteRenderer.color.a;
        float distance = 1f - currentAlpha;
        float v = distance / fadeInSeconds;

        while (1f - currentAlpha > 0.01f)
        {
            currentAlpha = currentAlpha + v * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
            FadeOut();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FadeIn();
    }
}
