using UnityEngine;

public class GazeColorChanger : MonoBehaviour
{
    // اللون الأساسي واللون عند التفاعل
    public Color defaultColor = Color.white;
    public Color gazeColor = Color.red;

    // مرجع للمادة
    private Renderer objectRenderer;

    private void Start()
    {
        // الحصول على الـ Renderer لتغيير اللون
        objectRenderer = GetComponent<Renderer>();

        // تعيين اللون الأساسي عند بدء اللعبة
        objectRenderer.material.color = defaultColor;
    }

    public void OnGazeEnter()
    {
        // تغيير اللون عند النظر
        objectRenderer.material.color = gazeColor;
    }

    public void OnGazeExit()
    {
        // إعادة اللون الأساسي عند عدم النظر
        objectRenderer.material.color = defaultColor;
    }
}
