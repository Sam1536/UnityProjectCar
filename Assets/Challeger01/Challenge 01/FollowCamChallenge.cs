using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamChallenge : MonoBehaviour
{
    public GameObject playerFollow;
    public Vector3 offSet = new Vector3(0,4,-10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerFollow.transform.position + offSet;
        
    }
}
