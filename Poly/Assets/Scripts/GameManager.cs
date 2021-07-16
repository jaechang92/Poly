using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum eGameMode
    {
        UIMode,
        PlayMode,

        Max,
    }

    // 모드에 따른 캠 설정
    public struct SetCamData
    {
        public Vector3 UIPos;
        public Vector3 PlayPos;

    }
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

    public eGameMode mode;
    public Transform camTr;

    void Start()
    {
        if (camTr == null)
        {
            camTr = Camera.main.transform;
        }
    }

    void Update()
    {
        GameLogic();
    }

    public GameObject uiFilter;
    public void GameLogic()
    {
        switch (mode)
        {
            case eGameMode.UIMode:
                if (uiFilter == null) { uiFilter = ProcessButton.instance.MainUIObj[(int)ProcessButton.eMainUI.playUI].transform.Find("Play/Filter").gameObject; }
                uiFilter.SetActive(true);
                Camera.main.orthographic = true;
                break;
            case eGameMode.PlayMode:
                if (uiFilter == null) { uiFilter = ProcessButton.instance.MainUIObj[(int)ProcessButton.eMainUI.playUI].transform.Find("Play/Filter").gameObject; }
                uiFilter.SetActive(false);
                Camera.main.orthographic = false;
                break;
            case eGameMode.Max:
                break;
            default:
                break;
        }

    }



}
