using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1Script : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {        
        StructureScript.Trg[0] = 1;        
    }

    void OnTriggerExit(Collider other)
    {
        StructureScript.Trg[0] = 0;        
    }
}
