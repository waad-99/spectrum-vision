using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // ·≈œ«—… «· ›«⁄· „⁄ Ê«ÃÂ… «·„” Œœ„

public class SettingsColorController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject colorPalettePanel; // ·ÊÕ… «·√·Ê«‰
    public Image colorPaletteImage;      // ’Ê—… ·ÊÕ… «·√·Ê«‰
    public Button settingsButton;        // “— «·≈⁄œ«œ« 

    [Header("Panel Management")]
    public GameObject panelToShow;       // «·»«‰Ì· «·–Ì  —Ìœ ≈ŸÂ«—Â
    public GameObject panelToHide;       // «·»«‰Ì· «·–Ì  —Ìœ ≈Œ›«¡Â

    [Header("Buttons Management")]
    public Button buttonToHide1;         // «·“— «·√Ê· «·–Ì  —Ìœ ≈Œ›«¡Â
    public Button buttonToHide2;         // «·“— «·À«‰Ì «·–Ì  —Ìœ ≈Œ›«¡Â
    public Button buttonToHide3;         // «·“— «·À«·À «·–Ì  —Ìœ ≈Œ›«¡Â

    [Header("Environment Settings")]
    public Material environmentMaterial; // «·„«œ… «·Œ«’… »«·»Ì∆…

    private Texture2D colorTexture;
    private bool buttonsHidden = false; // Õ«·… «·√“—«— („Œ›Ì… √Ê Ÿ«Â—…)

    void Start()
    {
        // ≈Œ›«¡ ·ÊÕ… «·√·Ê«‰
        if (colorPalettePanel != null)
            colorPalettePanel.SetActive(false);

        //  ÕÊÌ· ’Ê—… «·√·Ê«‰ ≈·Ï Texture2D
        if (colorPaletteImage != null)
            colorTexture = colorPaletteImage.mainTexture as Texture2D;

        // ≈÷«›… ÕœÀ “— «·≈⁄œ«œ« 
        if (settingsButton != null)
            settingsButton.onClick.AddListener(ToggleColorPalette);
    }

    // ≈ŸÂ«— Ê≈Œ›«¡ ·ÊÕ… «·√·Ê«‰ Ê≈œ«—… «·√“—«—
    void ToggleColorPalette()
    {
        if (colorPalettePanel != null)
            colorPalettePanel.SetActive(!colorPalettePanel.activeSelf);

        // ≈œ«—… ⁄—÷ Ê≈Œ›«¡ ·ÊÕ«  √Œ—Ï
        if (panelToShow != null)
            panelToShow.SetActive(!panelToShow.activeSelf);

        if (panelToHide != null)
            panelToHide.SetActive(!panelToHide.activeSelf);

        //  »œÌ· Õ«·… «·√“—«—
        ToggleButtons();
    }

    void ToggleButtons()
    {
        buttonsHidden = !buttonsHidden; // ⁄ﬂ” Õ«·… «·√“—«—

        if (buttonToHide1 != null)
            buttonToHide1.gameObject.SetActive(!buttonsHidden);

        if (buttonToHide2 != null)
            buttonToHide2.gameObject.SetActive(!buttonsHidden);

        if (buttonToHide3 != null)
            buttonToHide3.gameObject.SetActive(!buttonsHidden);
    }

    //  ÕœÌÀ «· ›«⁄· „⁄ «·‹ VR
    public void ChangeEnvironmentColor(Vector2 uvPosition)
    {
        if (colorTexture == null || environmentMaterial == null)
            return;

        //  ÕÊÌ· «·≈Õœ«ÀÌ«  «·‰”»Ì… ≈·Ï ≈Õœ«ÀÌ«  «·‹ Texture
        int pixelX = (int)(uvPosition.x * colorTexture.width);
        int pixelY = (int)(uvPosition.y * colorTexture.height);

        // «·Õ’Ê· ⁄·Ï «··Ê‰ „‰ «·‹ Texture »«” Œœ«„ GetPixel
        Color selectedColor = colorTexture.GetPixel(pixelX, pixelY);

        //  €ÌÌ— ·Ê‰ «·»Ì∆…
        environmentMaterial.color = selectedColor;

        Debug.Log($"Selected Color: {selectedColor}");
    }
}
