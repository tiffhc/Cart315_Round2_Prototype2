using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateKey : MonoBehaviour
{
    public SimpleCharacterControlFree SC;

    public GameObject key; 

    private int num; 

    // Update is called once per frame
    void Update()
    {
        num = SC.numOfGearCollected;
        Debug.Log("num inside GenerateKey" + num); 
    }


}
