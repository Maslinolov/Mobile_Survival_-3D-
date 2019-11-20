using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

    public GameObject SpwnP0, SpwnP1, Tree, Log;
    public int count = 0;    

    void Update () {
		if(count == 10)
        {
            Instantiate(Log, SpwnP0.transform.position, SpwnP0.transform.rotation);
            Instantiate(Log, SpwnP1.transform.position, SpwnP1.transform.rotation);
            Destroy(Tree);
        }
	}
}
