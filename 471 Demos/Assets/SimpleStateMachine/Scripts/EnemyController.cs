using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private enum State
    {
        Pace,
        Follow,
        LostPlayer,
    }

    private State currentState = State.Pace;

    [SerializeField] GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    private float speed;
    [SerializeField] float normalSpeed = 4f;
    [SerializeField] float chasingSpeed = 6f;
    private float raycastDistance = 15f;


    public float rotationSpeed = 360f; // Degrees per second when spinning
    public float spinTime = 4f;
    private float lostTimer = 0f;
    void Update()
    {
        switch (currentState)
        {
            case State.Pace:
                OnPace();
                break;
            case State.Follow:
                OnFollow();
                break;
            case State.LostPlayer:
                OnLostPlayer();
                break;
        }
    }

    void OnPace() 
    {

        //What do we do when we are pacing

        speed = normalSpeed;

        //print("Im pacing");
        target = route[routeIndex];

        MoveTo(target);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1)
        {
            routeIndex++;

            if (routeIndex >= route.Length)
            {
                routeIndex = 0;
            }
        }

        //On what condition do we switch states

        GameObject obstacle = CheckForward();

        if (obstacle != null) 
        {
            target = obstacle;
            currentState = State.Follow;
        }

    }

    void OnFollow()
    {
        //What do we do when we are following

        speed = chasingSpeed;

        //print("Im following");
        MoveTo(target);

        //On what condition do we switch states

        GameObject obstacle = CheckForward();

        if (obstacle == null)
        {
            currentState = State.Pace;
            lostTimer = spinTime;
            currentState = State.LostPlayer;
        }
    }
    void OnLostPlayer()
    {
        if (lostTimer > 0)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationStep);
            lostTimer -= Time.deltaTime;
            GameObject obstacle = CheckForward();

            if (obstacle != null)
            {
                target = obstacle;
                currentState = State.Follow;
                return;
            }
        }
        else
        {
            //print("Finished Spinning, Returning to Patrol");
            currentState = State.Pace;
        }
        //print("Lost Player");
    }

    private void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }

    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            StealthPlayerController player = hit.transform.gameObject.GetComponent<StealthPlayerController>();

            if (player != null) 
            {
                //print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            } 
        }


        return null;
    }

}
