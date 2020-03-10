using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowing : MonoBehaviour
{
    public Transform PlayerTransform;

    public Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f; 

    public bool LookAtPlayer = false; 

    public bool RotateAroundPlayer = true;

    public float RotationSpeed = 5.0f; 
        // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
            Quaternion camTurn = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            _cameraOffset = camTurn * _cameraOffset; 
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor); 

        if(LookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform); 
        }
    }
}
