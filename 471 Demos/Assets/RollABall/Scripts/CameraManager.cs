using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform player;
    private Vector3 offset = new Vector3(0, 5, -6);


    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
        }
    }
}
