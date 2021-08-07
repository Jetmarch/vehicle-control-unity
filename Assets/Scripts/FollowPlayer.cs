using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform positionBehindCar;
    public Transform positionOnDriverSeat;
    private float tilt = 18.5f;
    private bool isCameraOnDriverSeat;
    
    
    // Start is called before the first frame update
    void Start()
    {
        isCameraOnDriverSeat = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            isCameraOnDriverSeat = !isCameraOnDriverSeat;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isCameraOnDriverSeat)
        {
            transform.position = positionOnDriverSeat.position;
            transform.rotation = positionOnDriverSeat.rotation;
            transform.Rotate(new Vector3(tilt, positionOnDriverSeat.rotation.y, positionOnDriverSeat.rotation.z));
        }
        else
        {
            transform.position = positionBehindCar.position;
            transform.rotation = positionBehindCar.rotation;
            transform.Rotate(new Vector3(tilt, positionBehindCar.rotation.y, positionBehindCar.rotation.z));
        }
        
    }
}
