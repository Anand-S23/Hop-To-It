using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private PhotonView view;

    private float inputX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool grounded = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            body.velocity = new Vector2(inputX * moveSpeed, body.velocity.y);

            bool jumpKeyPressed = (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W));
            if (jumpKeyPressed && grounded)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground") {
            grounded = true;
        }
    }
}
