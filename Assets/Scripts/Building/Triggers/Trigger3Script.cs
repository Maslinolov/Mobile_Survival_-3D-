using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3Script : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {     
        StructureScript.Trg[2] = 1;
    }

    void OnTriggerExit(Collider other)
    {
        StructureScript.Trg[2] = 0;      
    }
}
