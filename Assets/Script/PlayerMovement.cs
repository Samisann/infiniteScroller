using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float jump = 8f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float timeToJump= 0.3f;



    private bool isGrounded = false;
    private bool isJump = false;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);
                if(isGrounded && Input.GetButtonDown("Jump"))
        {
            isJump = true;
            rb.velocity = Vector2.up * jump;
        }

        if(isJump && Input.GetButton("Jump"))
        {
            if(timer < timeToJump)
            {
                rb.velocity = Vector2.up * jump;
                timer += Time.deltaTime;
            }else{
                isJump = false; 
            }
        }

        if(Input.GetButton("Jump"))
        {
            isJump = false;
            timer = 0;
        }
    }
}
