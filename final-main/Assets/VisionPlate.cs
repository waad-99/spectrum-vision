using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vision Plate", menuName = "Vision Test/Vision Plate")]
public class VisionPlate : ScriptableObject
{
    public new string name; // ��� ������
    public Sprite plateImage; // ���� ������
    public Sprite correctAnswerImage; // ���� ������� �������
    public List<Sprite> wrongAnswerImages; // ����� ��� �������� �������

    public void Print()
    {
        Debug.Log($"{name}: Correct Answer: {correctAnswerImage.name}");
    }
}
