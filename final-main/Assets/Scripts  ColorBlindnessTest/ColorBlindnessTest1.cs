using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
[CreateAssetMenu(fileName = "New Ishihara Plate", menuName = "ScriptableObjects/Ishihara Plate")]
public class IshiharaPlateData : ScriptableObject
{
    public Sprite plateImage;
    public string correctAnswer;
    public string protanopiaAnswer;
    public string deuteranopiaAnswer;
}
public class ColorBlindnessTest1 : MonoBehaviour
{
    [System.Serializable]
    public class IshiharaPlateData
    {
        public Sprite plateImage;
        public string correctAnswer;
        public string protanopiaAnswer;
        public string deuteranopiaAnswer;
    }

    public IshiharaPlateData[] plates; // Declare the plates array once

    public Image plateDisplay;
    public TextMeshProUGUI instructions;
    public TextMeshProUGUI results;
    public GameObject userInputObject;
    private InputField userInput;


    private int currentPlateIndex = 0;
    private int protanopiaScore = 0;
    private int deuteranopiaScore = 0;

    private void Start()
    {
        userInput = userInputObject.GetComponent<InputField>();
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

    public void SubmitAnswer()
    {
        string userAnswer = userInput.text;

        if (plates[currentPlateIndex].correctAnswer == userAnswer)
        {
            // إجابة صحيحة
        }
        else if (plates[currentPlateIndex].protanopiaAnswer == userAnswer)
        {
            protanopiaScore++;
        }
        else if (plates[currentPlateIndex].deuteranopiaAnswer == userAnswer)
        {
            deuteranopiaScore++;
        }

        userInput.text = ""; // تفريغ الحقل
        currentPlateIndex++;

        if (currentPlateIndex < plates.Length)
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
        plateDisplay.sprite = plates[currentPlateIndex].plateImage;
        instructions.text = "What number do you see?";
    }

    private void ShowResults()
    {
        if (protanopiaScore > deuteranopiaScore)
        {
            results.text = "You may have Protanopia (Red-Green Color Blindness).";
        }
        else if (deuteranopiaScore > protanopiaScore)
        {
            results.text = "You may have Deuteranopia (Green-Red Color Blindness).";
        }
        else
        {
            results.text = "No significant color blindness detected.";
        }
    }
}
