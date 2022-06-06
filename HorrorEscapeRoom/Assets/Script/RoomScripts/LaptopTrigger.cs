using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopTrigger : MonoBehaviour
{
    private Interaction interac;
    private MeshRenderer meshRender;
    public Material matOff;
    public Material matOn;

    // Start is called before the first frame update
    void Start()
    {
        interac = GetComponent<Interaction>();
        meshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interac.trigger)
        {
            meshRender.material = matOn;
        }
        else
        { 
            meshRender.material = matOff;
        }
    }
}
