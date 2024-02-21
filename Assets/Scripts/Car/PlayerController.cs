using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public string inputID;
    

    public float SpeedCar = 10f;
    public float SpeeeDir = 10f;

    private float horizontaInput;
    private float forwardInput;

    public Camera mainCamera;//primeira camera
    public Camera hoodCamera;//segunda camera
    public KeyCode switchKey;
    public KeyCode switchKey2;

    [SerializeField] private float horsePower = 200f;
    [SerializeField] float turnSpeed = 30.0f;

    public Rigidbody rig;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    [SerializeField] GameObject centerOfMass;


    void Awake()
    {
        //must give each wheel a little torque or the wheel colliders will be stuck/not work properly
        foreach (WheelCollider w in allWheels)
            w.motorTorque = 0.000001f;
    }



    // Start is called before the first frame update
    void Start()
    {
        rig.centerOfMass = centerOfMass.transform.localPosition;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move para frente o veiculo

        horizontaInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        if (Input.GetKeyDown(switchKey) || Input.GetKeyDown(switchKey2))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;

        }

        if (IsOnGround())
        {
            // transform.Translate(Vector3.forward * Time.deltaTime * SpeedCar * forwardInput);
            //transform.Rotate(Vector3.up * SpeeeDir * horizontaInput * Time.deltaTime);

            rig.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            //Turning the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontaInput);

            speed = Mathf.Round(rig.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM " + rpm);


            //foreach (WheelCollider wheel in allWheels)
            //{
            //    wheel.motorTorque = forwardInput * horsePower;
            //}
            //for (int i = 0; i < allWheels.Count; i++)
            //{
            //    if (i < 2)
            //    {
            //        allWheels[i].steerAngle = horizontaInput * turnSpeed;
            //    }
            //}

            ////print speed
            //speed = Mathf.RoundToInt(rig.velocity.magnitude * 3.6f);
            //speedometerText.SetText("Speed: " + speed + " km/h");

            ////print RPM
            //rpm = Mathf.Round((speed % 30) * 40);
            //rpmText.SetText("RPM: " + rpm);
        }

       
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        return allWheels.All(w => w.isGrounded);

        //foreach (WheelCollider wheel in allWheels)
        //{
        //    if (wheel.isGrounded)
        //    {
        //        wheelsOnGround++;
        //    }
        //}
        //if (wheelsOnGround == 4)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }

}

