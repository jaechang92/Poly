using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    public HingeJoint [] hingeJoints;
    public SpriteRenderer[] jointPoint;
        
    void Start()
    {
        jointPoint = gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < jointPoint.Length; i++)
        {
            jointPoint[i].transform.localScale = new Vector3(jointPoint[i].transform.localScale.x / transform.localScale.x, jointPoint[i].transform.localScale.y, jointPoint[i].transform.localScale.z);
            //jointPoint[i].transform.localScale.Set(jointPoint[i].transform.localScale.x / transform.localScale.x, jointPoint[i].transform.localScale.y, jointPoint[i].transform.localScale.z);
        }
        hingeJoints = gameObject.GetComponents<HingeJoint>();
        Joint(hingeJoints[0],GameManager.instance.snapObject);
    }


    void Update()
    {
        switch (GameManager.instance.mode)
        {
            case GameManager.eGameMode.UIMode:
                for (int i = 0; i < jointPoint.Length; i++)
                {
                    jointPoint[i].enabled = true;
                }
                break;
            case GameManager.eGameMode.PlayMode:
                for (int i = 0; i < jointPoint.Length; i++)
                {
                    jointPoint[i].enabled = false;
                }
                break;
            default:
                break;
        }
    }

    public void Joint(HingeJoint my, HingeJoint other)
    {
        my.connectedBody = other.GetComponent<Rigidbody>();
        other.connectedBody = my.GetComponent<Rigidbody>();
    }

}
