using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerChallenge : MonoBehaviour
{
    public float planeSpeed = 10f;
    public float planeDir = 10f;

    
    private float forwardInput;
    private float horizontaInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move para frente o veiculo
        
        horizontaInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward *Time.deltaTime * planeSpeed * horizontaInput);
        transform.Rotate(Vector3.left * planeDir * forwardInput * Time.deltaTime);
       



        
        
        
        
      
    }
}
