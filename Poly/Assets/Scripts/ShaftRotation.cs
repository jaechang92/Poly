using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftRotation : MonoBehaviour
{
    public float rotSpeed;

    private RectTransform tr;

    void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    void Update()
    {
        tr.Rotate(Vector3.forward * Time.deltaTime * rotSpeed, Space.Self);
    }
}
