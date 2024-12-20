using UnityEngine;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    private void Start()
    {
        // استرداد النتيجة من PlayerPrefs وعرضها
        string testResult = PlayerPrefs.GetString("TestResult", "No result available.");
        resultText.text = testResult;
    }
}
