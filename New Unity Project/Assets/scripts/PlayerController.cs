using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;
    public int continueJump;
    public bool slowFall;
    private Rigidbody rb;
    private bool isGround;
    private int continueJump_remain;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGround = true;
        if (continueJump <= 0)
            continueJump = 0;
        continueJump_remain = continueJump;
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            continueJump_remain = continueJump;
        }
    }

    void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(moveHorizontal, rb.velocity.y, moveVertical);
        rb.velocity = movement;
        if (!isGround)
        {
            if (rb.velocity.y <= 0 && slowFall)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 9/ 10, rb.velocity.z);
            }
        }
        if (Input.GetButton("Jump"))
        {
            if (isGround)
            {
                rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
            }
            else if (continueJump_remain > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
                continueJump_remain--;
            }
        }
    }
}
