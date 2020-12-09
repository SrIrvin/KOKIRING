using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    public string id { get; private set; }

    private void Awake()
    {
        id = name + "-" + transform.position;
    }
}
