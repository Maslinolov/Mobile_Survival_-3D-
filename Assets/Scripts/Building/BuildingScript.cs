using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingScript : MonoBehaviour {
    public GameObject InventoryPart, BldLoc, RightFinger;
    public GameObject[] Buildings;
    public Button UseInMenu, UseInGame, Inventory;
    GameObject Bldng;
    int chsdCell, i = 0, r = 0;
    Vector3 Loc;
    Quaternion Rot;

	// Use this for initialization
	void Start ()
    {
        UseInMenu.onClick.AddListener(UseInMen);
        UseInGame.onClick.AddListener(UseInGam);
        Inventory.onClick.AddListener(Inventor);
    }
	
	// Update is called once per frame
	void Update ()
    {
        chsdCell = InventoryScript.ChsdCell;
        Loc = BldLoc.transform.position;
        Rot = BldLoc.transform.rotation;       
        if (i == 1)
        {                 
            if (Bldng.transform.localPosition.y < -1.5F || Bldng.transform.localPosition.y > 1.5F)
            {
                i = 0;
                Destroy(BldLoc.transform.GetChild(0).gameObject);
            }
            Quaternion t = Bldng.transform.rotation;
            t.y = BldLoc.transform.rotation.y;
            Bldng.transform.rotation = t;
        }
    }

    void UseInMen()
    {
        if (InventoryScript.Inv[chsdCell, 5] == "B")
        {
            i = 1;
            InventoryPart.SetActive(false);
            RightFinger.SetActive(true);
            InventoryScript.InvOpn = false;
            for(int y = 0; y < Buildings.Length; y++)
            {                
                if (InventoryScript.Inv[chsdCell, 6] == Buildings[y].name)
                {                                      
                    Bldng = Instantiate(Buildings[y], Loc, Rot);
                    Bldng.transform.SetParent(BldLoc.GetComponent<Transform>().transform);
                    Bldng.SetActive(true);
                    r = y;
                }
            }
            
        }               
    }

    void Inventor()
    {
        if (i == 1)
        {
            i = 0;            
            Destroy(BldLoc.transform.GetChild(0).gameObject);
        }
    }

    void UseInGam()
    {
        if (i == 1 && StructureScript.BldDeny == 1)
        {
            Destroy(BldLoc.transform.GetChild(0).gameObject);
            GameObject bld = Instantiate(Buildings[r], Bldng.transform.position, Bldng.transform.rotation);
            Destroy(bld.GetComponent<Rigidbody>());
            Destroy(bld.transform.GetChild(0).gameObject);
            InventoryScript.Inv[chsdCell, 1] = "" + (int.Parse(InventoryScript.Inv[chsdCell, 1]) - 1);
            i = 0;
            StructureScript.BldDeny = 0;
            bld.SetActive(true);    
        }
    } 
}
