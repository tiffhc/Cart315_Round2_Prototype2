using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //private attributes 


    private CharacterController _characterController; 
    private Animator _animator;
    private Rigidbody r; 
   
    private float Gravity = 20.0f; 
    //public attributes
    public float Speed = 18f;

    public float RotationSpeed = 240.0f;

    public float JumpSpeed = 2.0f;

    public bool isGrounded; 
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>(); 
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>(); 
    }

    /*
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
        }
    }
    */ 

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(h, 0, v) * Speed * Time.deltaTime;

        r.MovePosition(transform.position + move);
        _animator.SetBool("run", move.magnitude > 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f); 

        //for jumping 
        Vector3 jump = new Vector3(0, 0, 0);

        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                _animator.SetBool("is_in_air", true);
                r.AddForce(jump * JumpSpeed, ForceMode.Impulse);
                isGrounded = false;
                //r.AddForce(Vector3.up * JumpSpeed);
            }
        }
        else
        {
            _animator.SetBool("is_in_air", false);
            isGrounded = true;
            //set the character running
            _animator.SetBool("run", move.magnitude > 0);

        }
    }

}
