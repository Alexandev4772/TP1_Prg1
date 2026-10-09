using UnityEngine;

public class XBalaMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    private float velocidad = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
