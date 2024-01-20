using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject dialogOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = joystick.Horizontal;
        change.y = joystick.Vertical;
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (dialogOpen.activeInHierarchy)
        {
            animator.SetBool("moving", false);
        }

        else
        {
            if (change != Vector3.zero)
            {
                MoveCharacter();
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", change.y);
                animator.SetBool("moving", true);
            }

            else
            {
                animator.SetBool("moving", false);
            }
        }
    }

    void MoveCharacter()
    {
        if (dialogOpen.activeInHierarchy)
        {
            myRigidbody.MovePosition(transform.position + change * 0 * Time.deltaTime);
        }

        else {
            myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
        }
    }
}
