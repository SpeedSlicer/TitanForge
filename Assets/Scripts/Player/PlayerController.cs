using System;
using System.Collections;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 5f;
    public InputAction playerControls;
    public InputAction upMotion;
    public InputAction stabAction;
    public InputAction slashAction;

    Vector2 moveDirection;

    public CapsuleCollider2D collider;

    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private float damage = 1;
    public bool isGrounded = false;

    [SerializeField]
    private bool jumping = false;

    [SerializeField]
    private bool sprinting = false;

    [SerializeField]
    private bool attacking = false;

    public Animator bodyAnimator;
    public Animator swordAnimator;
    public Transform transform;
    public void OnEnable()
    {
        playerControls.Enable();
        upMotion.Enable();
        stabAction.Enable();
        slashAction.Enable();

        stabAction.performed += OnSlashPerformed;
        upMotion.performed += OnJumpPerformed;
        // slashAction.performed += OnSlashPerformed;
    }

    public void OnDisable()
    {
        playerControls.Disable();
        upMotion.Disable();
        stabAction.Disable();
        slashAction.Disable();
        stabAction.performed -= OnSlashPerformed;
        upMotion.performed -= OnJumpPerformed;
        // slashAction.performed -= OnSlashPerformed;
    }

    void Start()
    {

    }

    public void Update()
    {
        var input = playerControls.ReadValue<Vector2>();
        if (GameManager.allowedMovement)
        {
            moveDirection = new Vector2(input.x, 0);
        }
        else
        {
            moveDirection = new Vector2(0, 0);
        }
        if (moveDirection.x != 0)
        {
            bodyAnimator.SetBool("isMoving", true);
            transform.localScale = new Vector3(Mathf.Sign(moveDirection.x), 1, 1);
        }
        else
        {
            bodyAnimator.SetBool("isMoving", false);
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            jumping = true;
        }
    }

    private void OnStabPreformed(InputAction.CallbackContext context)
    {
        if (GameManager.allowedMovement && !attacking)
        {
            swordAnimator.Play("Stab");
            damage = 2;
            StartCoroutine(StabWait());
        }
    }
    private void OnSlashPerformed(InputAction.CallbackContext context)
    {
        if (GameManager.allowedMovement && !attacking)
        {
            swordAnimator.Play("Slash");
            damage = 3;
            StartCoroutine(SlashWait());
        }
    }


    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
        if (isGrounded && jumping && GameManager.allowedMovement)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = false;
        }
    }

    public Boolean IsAttacking()
    {
        return attacking;
    }
    // IEnumerator Wait1Second()
    // {
    //     yield return new WaitForSeconds(1f); // Wait for another 1 second
    // }
    IEnumerator StabWait()
    {
        attacking = true;
        yield return new WaitForSeconds(0.6f);
        attacking = false;
    }
    IEnumerator SlashWait()
    {
        attacking = true;
        yield return new WaitForSeconds(1.3f);
        attacking = false;
    }
}
