using UnityEngine;
using UnityEngine.SceneManagement; // ãßÊÈÉ ÅÏÇÑÉ ÇáãÔÇåÏ

public class ButtonManager : MonoBehaviour
{
    // ÇÓã ÇáãÔåÏ ÇáĞí ÊÑíÏ ÇáÚæÏÉ Åáíå
    public string sceneName;

    // ÇÓÊÏÚÇÁ ÚäÏ ÇáÖÛØ Úáì ÇáÒÑ
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
