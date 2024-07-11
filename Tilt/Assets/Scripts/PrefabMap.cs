using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMap : MonoBehaviour
{
    public float randNum = 8;

    public float ReturnDistY()
    {
        return transform.position.y;
    }
    
    public float ReturnRand(int maxIndex)
    {
        return Mathf.CeilToInt(UnityEngine.Random.Range(0, Mathf.Min(randNum, maxIndex + 2)));
    }
}
