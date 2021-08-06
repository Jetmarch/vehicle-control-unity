using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int vehicleSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Let's move that bloody car
        transform.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed);
    }
}
