using UnityEngine;
using UnityEngine.SceneManagement; // �������� ����� ����� �������

public class SceneChanger : MonoBehaviour
{
    // ��� ������ ���� ���� �������� ����
    public string targetSceneName;

    // ��� ������� ��� ������ ��� ���� ������ ��� ������
    private void OnTriggerEnter(Collider other)
    {
        // ������ �� �� ����� ���� ��� ������ �� ������
        if (other.CompareTag("Player"))
        {
            // ������� ������ ������
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        // ����� ������ �����
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("��� ������ ����� ��� ����!");
        }
    }
}
