using System;
using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    public float GetLeftLimit()
    {
        return GetComponent<Renderer>().bounds.min.x;
    }

    public float GetRightLimit()
    {
        return GetComponent<Renderer>().bounds.max.x;
    }
}
