using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FootSteps : MonoBehaviour
{
    public FMODUnity.EventReference FootStepsAudio;
    [Header("Playback Settings")]
    [SerializeField] private float _stepDistance = 2.5f;
    private float _stepRamdon;
    private Vector3 _prevPos;
    private float _distanceTravelled;
    // Start is called before the first frame update
    void Start()
    {
        _stepRamdon = Random.Range(0f, 0.2f);
        _prevPos = transform.position;
    }
    void Update()
    {
        
        _distanceTravelled += (transform.position - _prevPos).magnitude; 
        if(_distanceTravelled >= _stepDistance - _stepRamdon)
        {
            //Play Foot Step
            PlayFootStep();
            _stepRamdon = Random.Range(0f, 0.5f);
            _distanceTravelled = 0f;
        }
        _prevPos = transform.position;
    }
    void PlayFootStep()
    {
        FMOD.Studio.EventInstance FootStep = FMODUnity.RuntimeManager.CreateInstance(FootStepsAudio);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(FootStep, transform, GetComponent<Rigidbody>());
        FootStep.start();
        FootStep.release();
    }
}
