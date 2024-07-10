using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport2 : MonoBehaviour
{
    Vector3 pos;
    public Vector3 ReturnTelXY()
    {
        pos = transform.position;
        return pos;
    }
}
