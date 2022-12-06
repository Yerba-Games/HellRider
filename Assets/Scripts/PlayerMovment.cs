using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;
public class PlayerMovment : MonoBehaviour
{
    Actions input;
    [SerializeField] [Foldout("Settings")] float Speed, Jump, health=100f;
    [SerializeField] [Foldout("Settings")] Camera playerCamera;
    private Rigidbody rb;
    private InputAction move;
    private Vector3 forceDirection = Vector3.zero;
    private void OnEnable()
    {
        input.Player.Jump.started += DoJump;
        move = input.Player.Move;
        input.Player.Enable();
    }
    private void OnDisable()
    {
        input.Player.Jump.started -= DoJump;
        input.Player.Disable();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new Actions();

    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * Speed;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * Speed;
        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > Speed * Speed)
            rb.velocity = new Vector3(Mathf.Clamp(horizontalVelocity.x, 0, 1), 0, Mathf.Clamp(horizontalVelocity.z, 0, 1)) * Speed + Vector3.up * rb.velocity.y;
        LookAt();
    }
    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * Jump;
        }
    }
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position - (Vector3.up * 0.25f), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void HitPlayer(float damage)
    {
        health -= damage;
        death();
    }
    void death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
