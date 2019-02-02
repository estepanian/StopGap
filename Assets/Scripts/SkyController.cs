using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    //Make sure you attach a Rigidbody in the Inspector of this GameObject
    Rigidbody rb;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, 2, 0);

        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
    //ends game
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("GameManager").SendMessage("GameOver");
    }
}