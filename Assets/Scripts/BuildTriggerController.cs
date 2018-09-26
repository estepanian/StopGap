using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTriggerController : MonoBehaviour
{
    public Rigidbody blockRB;
    public Rigidbody touchBlockRB;
    public Transform blockTF;
    public Transform touchBlockTF;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void buildRow(float zPos){

        float xPos;
        float yPos = (float)-.5;
        zPos -= 16;
        Vector3 newPos;

        int i = 0;
        while (i < 9)
        {
            int r = Random.Range(0, 10);
            if(r<6){
                xPos = (float)(i - 4.5);
                newPos.x = xPos;
                newPos.y = yPos;
                newPos.z = zPos;
                blockTF.position = newPos;
                Instantiate(blockRB, blockTF.parent=null);
            }else{
                xPos = (float)(i - 4.5);
                newPos.x = xPos;
                newPos.y = yPos;
                newPos.z = zPos;
                touchBlockTF.position = newPos;
                Instantiate(touchBlockRB, touchBlockTF.parent = null);
            }

            i += 1;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if(go.tag == "Player"){
            //Creates a new trigger
            Vector3 pos = GetComponent<Transform>().position;
            pos.z -= 1;
            GetComponent<Transform>().position = pos;
            buildRow(pos.z);
        }
    }
}
