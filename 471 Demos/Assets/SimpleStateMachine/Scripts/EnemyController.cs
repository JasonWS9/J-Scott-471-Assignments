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
    private float speed = 10f;

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

    }

    void OnFollow()
    {
        //What do we do when we are following
        print("Im following");

        //On what condition do we switch states
    }

    private void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }

}
