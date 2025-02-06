using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    float bulletSpeed = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        rb.AddForce(transform.forward * bulletSpeed);
    }
}
