using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    Vector2 m;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m = new Vector2(0, 0);
    }

    void Update()
    {
        float xdir = m.x;
        float zdir = m.y;
        Vector3 actualmovement = new Vector3(xdir, 0 , zdir);
        print (actualmovement);

        rb.AddForce(actualmovement);
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }

}
