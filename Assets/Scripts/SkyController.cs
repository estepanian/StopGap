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
        //Operation: make sky spin
        m_EulerAngleVelocity = new Vector3(0, 2, 0);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //OMSS
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
    //ends game
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("GameManager").SendMessage("GameOver");
    }
}