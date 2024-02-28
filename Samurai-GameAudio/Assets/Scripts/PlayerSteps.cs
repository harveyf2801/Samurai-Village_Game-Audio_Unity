using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    public FMOD.Studio.EventInstance footsteps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayFootstep()
    {
        Debug.Log("step");
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Footsteps");
        footsteps.setParameterByName("Terrain", 1);
        footsteps.setParameterByName("RunCrawl", 1);
        footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }
}
