using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject cube;
    private Transform t;
    private float speed = 0.5f;
    void Start()
    {
        t = cube.GetComponent<Transform>();
    }

    void Update()
    {
        if (t.position.x > 10)
        {
            speed = speed * -1;
        }
        else if (t.position.x < -10)
        {
            speed = speed * -1;
        }

        t.Translate(speed, 0, 0);

    }
}
