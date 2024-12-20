using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vision Plate", menuName = "Vision Test/Vision Plate")]
public class VisionPlate : ScriptableObject
{
    public new string name; // «”„ «··ÊÕ…
    public Sprite plateImage; // ’Ê—… «··ÊÕ…
    public Sprite correctAnswerImage; // ’Ê—… «·≈Ã«»… «·’ÕÌÕ…
    public List<Sprite> wrongAnswerImages; // ﬁ«∆„… ’Ê— «·≈Ã«»«  «·Œ«ÿ∆…

    public void Print()
    {
        Debug.Log($"{name}: Correct Answer: {correctAnswerImage.name}");
    }
}
