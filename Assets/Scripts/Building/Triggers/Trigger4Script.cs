﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger4Script : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {  
        StructureScript.Trg[3] = 1;
    }

    void OnTriggerExit(Collider other)
    {
        StructureScript.Trg[3] = 0;       
    }
}
