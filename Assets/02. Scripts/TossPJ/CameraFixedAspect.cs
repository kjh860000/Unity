using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFixedAspect : MonoBehaviour
{
    public Vector2 targetAspectRatio = new Vector2(9f, 16f); // 720x1280 비율

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        float targetRatio = targetAspectRatio.x / targetAspectRatio.y;
        float windowRatio = (float)Screen.width / Screen.height;
        float scaleHeight = windowRatio / targetRatio;

        if (scaleHeight < 1f)
        {
            // Letterbox (위아래 여백)
            Rect rect = cam.rect;
            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1f - scaleHeight) / 2f;
            cam.rect = rect;
        }
        else
        {
            // Pillarbox (양옆 여백)
            float scaleWidth = 1f / scaleHeight;
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}
