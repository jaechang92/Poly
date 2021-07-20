using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
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
    public string selectMaterial;
    public GameObject circle, circleEffect;

    private GameObject UI;

    void Init()
    {
        StartCoroutine(WaitForLoading());

    }


    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickThisMaterialUI(string name)
    {
        selectMaterial = name;
    }

    IEnumerator WaitForLoading()
    {
        while (ProcessButton.instance.MainUIObj.Length == 0 || ProcessButton.instance.MainUIObj[0] == null)
        {
            yield return null;
        }
        UI = ProcessButton.instance.MainUIObj[(int)ProcessButton.eMainUI.playUI];
        UI.transform.Find("Play/BottomMenu/Grid/Concrete").GetComponent<Button>().onClick.AddListener(() => ClickThisMaterialUI("Concrete"));
        UI.transform.Find("Play/BottomMenu/Grid/Wood").GetComponent<Button>().onClick.AddListener(() => ClickThisMaterialUI("Wood"));
        UI.transform.Find("Play/BottomMenu/Grid/Wire").GetComponent<Button>().onClick.AddListener(() => ClickThisMaterialUI("Wire"));
        UI.transform.Find("Play/BottomMenu/Grid/Spring").GetComponent<Button>().onClick.AddListener(() => ClickThisMaterialUI("Spring"));
    }

}
