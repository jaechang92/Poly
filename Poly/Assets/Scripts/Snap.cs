using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snap : MonoBehaviour
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

    public bool isUI = false;
    public float snapSize = 1;

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
        switch (GameManager.instance.mode)
        {
            case GameManager.eGameMode.UIMode:
                if (Input.GetMouseButtonDown(0))
                {
                    startPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                    startPoint = ConvertGrid(startPoint, snapSize);
                    if (!isUI)
                    {
                        CircleEffectOnOff(Input.mousePosition, true);
                    }



                }

                if (Input.GetMouseButtonUp(0))
                {
                    endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                    endPoint = ConvertGrid(endPoint, snapSize);


                    if (isUI)
                    {
                        isUI = false;
                        return;
                    }
                    CircleEffectOnOff(startPoint, false);
                    createObj = Resources.Load(UIManager.instance.selectMaterial) as GameObject;
                    CreateObject(createObj);
                }
                break;
            case GameManager.eGameMode.PlayMode:
                CircleEffectOnOff(startPoint, false);
                break;
            default:
                break;
        }
        

    }

    public void CreateObject(GameObject obj)
    {
        if (startPoint == endPoint)
        {
            return;
        }
        Vector3 center = new Vector3((endPoint.x + startPoint.x)/2, (endPoint.y + startPoint.y)/2);
        float distance = Vector3.Distance(startPoint, endPoint);
        Debug.Log(distance);
        GameObject cObject = Instantiate(obj, center, Quaternion.Euler(0,0,0), objectPool.transform);
        cObject.transform.localScale = new Vector3(distance, cObject.transform.localScale.y, cObject.transform.localScale.z);
        float angle = Mathf.Rad2Deg * Mathf.Atan2((endPoint.y - startPoint.y), (endPoint.x - startPoint.x));
        if (endPoint.x - startPoint.x < 0)
        {
            angle += 180;
        }
        cObject.transform.localRotation = Quaternion.Euler(0, 0, angle);

    }

   
    public void CircleEffectOnOff(Vector3 startPoint,bool onOff)
    {
        UIManager.instance.circle.SetActive(onOff);
        UIManager.instance.circleEffect.SetActive(onOff);
        UIManager.instance.circle.transform.position = startPoint;
        UIManager.instance.circleEffect.transform.position = startPoint;
    }

    public Vector3 ConvertGrid(Vector3 v3 ,float converSize)
    {
        if (converSize == 0)
        {
            converSize = 1;
        }
        v3.Set(Mathf.Round(v3.x * converSize) / converSize, Mathf.Round(v3.y * converSize) / converSize, Mathf.Round(v3.z * converSize) / converSize);
        return v3;
    }

}
