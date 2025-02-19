using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform player;
    public Vector3 offset = new Vector3(0,15,-8);


    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
