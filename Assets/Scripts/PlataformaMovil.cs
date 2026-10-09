using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Puntos de Destino")]
    public Transform puntoA;
    public Transform puntoB;

    [Header("Configuración de Movimiento")]
    public float velocidad = 3.0f;
    public float tiempoDePausa = 2.0f; // Tiempo de espera al llegar a cada extremo

    private Vector3 objetivoActual;
    private bool estaEsperando = false;

    void Start()
    {
        // La plataforma inicia su viaje hacia el Punto B
        if (puntoB != null)
        {
            objetivoActual = puntoB.position;
        }
    }

    void Update()
    {
        // Si está pausada esperando en un extremo, no calcula movimiento
        if (estaEsperando) return;

        // Desplazamiento continuo con Vector3.MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        // Verifica si llegó a la posición objetivo
        if (Vector3.Distance(transform.position, objetivoActual) < 0.1f)
        {
            estaEsperando = true;

            // EXIGENCIA DE LA CONSIGNA: Usar Invoke() para temporizar el cambio de dirección
            Invoke(nameof(CambiarObjetivo), tiempoDePausa);
        }
    }

    void CambiarObjetivo()
    {
        // Alterna el objetivo entre Punto A y Punto B
        objetivoActual = (objetivoActual == puntoA.position) ? puntoB.position : puntoA.position;
        estaEsperando = false;
    }

    // --- Mecánica para que el Jugador viaje en la plataforma ---
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Emparenta al jugador con la plataforma para que se mueva con ella
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desemparenta al jugador al bajarse
            other.transform.SetParent(null);
        }
    }
}
