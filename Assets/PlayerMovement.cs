using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public Rigidbody2D rb;
    private bool isDashButtonDown;
    [SerializeField] private LayerMask dashLayerMask;

    Vector2 movement;
    Vector3 moveDir;

  void Update() {
        MovementInput();

        if (Input.GetKey(KeyCode.Space)) {
            isDashButtonDown = true;

        }
    }

    private void FixedUpdate() {
        rb.velocity = movement * moveSpeed;

        if (isDashButtonDown) {
            float dashAmount = 5f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;
            
            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if (raycastHit2d.collider !=null) {
                dashPosition = raycastHit2d.point;
            }

            rb.MovePosition(dashPosition);
            isDashButtonDown = false;

        }
    }


    void MovementInput () {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

            movement = new Vector2(mx,my).normalized;
    }

}