using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snap : MonoBehaviour, IPointerDownHandler
{
    public static Snap instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    // 만들수 있는 포인트인지 아닌지 확인
    // 드레그

    public List<Vector2> lCreatePoint;

    public GameObject createObj;
    private Vector3 startPoint,endPoint;
    public List<GameObject> lCreateObject;
    public GameObject objectPool;

    private bool isUI = false;

    private void Start()
    {
        if (objectPool == null)
        {
            objectPool = new GameObject();
            objectPool.name = "ObjectPool";
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            if (isUI)
            {
                isUI = false;
                return;
            }
            
            createObj = Resources.Load(UIManager.instance.selectMaterial) as GameObject;
            CreateObject(createObj);
        }

    }

    public void CreateObject(GameObject obj)
    {
        Vector3 center = new Vector3((endPoint.x + startPoint.x)/2, (endPoint.y + startPoint.y)/2);
        Instantiate(obj, center, Quaternion.Euler(0,90,0), objectPool.transform);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        if (eventData.selectedObject.layer == LayerMask.GetMask("UI"))
        {
            isUI = true;
        }
    }
}
