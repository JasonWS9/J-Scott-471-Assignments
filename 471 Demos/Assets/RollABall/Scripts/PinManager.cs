using UnityEngine;
using UnityEngine.SceneManagement;

public class PinManager : MonoBehaviour
{

    private float fallAngle = 80f;
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player") || other.CompareTag("DeathPlane")) 
        {
            print(other);
            //Destroy(gameObject, 4f);
        }
    }

    private float score;

    void Update()
    {

        float xAngle = Mathf.Abs(transform.eulerAngles.x);
        float zAngle = Mathf.Abs(transform.eulerAngles.z);

        if (xAngle > fallAngle && xAngle < 181)
        {
            Debug.Log("fall");
            Destroy(gameObject, 2f);
        }
        if (zAngle > fallAngle && zAngle < 181)
            {
                Debug.Log("fall");
                Destroy(gameObject, 2f);

            }
    }
}
