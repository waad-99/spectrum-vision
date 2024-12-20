using UnityEngine;

public class GazeRaycaster : MonoBehaviour
{
    public float rayDistance = 10f; // ãÏì ÇáÔÚÇÚ
    private ChangeColorOnGaze currentTarget; // ÇáßÇÆä ÇáÍÇáí
    private float gazeTimer = 0f; // ÚÏÇÏ ÇáÊÍÏíŞ
    public float gazeTime = 2f; // ÇáæŞÊ ÇáãØáæÈ áÊäİíĞ ÇáÍÏË

    void Update()
    {
        // ÅäÔÇÁ ÔÚÇÚ ãä ÇáßÇãíÑÇ ááÃãÇã
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // İÍÕ ãÇ ÅĞÇ ßÇä ÇáÔÚÇÚ íÕíÈ ßÇÆäğÇ
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            ChangeColorOnGaze gazeTarget = hit.collider.GetComponent<ChangeColorOnGaze>();

            if (gazeTarget != null)
            {
                // ÇáÊÈÏíá Èíä ÇáßÇÆäÇÊ ÚäÏ ÊÛííÑ ÇáåÏİ
                if (gazeTarget != currentTarget)
                {
                    currentTarget?.OnGazeExit(); // ÅäåÇÁ ÇáÊÍÏíŞ Úáì ÇáßÇÆä ÇáÓÇÈŞ
                    currentTarget = gazeTarget;
                    currentTarget.OnGazeEnter(); // ÈÏÁ ÇáÊÍÏíŞ Úáì ÇáßÇÆä ÇáÌÏíÏ
                }

                // ÇÓÊãÑÇÑ ÇáÊÍÏíŞ
                gazeTimer += Time.deltaTime;

                if (gazeTimer >= gazeTime)
                {
                    currentTarget.TriggerAction(); // ÊäİíĞ ÇáÅÌÑÇÁ (ãËá ÊÛííÑ Çááæä)
                    gazeTimer = 0f; // ÅÚÇÏÉ ÖÈØ ÚÏÇÏ ÇáÊÍÏíŞ
                }
            }
        }
        else
        {
            // ÅäåÇÁ ÇáÊÍÏíŞ ÅĞÇ áã íÕÈ ÇáÔÚÇÚ ßÇÆäğÇ
            currentTarget?.OnGazeExit();
            currentTarget = null;
            gazeTimer = 0f;
        }
    }
}
