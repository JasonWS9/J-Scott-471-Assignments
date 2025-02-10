using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float bulletSpeed = 50;

    bool bulletActive = true;
    private float startTime;
    [SerializeField] float bulletTime = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
    }



    void Update()
    {

        if (Time.time > startTime + bulletTime)
        {
            {
                bulletActive = false;
            }
        }
        if (bulletActive == true)
        {
            rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
           Destroy(gameObject);
        }
    }
}
