using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingScript : MonoBehaviour {
    public GameObject Information, RopeI, FirePlaceI, CraftingTableI, StoneAxeI;
    public Button Rope, CraftingTable, Fireplace, StoneAxe, Craft;
    int Rp = 0, CrftTbl = 0, Hatchet = 0, FireP = 0;
    int[] Chsdcell;

    // Use this for initialization
    void Start ()
    {
        Rope.onClick.AddListener(Rop);
        CraftingTable.onClick.AddListener(CraftingTabl);
        Fireplace.onClick.AddListener(Fireplac);
        StoneAxe.onClick.AddListener(StoneAx);
        Craft.onClick.AddListener(Crft);
	}
	
	// Update is called once per frame
	void Update ()
    {	
        
	}

    void SearchRes(string [,] Res, int U)
    {
        for (int i = 0; i < 12; i++)
        {
            if (InventoryScript.Inv[i, 0] == Res[U, 0])
                Chsdcell[U] = i;
        }
    }

    void CraftPart(int AmOfINgr, int[] Chk, string[,] Res, int U, int p, string[,] NwItem)
    {
        for (; U < AmOfINgr; U++)
        {
            SearchRes(Res, U);
            if (InventoryScript.Inv[Chsdcell[U], 0] != null && InventoryScript.Inv[Chsdcell[U], 0] == Res[U, 0])
            {
                if (int.Parse(InventoryScript.Inv[Chsdcell[U], 1]) >= int.Parse(Res[U, 1]))
                    Chk[U] = 1;
            }
        }
        U = 0;
        if (Chk[0] == 1 && Chk[1] == 1 && Chk[2] == 1)
        {
            for (; U < AmOfINgr; U++)
            {
                SearchRes(Res, U);
                if (InventoryScript.Inv[Chsdcell[U], 0] != null && InventoryScript.Inv[Chsdcell[U], 0] == Res[U, 0])
                {
                    if (int.Parse(InventoryScript.Inv[Chsdcell[U], 1]) >= int.Parse(Res[U, 1]))
                        InventoryScript.Inv[Chsdcell[U], 1] = "" + (float.Parse(InventoryScript.Inv[Chsdcell[U], 1]) -
                            float.Parse(Res[U, 1]));
                }
                InventoryScript.NwItem = NwItem;
            }
        }
        else
            p = 1;
        if (p == 1)
        {
            Information.GetComponent<Text>().text = "Not enough resources.";
            p = 0;
        }
    }

    void Rop()
    {
        Rp = 1;
        Information.GetComponent<Text>().text = "Required Items: \nGrass - X5";
    }
    void CraftingTabl()
    {
        CrftTbl = 1;
        Information.GetComponent<Text>().text = "Required Items: \nLog - X2 \nRope - X4 \nStick - X6";
    }
    void Fireplac()
    {
        FireP = 1;
        Information.GetComponent<Text>().text = "Required Items: \nLog - X1 \nStone - X4 \nStick - X4";
    }
    void StoneAx()
    {
        Hatchet = 1;
        Information.GetComponent<Text>().text = "Required Items: \nStone - X1 \nRope - X1 \nStick - X1";
    }


    void Crft()
    {
        int p = 0;
        //Крафт веревки
        if (Rp == 1)
        {
            Chsdcell = new int[1];
            string[ , ] Res = new string[1, 1];
            int U = 0;
            Res[0, 0] = "Cut Grass";            
            SearchRes(Res, U);            
            if (InventoryScript.Inv[Chsdcell[U], 0] != null && InventoryScript.Inv[Chsdcell[0], 0] == Res[U, 0])
            {
                if (int.Parse(InventoryScript.Inv[Chsdcell[U], 1]) >= 5)
                {
                    InventoryScript.NwItem = RopeI.GetComponent<ItemScript>().Item;
                    InventoryScript.Inv[Chsdcell[0], 1] = "" + (int.Parse(InventoryScript.Inv[Chsdcell[0], 1]) - 5);
                }
                else
                    p = 1;               
            }
            else
                p = 1;           
            Rp = 0;
            if (p == 1)
            {
                Information.GetComponent<Text>().text = "Not enough resources.";
                p = 0;
            }
        }
        //Крафт верстака
        if (CrftTbl == 1)
        {
            /* 2 бревна, 4 веревки, 6 палок*/
            int AmOfINgr = 3;
            Chsdcell = new int[AmOfINgr];
            int[] Chk = new int[AmOfINgr];
            string[ , ] Res = new string[AmOfINgr, 2];
            string[,] NwItem = CraftingTableI.GetComponent<ItemScript>().Item;
            int U = 0;
            Res[0, 0] = "Log"; Res[0, 1] = ""+ 2;
            Res[1, 0] = "Rope"; Res[1, 1] = "" + 4;
            Res[2, 0] = "Stick"; Res[2, 1] = "" + 6;
            CraftPart(AmOfINgr, Chk, Res, U, p, NwItem);
            CrftTbl = 0;
        }

        //Крафт каменного топора
        if (Hatchet == 1)
        {
            /* 1 палка, 1 камень, 1 веревка*/
            int AmOfINgr = 3;
            Chsdcell = new int[AmOfINgr];
            int[] Chk = new int[AmOfINgr];
            string[,] Res = new string[AmOfINgr, 2];
            string[,] NwItem = StoneAxeI.GetComponent<ItemScript>().Item;
            int U = 0;
            Res[0, 0] = "Stone"; Res[0, 1] = "" + 1;
            Res[1, 0] = "Rope"; Res[1, 1] = "" + 1;
            Res[2, 0] = "Stick"; Res[2, 1] = "" + 1;
            CraftPart(AmOfINgr, Chk, Res, U, p, NwItem);
            Hatchet = 0;
        }
        //Крафт костра
        if (FireP == 1)
        {
            /* 1 бревно, 4 камень, 4 палки*/
            int AmOfINgr = 3;
            Chsdcell = new int[AmOfINgr];
            int[] Chk = new int[AmOfINgr];
            string[,] Res = new string[AmOfINgr, 2];
            string[,] NwItem = FirePlaceI.GetComponent<ItemScript>().Item;
            int U = 0;
            Res[0, 0] = "Log"; Res[0, 1] = "" + 1;
            Res[1, 0] = "Stone"; Res[1, 1] = "" + 4;
            Res[2, 0] = "Stick"; Res[2, 1] = "" + 4;
            CraftPart(AmOfINgr, Chk, Res, U, p, NwItem);
            FireP = 0;
        }
    }
}
