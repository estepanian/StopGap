using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuyController : MonoBehaviour
{
    public float staticSpeed;
    public float controlSpeed;
    private Rigidbody rb = new Rigidbody();
    private Gyroscope gyro;
    private bool isGyro;
    public float xRotation = 0;
    public float yRotation = 0;

    public Text yrot;

    // Start is called before the first frame update
    void Start()
    {
        isGyro = false;
        rb = GetComponent<Rigidbody>();
        if(SystemInfo.supportsGyroscope){
            gyro = Input.gyro;
            gyro.enabled = true;
            isGyro = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Handles all the complicated controls and God's hand.
        float hInput = Input.GetAxis("Horizontal");
        float vInput = 0;

        if (isGyro){

            if(SystemInfo.operatingSystem.Contains("Android")){
                yRotation += Input.gyro.rotationRateUnbiased.y;
                xRotation += Input.gyro.rotationRateUnbiased.x;
                hInput = yRotation/10;
                vInput = xRotation/10;
            }
            else if(SystemInfo.operatingSystem.Contains("iPhone") || SystemInfo.operatingSystem.Contains("iOS")){
                float yRot = gyro.attitude.y;
                float xRot = gyro.attitude.x;
                hInput = yRot * 4;
                vInput = xRot;
            }
        }
        else{
            yrot.enabled = true;
            yrot.text = "no gyro detected";
        }
        //if(Input.touchCount > 0){
        //    Vector3 yForce = new Vector3(0, 300, 0);
        //    rb.AddForce(yForce);
        //}
        Vector3 cForce = new Vector3(0, 0, -1 - vInput);
        Vector3 hForce = new Vector3(hInput, 0, 0);

        rb.AddForce(cForce * staticSpeed);
        rb.AddForce(hForce * controlSpeed * Time.deltaTime);

    }
}
