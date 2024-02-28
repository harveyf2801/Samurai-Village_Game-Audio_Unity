using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    private enum CURRENT_TERRAIN:int { GRASS = 0, GRAVEL = 1, PATH = 2, WOOD = 3, SAND = 4 };

    [SerializeField]
    private CURRENT_TERRAIN currentTerrain;

    public FMOD.Studio.EventInstance footsteps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTerrain();
    }

    private void UpdateTerrain()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                currentTerrain = CURRENT_TERRAIN.GRASS;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Gravel"))
            {
                currentTerrain = CURRENT_TERRAIN.GRAVEL;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Path"))
            {
                currentTerrain = CURRENT_TERRAIN.PATH;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Wood"))
            {
                currentTerrain = CURRENT_TERRAIN.WOOD;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Sand"))
            {
                currentTerrain = CURRENT_TERRAIN.SAND;
                break;
            }
            
            // else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
            // {
            //     currentTerrain = CURRENT_TERRAIN.WATER;
            // }
        }
    }

    private void PlayFootstep()
    {
        Debug.Log("Ran on ");
        Debug.Log(currentTerrain);

        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Footsteps");
        footsteps.setParameterByName("Terrain", (float)currentTerrain);
        footsteps.setParameterByName("RunCrawl", 1);
        footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }
}
