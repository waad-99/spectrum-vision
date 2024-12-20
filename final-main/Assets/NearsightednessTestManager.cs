using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NearsightednessTestManager : MonoBehaviour
{
    public List<VisionPlate> plates; // List of vision plates
    public Image plateDisplay; // Display for the plate image
    public Button[] answerButtons; // Buttons used for answers
    public TextMeshProUGUI instructions; // User instructions
    public TextMeshProUGUI results; // Display area for results
    public List<Sprite> wrongAnswers; // List of images for wrong answers

    private int currentPlateIndex = 0;
    private int correctAnswers = 0;

    private void Start()
    {
        StartTest();
    }

    private void StartTest()
    {
        currentPlateIndex = 0;
        correctAnswers = 0;
        ShowPlate();
        results.text = "";
    }

    private void ShowPlate()
    {
        if (currentPlateIndex < plates.Count)
        {
            VisionPlate currentPlate = plates[currentPlateIndex];
            plateDisplay.sprite = currentPlate.plateImage;

            instructions.text = "Choose the correct answer:";
            SetAnswerButtons(currentPlate);
        }
        else
        {
            ShowResults();
        }
    }

    private void SetAnswerButtons(VisionPlate currentPlate)
    {
        int correctButtonIndex = Random.Range(0, answerButtons.Length);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i];
            button.onClick.RemoveAllListeners();

            if (i == correctButtonIndex)
            {
                // Set the correct answer image
                button.GetComponentInChildren<Image>().sprite = currentPlate.correctAnswerImage;
                button.onClick.AddListener(() => SubmitAnswer(true));
            }
            else
            {
                // Set the wrong answer images randomly from the list
                Sprite wrongAnswerImage = GenerateRandomWrongAnswer(currentPlate.correctAnswerImage);
                button.GetComponentInChildren<Image>().sprite = wrongAnswerImage;
                button.onClick.AddListener(() => SubmitAnswer(false));
            }
        }
    }

    private Sprite GenerateRandomWrongAnswer(Sprite correctAnswerImage)
    {
        // List of wrong answer images (you need to add the custom images here)
        List<Sprite> possibleAnswers = new List<Sprite>(wrongAnswers);
        possibleAnswers.Remove(correctAnswerImage); // Remove the correct answer from the list
        return possibleAnswers[Random.Range(0, possibleAnswers.Count)];
    }

    private void SubmitAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            correctAnswers++;
        }

        currentPlateIndex++;
        ShowPlate();
    }

    private void ShowResults()
    {
        float accuracy = (float)correctAnswers / plates.Count;

        if (accuracy > 0.9f)
        {
            results.text = "Your vision is excellent! (20/20)";
        }
        else if (accuracy > 0.75f)
        {
            results.text = "Your vision is good! (20/25)";
        }
        else if (accuracy > 0.5f)
        {
            results.text = "You might need an eye checkup. (20/40)";
        }
        else
        {
            results.text = "Your vision is weak. It is advised to visit an eye doctor.";
        }
    }
}
