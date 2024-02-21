using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam2 : MonoBehaviour
{
    public GameObject playerFollow;
    public Vector3 offSet02 = new Vector3(0, 2, 1);
    
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerFollow.transform.position + offSet02;

       
    }

}



    