using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchBlockController : MonoBehaviour
{
    public Text blockCountText;
    public GameObject manager;
	string blockCountString;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
        blockCountText = GameObject.Find("BlockCount Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        blockCountString = blockCountText.text;
    }
    void touchBegin(){
        if(blockCountString != "0"){
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            manager.SendMessage("RemoveNibble", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject, 3);
        }else{
            manager.SendMessage("OOM", SendMessageOptions.DontRequireReceiver);
        }

    }
    void touchEnded(){
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}
