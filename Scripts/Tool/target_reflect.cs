using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class target_reflect : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void OnDetected();
}


public class Yanzi_Detect : target_reflect
{
    public override void OnDetected()
    {
        Debug.Log("这里有一个盐渍");
    }
}