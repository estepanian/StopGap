using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private GameObject guy;
    // Start is called before the first frame update
    void Start()
    {
        guy = GameObject.Find("Guy");
    }

    // Update is called once per frame
    int destroyTime = 10; 
    private void Update() { 
        if((Mathf.Abs(transform.position.z - guy.transform.position.z)) > 2){
            Destroy(gameObject, destroyTime);
        }
    }
}
