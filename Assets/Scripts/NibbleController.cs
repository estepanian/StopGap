using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NibbleController : MonoBehaviour
{
    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if(go.name == "Guy"){
            manager.SendMessage("AddNibble", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
