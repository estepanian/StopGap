using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    public LayerMask touchLayer;
    private GameObject touchedObject;
    private List<GameObject> touchList;
    private GameObject[] oldGOList;
    private RaycastHit hit;
    void Start()
    {
        touchList = new List<GameObject>();
        offset = transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;   
    }
    void Update()
    {
        if(Input.touchCount > 0){
            oldGOList = new GameObject[touchList.Count];
            touchList.CopyTo(oldGOList);
            touchList.Clear();
            foreach (Touch t in Input.touches){
                Ray ray = GetComponent<Camera>().ScreenPointToRay(t.position);
                if(Physics.Raycast(ray,out hit, touchLayer)){
                    touchedObject = hit.transform.gameObject;
                    touchList.Add(touchedObject);
                    switch(t.phase){
                        case TouchPhase.Began:
                            touchedObject.SendMessage("touchBegin", hit.point, SendMessageOptions.DontRequireReceiver);
                            break;

                    }
                }
            }
            foreach(GameObject go in oldGOList){
                if(!touchList.Contains(go)){
                    go.SendMessage("touchEnded", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
