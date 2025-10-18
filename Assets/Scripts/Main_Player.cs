using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main_Player : MonoBehaviour
{
    public Transform firePoint;           
    public GameObject currentWeapon;
    public InputSystem_Actions inputs;
    public Transform flashlight; 

    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    private Vector2 moveInput;
    private Vector2 lookDirection = Vector2.down; 
    private bool isRunning;

   
    public float stamina = 100f;
    public float maxStamina = 100f;
    public float staminaDrain = 20f;
    public float staminaRegen = 10f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            currentWeapon = other.gameObject;    
            other.gameObject.SetActive(false);   
            Debug.Log("Arma recogida!");
        }
    }
    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
            Destroy(currentWeapon);

        currentWeapon = Instantiate(weaponPrefab, firePoint.position, firePoint.rotation, firePoint);
    }

    private void HandleShooting()
    {
        if (currentWeapon == null) return;

        if (inputs.Player.Fire.triggered)
        {
            Weapon weapon = currentWeapon.GetComponent<Weapon>();
            if (weapon != null)
                weapon.Fire(firePoint.position, lookDirection);
        }
    }

    private void Awake()
    {
        inputs = new InputSystem_Actions();
        stamina = maxStamina;
    }

    private void OnEnable()
    {
        inputs.Enable();

        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;

        inputs.Player.Run.started += ctx => isRunning = true;
        inputs.Player.Run.canceled += ctx => isRunning = false;
    }

    private void OnDisable()
    {
        inputs.Player.Move.started -= OnMove;
        inputs.Player.Move.performed -= OnMove;
        inputs.Player.Move.canceled -= OnMove;

        inputs.Player.Run.started -= ctx => isRunning = true;
        inputs.Player.Run.canceled -= ctx => isRunning = false;

        inputs.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
            lookDirection = moveInput;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShooting(); 

    }

    private void HandleMovement()
    {
        float currentSpeed = walkSpeed;

        if (isRunning && stamina > 0 && moveInput != Vector2.zero)
        {
            currentSpeed = runSpeed;
            stamina -= staminaDrain * Time.deltaTime;
        }
        else
        {
            stamina += staminaRegen * Time.deltaTime;
        }

        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        transform.position += (Vector3)(moveInput * currentSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        if (lookDirection == Vector2.zero) return;

        
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        

       
        if (flashlight != null)
            flashlight.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
