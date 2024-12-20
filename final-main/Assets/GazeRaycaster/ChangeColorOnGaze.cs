using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnGaze : MonoBehaviour
{
    public List<Color> colorOptions = new List<Color> { Color.red, Color.blue, Color.green }; // ﬁ«∆„… «·√·Ê«‰
    private int currentColorIndex = 0; // „ƒ‘— «··Ê‰ «·Õ«·Ì
    private Renderer objectRenderer; // „—Ã⁄ ··„ﬂÊ‰ Renderer
    public ParticleSystem colorChangeEffect; // «· √ÀÌ— «·»’—Ì («Œ Ì«—Ì)
    private AudioSource audioSource; // „—Ã⁄ ··’Ê  («Œ Ì«—Ì)
    private bool isChangingColor = false; // ⁄·„ · Ã‰» «· ﬂ—«—

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnGazeEnter()
    {
        Debug.Log($"Started gazing at {gameObject.name}");
    }

    public void OnGazeExit()
    {
        Debug.Log($"Stopped gazing at {gameObject.name}");
    }

    public void TriggerAction()
    {
        if (isChangingColor) return; //  Ã‰» «· ﬂ—«—

        currentColorIndex = (currentColorIndex + 1) % colorOptions.Count; // «· ‰ﬁ· »Ì‰ «·√·Ê«‰
        StartCoroutine(ChangeColorSmoothly(colorOptions[currentColorIndex]));

        if (colorChangeEffect != null)
        {
            colorChangeEffect.Play(); //  ‘€Ì· «· √ÀÌ— «·»’—Ì
        }

        if (audioSource != null)
        {
            audioSource.Play(); //  ‘€Ì· «·’Ê 
        }
    }

    private IEnumerator ChangeColorSmoothly(Color targetColor)
    {
        isChangingColor = true;
        float duration = 1f; // „œ… «·«‰ ﬁ«·
        float timer = 0f;
        Color startColor = objectRenderer.material.color;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            objectRenderer.material.color = Color.Lerp(startColor, targetColor, timer / duration);
            yield return null;
        }

        objectRenderer.material.color = targetColor;
        isChangingColor = false;
    }
}
