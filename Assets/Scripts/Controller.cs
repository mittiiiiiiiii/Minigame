using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float mouseSensitivity = 2.0f;
    public float upDownRange = 60.0f;
    public Transform cameraTransform; // カメラのTransformをアサイン

    private float verticalRotation = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Rigidbodyの回転を制限
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // マウスによる視線の制御
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); // カメラのローカル回転を更新

        // キーボードによる移動
        float forwardSpeed = Input.GetAxis("Vertical") * walkingSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * walkingSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;

        rb.velocity = new Vector3(speed.x, rb.velocity.y, speed.z);
    }
}