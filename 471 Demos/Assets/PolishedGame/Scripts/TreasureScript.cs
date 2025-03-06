using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    [SerializeField] GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerStateManager>() != null)
        {
            manager.EndGame();
        }
    }

}
