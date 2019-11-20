using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureScript : MonoBehaviour {
    public GameObject Structure;
    public static int[] Trg = new int[4];
    static public int BldDeny = 0;
    bool i = false;
    Vector3 pos;
	
	
	// Update is called once per frame
	void Update ()
    {        
        if (Trg[0] == 0)
        {
            Structure.transform.Rotate(-1F, 0, 0);
        }
        if (Trg[1] == 0)
        {
            Structure.transform.Rotate(1F, 0, 0);
        }
        if (Trg[2] == 0)
        {
            Structure.transform.Rotate(0, 0, -1F);
        }
        if (Trg[3] == 0)
        {
            Structure.transform.Rotate(0, 0, 1F);
        }
        if (Trg[0] == 1 && Trg[1] == 1 && Trg[2] == 1 && Trg[3] == 1 && i == true)
            BldDeny = 1;
        else
            BldDeny = 0;                
	}

    void OnTriggerEnter(Collider other)
    {        
        if(other.tag == "Terrain")
        {
            i = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        i = false;
    }
}
