using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //private attributes 


    private CharacterController _characterController; 
    private Animator _animator;
    private Rigidbody r;

    private float distance = 5; 
    //public attributes
    public float Speed = 18f;

    public float RotationSpeed = 240.0f;

    public float JumpSpeed = 2.0f;

    public bool isGrounded;

    
    public Transform cam_parent; //pivot point 
    Vector2 input; 
    public Transform cam; 
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


        //moving the character 
        //Vector3 move = new Vector3(h, 0, v) * Speed * Time.deltaTime;
        Vector3 move = new Vector3(h, 0, v) * Speed;

        r.velocity = move; 
       // r.velocity = move * Speed; 
        //r.MovePosition(transform.position + move);

        _animator.SetBool("run", move.magnitude > 0);

        //do transform on player - allows smooth rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
        Vector3 rot = v * cam.transform.forward + h * cam.transform.right;

        move = transform.InverseTransformDirection(move);

        float turnAmount = Mathf.Atan2(move.x, move.z);

        transform.Rotate(0, turnAmount * RotationSpeed * Time.deltaTime, 0);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(move), RotationSpeed * Time.deltaTime); 

        //Handle the rotation
        /*
        input = new Vector2(h, v);

        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward; 
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.forward = camF;
        transform.right = camR; 
        */

        //transform.Translate(move * Speed * Time.deltaTime); 
        //transform.position += (camF * input.y + camR * input.x) * Time.deltaTime; 

        //ADJUST THE POSITION OF THE RIGID BODY WITH RESPECT 
        //transform.position = transform.position + cam_parent.transform.forward * distance * Time.deltaTime; 


        //r.MovePosition(transform.localRotation * transform.localPosition + (transform.right + transform.forward) * Time.deltaTime * Speed); 

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

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.F))
        {

        }
    }

}
