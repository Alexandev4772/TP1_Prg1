using UnityEngine;

public class ControlBandera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Referencias de Banderas")]
    public GameObject banderaMetaA;   // La bandera que está sobre la Zona A
    public GameObject banderaPlayer;  // La bandera inclinada en el brazo derecho
    public GameObject banderaMetaB;   // La bandera plantada en la Zona B

    [Header("Estado")]
    public bool tieneBandera = false;

    // Se dispara si las zonas tienen 'Is Trigger' activado
    private void OnTriggerEnter(Collider other)
    {
        // 1. LLEGADA A ZONA A: Recoger la bandera de MetaA al brazo
        if (other.CompareTag("ZonaA") && !tieneBandera)
        {
            tieneBandera = true;

            if (banderaMetaA != null) banderaMetaA.SetActive(false); // Oculta la de MetaA
            if (banderaPlayer != null) banderaPlayer.SetActive(true);  // Muestra la del brazo

            Debug.Log("¡Bandera tomada de Zona A!");
        }

        // 2. LLEGADA A ZONA B: Entregar la bandera del brazo a MetaB
        if (other.CompareTag("ZonaB") && tieneBandera)
        {
            tieneBandera = false;

            if (banderaPlayer != null) banderaPlayer.SetActive(false); // Oculta la del brazo
            if (banderaMetaB != null) banderaMetaB.SetActive(true);   // Muestra la de MetaB

            Debug.Log("¡Bandera entregada en Zona B!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ZonaA") && !tieneBandera)
        {
            tieneBandera = true;
            if (banderaMetaA != null) banderaMetaA.SetActive(false);
            if (banderaPlayer != null) banderaPlayer.SetActive(true);
        }

        if (collision.gameObject.CompareTag("ZonaB") && tieneBandera)
        {
            tieneBandera = false;
            if (banderaPlayer != null) banderaPlayer.SetActive(false);
            if (banderaMetaB != null) banderaMetaB.SetActive(true);
        }
    }
}
