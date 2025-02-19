using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StealthPlayerController : MonoBehaviour
{


    Vector2 movement;
    CharacterController controller;
    private float playerSpeed;
    private float normalSpeed = 5f;
    private float boostedSpeed = 10f;

    private float speedBoostDuration = 1f;
    private float speedBoostCooldown = 3f;
    private bool canSprint = true;

    private void Start()
    {
        print("Get to the goal without being detected");
        print("Dont Let Enemies See Or Touch You!");
        print("Movement: WASD Speed Boost: LShift");


        playerSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Debug.Log(playerSpeed);

        float MoveX = movement.x;
        float MoveZ = movement.y;

        Vector3 ActualMovement = (transform.forward * MoveZ) + (transform.right * MoveX);


        controller.Move(ActualMovement * Time.deltaTime * playerSpeed);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }



    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnSprint(InputValue sprintVal)
    {
        if (canSprint)
        {
            StartCoroutine(SpeedBoost());
        }
    }
    
    IEnumerator SpeedBoost()
    {
        canSprint = false;
        playerSpeed = boostedSpeed;
        yield return new WaitForSeconds(speedBoostDuration);
        playerSpeed = normalSpeed;

        yield return new WaitForSeconds(speedBoostCooldown);
        canSprint = true;
    }

    /*
        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            EnemyController enemy = hit.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                GameOver();
            }
        }
    */
    void OnTriggerEnter(Collider collider)
    {
        EnemyController enemy = collider.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            GameOver();
        }

        if (collider.CompareTag("Goal"))
        {
            SceneManager.LoadScene("SimpleState");
            print("You Win!");
            print("You Win!");
            print("You Win!");
            print("You Win!");
        }
    
    }



    private void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("SimpleState");
    }


}
