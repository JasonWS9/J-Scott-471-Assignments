using UnityEngine;

public class Enemy : MonoBehaviour
{

    int health = 5;



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



    void OnTriggerEnter()
    {
        health -= 1;
    }

}
