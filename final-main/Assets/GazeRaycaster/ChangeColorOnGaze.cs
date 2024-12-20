using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnGaze : MonoBehaviour
{
    public List<Color> colorOptions = new List<Color> { Color.red, Color.blue, Color.green }; // ����� �������
    private int currentColorIndex = 0; // ���� ����� ������
    private Renderer objectRenderer; // ���� ������ Renderer
    public ParticleSystem colorChangeEffect; // ������� ������ (�������)
    private AudioSource audioSource; // ���� ����� (�������)
    private bool isChangingColor = false; // ��� ����� �������

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
        if (isChangingColor) return; // ���� �������

        currentColorIndex = (currentColorIndex + 1) % colorOptions.Count; // ������ ��� �������
        StartCoroutine(ChangeColorSmoothly(colorOptions[currentColorIndex]));

        if (colorChangeEffect != null)
        {
            colorChangeEffect.Play(); // ����� ������� ������
        }

        if (audioSource != null)
        {
            audioSource.Play(); // ����� �����
        }
    }

    private IEnumerator ChangeColorSmoothly(Color targetColor)
    {
        isChangingColor = true;
        float duration = 1f; // ��� ��������
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
