using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float velocidad = 7f;
    private float fuerzaSalto = 10f;
    private float velocidadRotacion = 90f;
    private Vector3 direccion = Vector3.zero;
    private Rigidbody rigb;
    private bool saltarDisponible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float giro = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direccion = new Vector3(0f, 0f ,vertical);
        Vector3 desplazamiento = direccion.normalized * Time.deltaTime * velocidad;
        transform.Translate(desplazamiento, Space.Self);
        transform.Rotate(0f, giro * velocidadRotacion * Time.deltaTime, 0f);
        if (Input.GetButtonDown("Jump"))
        {
            Saltar();
        }
    }

    public void Saltar()
    {
        if(saltarDisponible)
        rigb.AddForce(new Vector3(0f, fuerzaSalto, 0f),ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            saltarDisponible = true;
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
