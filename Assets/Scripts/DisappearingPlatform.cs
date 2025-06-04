using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public float invisibleDuration = 2f;

    private SpriteRenderer sr;
    private Collider2D col;
    private Color originalColor;
    private bool isDisappearing = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        originalColor = sr.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDisappearing && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeOutAndIn());
        }
    }

    System.Collections.IEnumerator FadeOutAndIn()
    {
        isDisappearing = true;

        // Fade out
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        col.enabled = false;

        // Stay invisible
        yield return new WaitForSeconds(invisibleDuration);

        // Fade in
        t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        sr.color = originalColor;
        col.enabled = true;

        isDisappearing = false;
    }
}
