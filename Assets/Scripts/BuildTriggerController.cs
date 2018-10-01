using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTriggerController : MonoBehaviour
{
    public Rigidbody blockRB;
    public Rigidbody touchBlockRB;
    public Rigidbody nibbleRB;
    public Transform blockTF;
    public Transform touchBlockTF;
    public Transform nibbleTF;
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
        zPos -= 17;
        Vector3 newPos;
        Vector3 tempPos;

        int i = 0;
        while (i < 10)
        {
            int r = Random.Range(0, 10);
            if (r<6){
                xPos = (float)(i - 4.5);
                newPos.x = xPos;
                newPos.y = yPos;
                newPos.z = zPos;
                blockTF.position = newPos;
                Instantiate(blockRB, blockTF.parent=null);
                if(r%3 == 0){
                    //Builds the golden nibbles.
                    tempPos = newPos;
                    tempPos.y = 0.2F;
                    nibbleTF.position = tempPos;
                    Instantiate(nibbleRB, nibbleTF.parent = null);
                }
            }
            else{
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
