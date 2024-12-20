using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    // ����� ������ ��� ����� ���� ���� ������
    public AudioClip triggerSound;

    private AudioSource audioSource;

    private void Start()
    {
        // ����� AudioSource �������� ��� ������ ��� �� ��� �������
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ������� �����
        audioSource.playOnAwake = false; // �� ��� ����� ����� ��������
        audioSource.clip = triggerSound; // ����� ��� �����
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ �� �� ����� ���� ��� ������ �� ������
        if (other.CompareTag("Player"))
        {
            PlaySound(); // ����� �����
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && triggerSound != null)
        {
            audioSource.Play(); // ����� �����
        }
        else
        {
            Debug.LogError("��� ����� ��� ����� �� AudioSource ��� ����!");
        }
    }
}
