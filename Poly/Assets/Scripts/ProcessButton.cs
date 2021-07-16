using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessButton : MonoBehaviour
{
    public static ProcessButton instance;
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



    public enum eMainUI
    {
        mainLobby,
        playUI,


        max,
    }

    public GameObject[] MainUIObj = new GameObject[(int)eMainUI.max];


    void Init()
    {
        MainUIObj[(int)eMainUI.mainLobby].transform.Find("PlayBtn").GetComponent<Button>().onClick.AddListener(Play);
    }

    void Start()
    {
        for (eMainUI i = 0; i < eMainUI.max; i++)
        {
            switch (i)
            {
                case eMainUI.mainLobby:
                    MainUIObj[(int)i] = GetPrefabs("MainLobby");
                    break;
                case eMainUI.playUI:
                    MainUIObj[(int)i] = GameObject.Find("UI");
                    break;
                case eMainUI.max:
                    break;
                default:
                    break;
            }
        }



    }

    void Update()
    {

    }


    void Play()
    {
        
    }


    public GameObject GetPrefabs(string prefabname)
    {
        GameObject obj;
        
        obj = Instantiate(Resources.Load(prefabname) as GameObject);

        if (GameManager.instance.camTr == null)
        {
            GameManager.instance.camTr = Camera.main.transform;
        }
        obj.transform.parent = GameManager.instance.camTr;

        return obj;
    }

}

