using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{


    Vector2 movement;
    Vector2 mouseMovement;
    CharacterController controller;
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] GameObject cam;
    float cameraUpRotation = 0;

    [SerializeField] GameObject bulletSpawner;
    [SerializeField] GameObject bullet;

    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float LookX = mouseMovement.x * Time.deltaTime * mouseSensitivity;
        float LookY = mouseMovement.y * Time.deltaTime * mouseSensitivity;

        cameraUpRotation -= LookY;

        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

        transform.Rotate(Vector3.up * LookX);

        float MoveX = movement.x;
        float MoveZ = movement.y;

        Vector3 ActualMovement = (transform.forward * MoveZ) + (transform.right * MoveX);

       // Vector3 ActualMovement = new Vector3(MoveX, 0, MoveZ);

        controller.Move(ActualMovement * Time.deltaTime * playerSpeed);

    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue lookVal)
    { 
        mouseMovement = lookVal.Get<Vector2>();
    }


    void OnAttack()
    {
        Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }


}
