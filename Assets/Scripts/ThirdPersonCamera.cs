using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 1.0f;
    public float rotationSpeed = 100.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, yMinLimit, yMaxLimit);
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance) + Vector3.up * height;
            transform.position = position;
            transform.LookAt(target.position + Vector3.up * height);
        }
    }
}
