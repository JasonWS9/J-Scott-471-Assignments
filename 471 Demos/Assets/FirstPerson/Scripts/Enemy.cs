using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 5;



    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }




    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            health -= 1;
            print("Health = " + health);
        }

    }

}
