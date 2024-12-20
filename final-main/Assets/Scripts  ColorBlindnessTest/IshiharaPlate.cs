using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ishihara Plate", menuName = "Color Blindness Test/Ishihara Plate")]
public class IshiharaPlate : ScriptableObject
{
    public new string name; // اسم اللوحة
    public Sprite plateImage; // صورة اللوحة
    public string correctAnswer; // الإجابة الصحيحة
    public string protanopiaAnswer; // الإجابة إذا كان لدى المستخدم Protanopia
    public string deuteranopiaAnswer; // الإجابة إذا كان لدى المستخدم Deuteranopia

    public void Print()
    {
        Debug.Log(name + ": Correct Answer: " + correctAnswer + 
                  ", Protanopia Answer: " + protanopiaAnswer + 
                  ", Deuteranopia Answer: " + deuteranopiaAnswer);
    }
}
