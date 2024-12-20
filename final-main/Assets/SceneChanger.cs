using UnityEngine;
using UnityEngine.SceneManagement; // áÇÓÊíÑÇÏ ãßÊÈÉ ÅÏÇÑÉ ÇáãÔÇåÏ

public class SceneChanger : MonoBehaviour
{
    // ÇÓã ÇáãÔåÏ ÇáĞí ÓíÊã ÇáÇäÊŞÇá Åáíå
    public string targetSceneName;

    // íÊã ÇÓÊÏÚÇÁ åĞå ÇáÏÇáÉ ÚäÏ ÏÎæá ÇááÇÚÈ Åáì ÇáßíæÈ
    private void OnTriggerEnter(Collider other)
    {
        // ÇáÊÍŞŞ ãä Ãä ÇáÌÓã ÇáĞí áãÓ ÇáßíæÈ åæ ÇááÇÚÈ
        if (other.CompareTag("Player"))
        {
            // ÇÓÊÏÚÇÁ ÇáãÔåÏ ÇáÌÏíÏ
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        // ÊÍãíá ÇáãÔåÏ ÇáåÏİ
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("ÇÓã ÇáãÔåÏ ÇáåÏİ ÛíÑ ãÍÏÏ!");
        }
    }
}
