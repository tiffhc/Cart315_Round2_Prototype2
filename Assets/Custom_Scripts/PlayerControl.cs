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

    public float JumpSpeed = 7.0f; 
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>(); 
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * Speed * Time.deltaTime;

        r.MovePosition(transform.position + move);
        _animator.SetBool("run", move.magnitude > 0);
     
     
    }
}
