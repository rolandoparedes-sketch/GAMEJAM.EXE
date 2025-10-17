using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main_Player : MonoBehaviour
{
    [SerializeField] protected int health = 100;
    [SerializeField] protected GameObject candy;
    public InputSystem_Actions inputs;
    public Rigidbody2D rb;

    public Vector2 moveInput;

    public float moveSpeed = 5f;
    public float PlayerHp;
    public float KnockbackForce;

    public Transform flashlight;

    private void Awake()
    {
        inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputs.Player.Move.started -= OnMove;
        inputs.Player.Move.performed -= OnMove;
        inputs.Player.Move.canceled -= OnMove;
        inputs.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {

        Vector2 move = moveInput.normalized;
        transform.position += (Vector3)move * moveSpeed * Time.deltaTime;


        if (move != Vector2.zero)
        {
            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
    }
}
