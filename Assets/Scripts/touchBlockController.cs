using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchBlockController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void touchBegin(){
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(gameObject, 2);
    }
    void touchEnded(){
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}
