using UnityEngine;

public class GazeRaycaster : MonoBehaviour
{
    public float rayDistance = 10f; // ��� ������
    private ChangeColorOnGaze currentTarget; // ������ ������
    private float gazeTimer = 0f; // ���� �������
    public float gazeTime = 2f; // ����� ������� ������ �����

    void Update()
    {
        // ����� ���� �� �������� ������
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // ��� �� ��� ��� ������ ���� ������
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            ChangeColorOnGaze gazeTarget = hit.collider.GetComponent<ChangeColorOnGaze>();

            if (gazeTarget != null)
            {
                // ������� ��� �������� ��� ����� �����
                if (gazeTarget != currentTarget)
                {
                    currentTarget?.OnGazeExit(); // ����� ������� ��� ������ ������
                    currentTarget = gazeTarget;
                    currentTarget.OnGazeEnter(); // ��� ������� ��� ������ ������
                }

                // ������� �������
                gazeTimer += Time.deltaTime;

                if (gazeTimer >= gazeTime)
                {
                    currentTarget.TriggerAction(); // ����� ������� (��� ����� �����)
                    gazeTimer = 0f; // ����� ��� ���� �������
                }
            }
        }
        else
        {
            // ����� ������� ��� �� ��� ������ ������
            currentTarget?.OnGazeExit();
            currentTarget = null;
            gazeTimer = 0f;
        }
    }
}
