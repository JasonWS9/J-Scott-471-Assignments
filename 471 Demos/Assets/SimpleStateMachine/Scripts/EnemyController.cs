using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private enum State
    {
        Pace,
        Follow,
    }

    private State currentState = State.Pace;

    [SerializeField] GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    private float speed = 5f;

    private float raycastDistance = 15f;

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
        }
    }

    void OnPace() 
    {
        //What do we do when we are pacing
        print("Im pacing");
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
        print("Im following");
        MoveTo(target);

        //On what condition do we switch states

        GameObject obstacle = CheckForward();

        if (obstacle == null)
        {
            currentState = State.Pace;
        }
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
            FirstPersonController player = hit.transform.gameObject.GetComponent<FirstPersonController>();

            if (player != null) 
            {
                print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            } 
        }


        return null;
    }

}
