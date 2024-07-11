using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpneButton : MonoBehaviour
{

    [SerializeField]
    private GameObject closeObject;
    [SerializeField]
    private GameObject openObject;

    public void Open()
    {
        openObject.SetActive(true);
        closeObject.SetActive(false);
        
    }
    
}
