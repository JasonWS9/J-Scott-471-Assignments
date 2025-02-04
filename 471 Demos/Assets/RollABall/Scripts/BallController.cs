using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

 public class BallController : MonoBehaviour
{
    Vector2 m;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m = new Vector2(0, 0);
    }

    private float speedMult = 1.5f;

    void Update()
    {
        float xdir = m.x;
        float zdir = m.y;
        Vector3 actualmovement = new Vector3(xdir, 0 , zdir);
        //print (actualmovement);

        rb.AddForce(actualmovement * speedMult);
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("DeathPlane"))
        {
            print (other);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
