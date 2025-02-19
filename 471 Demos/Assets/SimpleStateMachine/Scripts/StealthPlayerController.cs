using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StealthPlayerController : MonoBehaviour
{


    Vector2 movement;
    CharacterController controller;
    [SerializeField] float playerSpeed = 10f;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {


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
    }



    private void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("SimpleState");
    }


}
