using UnityEngine;

public class PanelVisibility : MonoBehaviour
{
    public GameObject panelToShow;  // «·»«‰Ì· «·–Ì  —Ìœ ≈ŸÂ«—Â √Ê ≈Œ›«¡Â
    public GameObject buttonToHide; // «·“— «·–Ì  —Ìœ ≈Œ›«¡Â ⁄‰œ ≈ŸÂ«— «·»«‰Ì·

    public void TogglePanelVisibility()
    {
        //  Õﬁﬁ ≈–« ﬂ«‰ «·»«‰Ì· „—∆Ì √Ê „Œ›Ì À„ €Ì¯— Õ«· Â
        bool isActive = panelToShow.activeSelf;
        panelToShow.SetActive(!isActive); //  €ÌÌ— «·Õ«·… „‰ „—∆Ì ≈·Ï „Œ›Ì √Ê «·⁄ﬂ”

        // ≈–«  „ ≈ŸÂ«— «·»«‰Ì·° √Œ›Ì «·“—
        if (panelToShow.activeSelf)
        {
            buttonToHide.SetActive(false); // ≈Œ›«¡ «·“—
        }
        else
        {
            buttonToHide.SetActive(true);  // ≈ŸÂ«— «·“— ≈–«  „ ≈Œ›«¡ «·»«‰Ì·
        }
    }
}