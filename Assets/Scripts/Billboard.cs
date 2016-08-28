using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Billboard : MonoBehaviour 
{
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

}
