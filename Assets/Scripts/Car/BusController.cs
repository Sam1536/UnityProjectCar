using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    public float SpeedCar = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move para frente o veiculo

        transform.Translate(Vector3.forward * Time.deltaTime * SpeedCar);



        
        
        
        
      
    }
}
