using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] int speed = 5;
    [SerializeField] float sprintMultiplier = 1.5f;
    [SerializeField] int jumpForce = 2;
    [SerializeField] float checkGroundRadius = 0.2f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float rotationSpeed = 10f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    CharacterController Player;
    private Vector3 velocity;
    public bool isGrounded { get; private set; }
    public bool isSprinting { get; private set; }
    public bool isInteracting { get; private set; }

    // Start is called before the first frame update
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere( groundCheck.position,  checkGroundRadius);
    }
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position , checkGroundRadius, groundMask);
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        isInteracting= Input.GetKeyDown(KeyCode.F);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        
        float h= Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0, v).normalized;

        direction = transform.TransformDirection(direction);
        Vector3 lookDirection = direction;

        if (direction != Vector3.zero)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, lookDirection, rotationSpeed * Time.deltaTime,0F);

            transform.rotation = Quaternion.LookRotation(newDirection);
        }


        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        Player.Move((direction * currentSpeed + velocity)  * Time.deltaTime);

    }
    public float getHealth()
    {
        return health;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
