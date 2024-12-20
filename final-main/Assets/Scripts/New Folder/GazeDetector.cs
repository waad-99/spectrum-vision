using UnityEngine;

public class GazeDetector : MonoBehaviour
{
    public float gazeRange = 10f; // مدى النظر
    private GameObject currentObject; // العنصر الحالي الذي يتم النظر إليه

    void Update()
    {
        // إنشاء شعاع من الكاميرا باتجاه الأمام
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, gazeRange))
        {
            // إذا أصاب الشعاع جسمًا جديدًا
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject != currentObject)
            {
                // إذا كان هناك جسم سابق، استدعِ OnGazeExit
                if (currentObject != null)
                {
                    GazeColorChanger changer = currentObject.GetComponent<GazeColorChanger>();
                    if (changer != null)
                    {
                        changer.OnGazeExit();
                    }
                }

                // تحديث الجسم الحالي واستدعاء OnGazeEnter
                currentObject = hitObject;
                GazeColorChanger newChanger = currentObject.GetComponent<GazeColorChanger>();
                if (newChanger != null)
                {
                    newChanger.OnGazeEnter();
                }
            }
        }
        else
        {
            // إذا لم يصب الشعاع أي جسم
            if (currentObject != null)
            {
                GazeColorChanger changer = currentObject.GetComponent<GazeColorChanger>();
                if (changer != null)
                {
                    changer.OnGazeExit();
                }
                currentObject = null;
            }
        }
    }
}
