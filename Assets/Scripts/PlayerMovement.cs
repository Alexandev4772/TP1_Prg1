using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float velocidad = 7f;
    private float fuerzaSalto = 10f;
    private Vector3 direccion = Vector3.zero;
    private Rigidbody rigb;
    private bool saltarDisponible;
    public bool dobleSaltoHabilitado;
    private bool dobleSaltoDisponible=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direccion = new Vector3(horizontal, 0f ,vertical);
        Vector3 desplazamiento = direccion.normalized * Time.deltaTime * velocidad;
        transform.Translate(desplazamiento, Space.Self);
        if (Input.GetButtonDown("Jump"))
        {
            Saltar();
        }
    }

    public void Saltar()
    {
        if (saltarDisponible)
        {
            rigb.AddForce(new Vector3(0f, fuerzaSalto, 0f), ForceMode.Impulse);
        
        }
        else if (dobleSaltoHabilitado && dobleSaltoDisponible)
        {
            // Reiniciamos la velocidad en Y para que el salto secundario no pierda fuerza si vas cayendo
            rigb.linearVelocity = new Vector3(rigb.linearVelocity.x, 0f, rigb.linearVelocity.z);
            rigb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

            // Consumimos el doble salto hasta volver a tocar el suelo
            dobleSaltoDisponible = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            saltarDisponible = true;
        }
        if (dobleSaltoHabilitado)
        {
            dobleSaltoDisponible = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            saltarDisponible = false;
        }
    }
}
