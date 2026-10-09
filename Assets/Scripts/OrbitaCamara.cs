using UnityEngine;

public class OrbitaCamara : MonoBehaviour
{
    public float mouseSensitivity = 400f;

    [Header("Límites de Mirada Vertical")]
    public float minXAngle = -60f; // Límite mirando hacia abajo
    public float maxXAngle = 70f;  // Límite mirando hacia arriba

    private Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        // Obtiene la referencia al Player (el padre de la cámara)
        playerBody = transform.parent;

        // Bloquea y oculta el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener la entrada del movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 1. Rotación Vertical (Arriba / Abajo) - Afecta solo a la Cámara
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle); // Limita el ángulo
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 2. Rotación Horizontal (Izquierda / Derecha) - Gira a todo el Player
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
