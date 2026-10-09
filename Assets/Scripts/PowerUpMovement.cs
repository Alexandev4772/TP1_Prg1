using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    private float velocidadGiro = 120f;
    private float distancia = 0.25f;
    private float velocidad = 2f;
    private Vector3 posicionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, velocidadGiro * Time.deltaTime, 0f, Space.World);
        float desfaseY = Mathf.Sin(Time.time * velocidad) * distancia;

        // Aplicamos el movimiento únicamente al eje Y
        transform.position = posicionInicial + new Vector3(0f, desfaseY, 0f);
        
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.dobleSaltoHabilitado = true;
            }
            Destroy(gameObject);
        }
    }
}
