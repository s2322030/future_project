using UnityEngine;

using UnityEngine;

public class CameraFallController : MonoBehaviour
{
    private bool isFalling = true;

    public void StopFalling()
    {
        isFalling = false;
        Debug.Log("Camera falling stopped");
    }

    public void StartFalling()
    {
        isFalling = true;
        Debug.Log("Camera falling started");
    }

    void Update()
    {
        if (isFalling)
        {
            // カメラの落下に関するロジックをここに追加します
        }
    }
}