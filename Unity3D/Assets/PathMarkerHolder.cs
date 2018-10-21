using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathMarkerHolder : MonoBehaviour
{
    public List<Transform> pathList = new List<Transform>();
    Transform[] theArray;

    void Start()
    {
        theArray = GetComponentsInChildren<Transform>();

        pathList.Clear();

        foreach (Transform pathObj in theArray)
        {
            if (pathObj != this.transform)
            {
                pathList.Add((pathObj));
            }
        }
    }
}
