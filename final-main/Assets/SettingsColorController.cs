using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // ������ ������� �� ����� ��������

public class SettingsColorController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject colorPalettePanel; // ���� �������
    public Image colorPaletteImage;      // ���� ���� �������
    public Button settingsButton;        // �� ���������

    [Header("Panel Management")]
    public GameObject panelToShow;       // ������� ���� ���� ������
    public GameObject panelToHide;       // ������� ���� ���� ������

    [Header("Buttons Management")]
    public Button buttonToHide1;         // ���� ����� ���� ���� ������
    public Button buttonToHide2;         // ���� ������ ���� ���� ������
    public Button buttonToHide3;         // ���� ������ ���� ���� ������

    [Header("Environment Settings")]
    public Material environmentMaterial; // ������ ������ �������

    private Texture2D colorTexture;
    private bool buttonsHidden = false; // ���� ������� (����� �� �����)

    void Start()
    {
        // ����� ���� �������
        if (colorPalettePanel != null)
            colorPalettePanel.SetActive(false);

        // ����� ���� ������� ��� Texture2D
        if (colorPaletteImage != null)
            colorTexture = colorPaletteImage.mainTexture as Texture2D;

        // ����� ��� �� ���������
        if (settingsButton != null)
            settingsButton.onClick.AddListener(ToggleColorPalette);
    }

    // ����� ������ ���� ������� ������ �������
    void ToggleColorPalette()
    {
        if (colorPalettePanel != null)
            colorPalettePanel.SetActive(!colorPalettePanel.activeSelf);

        // ����� ��� ������ ����� ����
        if (panelToShow != null)
            panelToShow.SetActive(!panelToShow.activeSelf);

        if (panelToHide != null)
            panelToHide.SetActive(!panelToHide.activeSelf);

        // ����� ���� �������
        ToggleButtons();
    }

    void ToggleButtons()
    {
        buttonsHidden = !buttonsHidden; // ��� ���� �������

        if (buttonToHide1 != null)
            buttonToHide1.gameObject.SetActive(!buttonsHidden);

        if (buttonToHide2 != null)
            buttonToHide2.gameObject.SetActive(!buttonsHidden);

        if (buttonToHide3 != null)
            buttonToHide3.gameObject.SetActive(!buttonsHidden);
    }

    // ����� ������� �� ��� VR
    public void ChangeEnvironmentColor(Vector2 uvPosition)
    {
        if (colorTexture == null || environmentMaterial == null)
            return;

        // ����� ���������� ������� ��� �������� ��� Texture
        int pixelX = (int)(uvPosition.x * colorTexture.width);
        int pixelY = (int)(uvPosition.y * colorTexture.height);

        // ������ ��� ����� �� ��� Texture �������� GetPixel
        Color selectedColor = colorTexture.GetPixel(pixelX, pixelY);

        // ����� ��� ������
        environmentMaterial.color = selectedColor;

        Debug.Log($"Selected Color: {selectedColor}");
    }
}
