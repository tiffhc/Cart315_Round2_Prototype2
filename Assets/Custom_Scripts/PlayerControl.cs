using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //private attributes 
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
        //get Input for axis (up down left right)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * camForward_Dir + h * Camera.main.transform.right; 
        
        if (move.magnitude < 1f)
        {
            move.Normalize(); 
        }

        _animator.SetBool("run", move.magnitude > 0); 
        
    }
}
