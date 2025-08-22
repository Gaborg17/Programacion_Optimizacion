using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensibility;
    public float smoothness;

    public float maxVertical;
    public float minVertical;

    private Vector2 mouseScaledPos;
    private Vector2 smoothedCam;
    private Vector2 camPos;
    private Vector2 mousePos;

    public Transform player;
    void Start()
    {
        if (player == null)
        {
            player = transform.parent;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        mousePos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseScaledPos = Vector2.Scale(mousePos,Vector2.one *  sensibility);
        smoothedCam = Vector2.Lerp(smoothedCam, mouseScaledPos, 1 / smoothness);

        camPos += smoothedCam;

        camPos.y = Mathf.Clamp(camPos.y, minVertical,maxVertical);

        transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);

        player.localRotation = Quaternion.AngleAxis(camPos.x, Vector3.up);

    }
}
