using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    // „ €Ì— · Œ“Ì‰ „·› «·’Ê  «·–Ì ”Ì „  ‘€Ì·Â
    public AudioClip triggerSound;

    private AudioSource audioSource;

    private void Start()
    {
        // ≈÷«›… AudioSource  ·ﬁ«∆Ì« ≈·Ï «·ﬂ«∆‰ ≈–« ·„ Ìﬂ‰ „ÊÃÊœ«
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ≈⁄œ«œ«  «·’Ê 
        audioSource.playOnAwake = false; // ·« Ì „  ‘€Ì· «·’Ê   ·ﬁ«∆Ì«
        audioSource.clip = triggerSound; //  ⁄ÌÌ‰ „·› «·’Ê 
    }

    private void OnTriggerEnter(Collider other)
    {
        // «· Õﬁﬁ „‰ √‰ «·Ã”„ «·–Ì ·„” «·ﬂÌÊ» ÂÊ «··«⁄»
        if (other.CompareTag("Player"))
        {
            PlaySound(); //  ‘€Ì· «·’Ê 
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && triggerSound != null)
        {
            audioSource.Play(); //  ‘€Ì· «·’Ê 
        }
        else
        {
            Debug.LogError("„·› «·’Ê  €Ì— „ÊÃÊœ √Ê AudioSource €Ì— „ÂÌ√!");
        }
    }
}
