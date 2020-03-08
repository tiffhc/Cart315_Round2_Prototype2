using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //private attributes 

    GameObject player; 
    private Animator _animator;

    private Vector3 _moveDirection = Vector3.zero; 
    //public attributes
    public float Speed = 2.5f;

    public float RotationSpeed = 240.0f;

    public float JumpSpeed = 7.0f; 
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        player.transform.position += (move * Speed) * Time.deltaTime; 
        
        //get Input for axis (up down left right)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

   
        _animator.SetBool("run", move.magnitude > 0); 
        
    }
}
