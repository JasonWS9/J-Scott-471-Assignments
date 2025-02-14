using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerController : MonoBehaviour
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
    private float attackCooldown;

    private bool hasJumped = false;

    private void Start()
    {
        attackCooldown = Time.time;
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

        if (hasJumped)
        {
            ActualMovement.y = 10;

        }

        ActualMovement.y -= 200 * Time.deltaTime;


        controller.Move(ActualMovement * Time.deltaTime * playerSpeed);


        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();

        }

    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue lookVal)
    { 
        mouseMovement = lookVal.Get<Vector2>();
    }

    void OnJump()
    {
        hasJumped = true;
    }

    void OnAttack()
    {
        if (attackCooldown + 0.5f < Time.time)
        {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            attackCooldown = Time.time;
        }

    }



}
