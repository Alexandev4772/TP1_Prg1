using UnityEngine;

public class DispararBalas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Configuración del Disparo")]
    public GameObject bulletPrefab; // Arrastra el Prefab de la bala aquí
    public Transform firePoint;     // Objeto vacío en la punta del cañón
    public float fireRate = 2f;      // Intervalo de disparo en segundos

    void Start()
    {
        // Ejecuta 'Shoot' repetidamente: empieza en 0s y se repite cada 'fireRate' segundos
        InvokeRepeating(nameof(Shoot), 0f, fireRate);
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instancia la bala en la posición y rotación del firePoint
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }


}
