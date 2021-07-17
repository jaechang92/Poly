using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snap : MonoBehaviour
{

    // 만들수 있는 포인트인지 아닌지 확인
    // 드레그

    public List<Vector2> lCreatePoint;

    public GameObject createObj;
    private Vector3 startPoint,endPoint;
    public GameObject objectPool;

    private void Start()
    {
        if (objectPool == null)
        {
            objectPool = new GameObject();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            
            Debug.Log("Down");
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            CreateObject(createObj);
            Debug.Log("Up");
        }

    }

    public void CreateObject(GameObject obj)
    {
        Vector3 center = new Vector3((endPoint.x + startPoint.x)/2, (endPoint.y + startPoint.y)/2);
        Instantiate(obj, center, Quaternion.identity, objectPool.transform);
    }



}
