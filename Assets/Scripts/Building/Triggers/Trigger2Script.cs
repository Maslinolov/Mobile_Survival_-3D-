using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2Script : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {      
        StructureScript.Trg[1] = 1;
    }

    void OnTriggerExit(Collider other)
    {
        StructureScript.Trg[1] = 0;        
    }
}
