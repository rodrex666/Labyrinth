using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_FMOD : MonoBehaviour
{
   
    private bool _control;

    private void OnEnable()
    {
        enterPlayer.OnStart_T += playMusic;
        outPlayer.OnEnd_T += stopMusic;
    }
    private void OnDisable()
    {
        enterPlayer.OnStart_T -= playMusic;
        outPlayer.OnEnd_T -= stopMusic;
    }
    void Start()
    {
        _control = false;
    }

   void playMusic()
    {
        if (!_control)
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            _control = true;
        }
    }
   void stopMusic()
    {
        if(_control)
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Stop();
            _control = false;
        }
        
    }
}
