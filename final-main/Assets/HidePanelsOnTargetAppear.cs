using UnityEngine;

public class PanelVisibility : MonoBehaviour
{
    public GameObject panelToShow;  // ������� ���� ���� ������ �� ������
    public GameObject buttonToHide; // ���� ���� ���� ������ ��� ����� �������

    public void TogglePanelVisibility()
    {
        // ���� ��� ��� ������� ���� �� ���� �� ���� �����
        bool isActive = panelToShow.activeSelf;
        panelToShow.SetActive(!isActive); // ����� ������ �� ���� ��� ���� �� �����

        // ��� �� ����� ������� ���� ����
        if (panelToShow.activeSelf)
        {
            buttonToHide.SetActive(false); // ����� ����
        }
        else
        {
            buttonToHide.SetActive(true);  // ����� ���� ��� �� ����� �������
        }
    }
}