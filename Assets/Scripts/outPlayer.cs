using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outPlayer : MonoBehaviour
{
    public delegate void EndTimer();
    public static event EndTimer OnEnd_T;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if (OnEnd_T != null)
                OnEnd_T();
        }
        
    }
}
