using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorBlindnessTestManager : MonoBehaviour
{
    public List<IshiharaPlate> plates; // قائمة باللوحات
    public Image plateDisplay; // لعرض صورة اللوحة
    public TextMeshProUGUI instructions; // النصوص التعريفية
    public TextMeshProUGUI results; // النصوص الخاصة بالنتائج
    public Button correctAnswerButton; // زر الإجابة الصحيحة
    public Button protanopiaAnswerButton; // زر إجابة Protanopia
    public Button deuteranopiaAnswerButton; // زر إجابة Deuteranopia

    private int currentPlateIndex = 0;
    private int protanopiaScore = 0;
    private int deuteranopiaScore = 0;

    private void Start()
    {
        StartTest();
    }

    public void StartTest()
    {
        currentPlateIndex = 0;
        protanopiaScore = 0;
        deuteranopiaScore = 0;
        ShowPlate();
        results.text = "";
    }

    public void SubmitAnswer(string answerType)
    {
        IshiharaPlate currentPlate = plates[currentPlateIndex];

        if (answerType == "correct")
        {
            // إجابة صحيحة
        }
        else if (answerType == "protanopia")
        {
            protanopiaScore++;
        }
        else if (answerType == "deuteranopia")
        {
            deuteranopiaScore++;
        }

        currentPlateIndex++;

        if (currentPlateIndex < plates.Count)
        {
            ShowPlate();
        }
        else
        {
            ShowResults();
        }
    }

    private void ShowPlate()
    {
        IshiharaPlate currentPlate = plates[currentPlateIndex];
        plateDisplay.sprite = currentPlate.plateImage;
        instructions.text = "What number do you see?";

        // إعداد الأزرار مع النصوص الصحيحة
        correctAnswerButton.GetComponentInChildren<TextMeshProUGUI>().text = currentPlate.correctAnswer;
        protanopiaAnswerButton.GetComponentInChildren<TextMeshProUGUI>().text = currentPlate.protanopiaAnswer;
        deuteranopiaAnswerButton.GetComponentInChildren<TextMeshProUGUI>().text = currentPlate.deuteranopiaAnswer;

        // ربط الأزرار بوظيفة الإجابة
        correctAnswerButton.onClick.RemoveAllListeners();
        protanopiaAnswerButton.onClick.RemoveAllListeners();
        deuteranopiaAnswerButton.onClick.RemoveAllListeners();

        correctAnswerButton.onClick.AddListener(() => SubmitAnswer("correct"));
        protanopiaAnswerButton.onClick.AddListener(() => SubmitAnswer("protanopia"));
        deuteranopiaAnswerButton.onClick.AddListener(() => SubmitAnswer("deuteranopia"));
    }

    private void ShowResults()
    {
        if (protanopiaScore > deuteranopiaScore)
        {
            results.text = "You may have Protanopia .";
            //(Red - Green Color Blindness)
        }
        else if (deuteranopiaScore > protanopiaScore)
        {
            results.text = "You may have Deuteranopia .";
            //(Green - Red Color Blindness)
        }
        else
        {
            results.text = "No significant color blindness detected.";
        }
    }
}
