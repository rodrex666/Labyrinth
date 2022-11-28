using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterPlayer : MonoBehaviour
{
    public delegate void StartTimer();
    public static event StartTimer OnStart_T;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (OnStart_T != null)
                OnStart_T();
        }
    }
       
}
