using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    public GameObject [] Cell;
    public GameObject Inventory, Drop, Close,InventoryPart, Information, Weight, RightFinger;
    public Button Craft, Use;
    public Texture2D[] Icons;
    public static Texture2D[] ICONS;
    public static bool InvOpn = false;
    public static int MaxMass = 50, ChsdCell = 0;
    public static float Mass = 0;
    public static string[,] Inv = new string[12, 7]; 
    //0 - Name
    //1 - Amount
    //2 - Weight
    public static string[,] NwItem = new string[1, 7];
    int i = 0, I = 0, P = 0, u = 0;

    // Use this for initialization
    void Start () {
        ICONS = Icons;
        Use.onClick.AddListener(Us);
        Button Inventor = Inventory.GetComponent<Button>();
        Inventor.onClick.AddListener(Invento);
        Button Drp = Drop.GetComponent<Button>();
        Drp.onClick.AddListener(Dro);
        Button Clos = Close.GetComponent<Button>();
        Clos.onClick.AddListener(Clo);
        Button Cel1 = Cell[0].GetComponent<Button>();

        Cel1.onClick.AddListener(C1);
        Button Cel2 = Cell[1].GetComponent<Button>();
        Cel2.onClick.AddListener(C2);
        Button Cel3 = Cell[2].GetComponent<Button>();
        Cel3.onClick.AddListener(C3);
        Button Cel4 = Cell[3].GetComponent<Button>();
        Cel4.onClick.AddListener(C4);
        Button Cel5 = Cell[4].GetComponent<Button>();
        Cel5.onClick.AddListener(C5);
        Button Cel6 = Cell[5].GetComponent<Button>();
        Cel6.onClick.AddListener(C6);
        Button Cel7 = Cell[6].GetComponent<Button>();
        Cel7.onClick.AddListener(C7);
        Button Cel8 = Cell[7].GetComponent<Button>();
        Cel8.onClick.AddListener(C8);
        Button Cel9 = Cell[8].GetComponent<Button>();
        Cel9.onClick.AddListener(C9);
        Button Cel10 = Cell[9].GetComponent<Button>();
        Cel10.onClick.AddListener(C10);
        Button Cel11 = Cell[10].GetComponent<Button>();
        Cel11.onClick.AddListener(C11);
        Button Cel12 = Cell[11].GetComponent<Button>();
        Cel12.onClick.AddListener(C12);
    }
	
	// Update is called once per frame
	void Update ()
    {        
        if (Inv[P, 1] != null)
        {
            if (int.Parse(Inv[P, 1]) == 0)
            {
                Inv[P, 0] = null;
                Inv[P, 1] = null;
                Inv[P, 2] = null;
                Inv[P, 3] = null;
                Inv[P, 4] = null;
                Inv[P, 5] = null;
                Inv[P, 6] = null;
                Cell[P].GetComponentInChildren<RawImage>().texture = null;
                P = -1;
                i = 0;
                I = 12;
            }
        }
        P++;
        if (P == 12)
            P = 0;

        if (NwItem[0, 0] != null)
        {                        
            if (NwItem[0, 0] == Inv[i, 0])
            {
                AddingItem();
            }            
            if (Inv[i, 0] == null && u == 1)
            {                
                AddingItem();
                u = 0;
                i -= 1;
            }                
            if (i == 11)
            {
                i = -1;
                u = 1;
            }
            i++;           
        }

        if (I < 12 && Inv[I, 2] != null && int.Parse(Inv[I, 1]) != 0)
        { 
            Mass += float.Parse(Inv[I, 2]) * float.Parse(Inv[I, 1]);            
        }         
        if (I == 12)
        {
            Weight.GetComponent<Text>().text = "Mass: " + Mass + " / 50";
            I = -1;
            Mass = 0;
        }
        I++;
        if (NwItem[0, 0] == null)
            i = 0;
	}

    void AddingItem()
    {
        Inv[i, 0] = NwItem[0, 0];
        if (Inv[i, 1] != null)
            Inv[i, 1] = "" + (int.Parse(Inv[i, 1]) + int.Parse(NwItem[0, 1]));
        else
            Inv[i, 1] = NwItem[0, 1];
        Inv[i, 2] = NwItem[0, 2];
        Inv[i, 3] = NwItem[0, 3];
        Inv[i, 4] = NwItem[0, 4];
        Inv[i, 5] = NwItem[0, 5];
        Inv[i, 6] = NwItem[0, 6];
        NwItem[0, 0] = null;
        Cell[i].GetComponentInChildren<RawImage>().texture = Icons[int.Parse(Inv[i, 3])];
        i = 0;
    }

    void Invento()
    {
        InventoryPart.SetActive(true);
        InvOpn = true;
        RightFinger.SetActive(false);
    }
    void Dro()
    {

    }
    void Clo()
    {
        InventoryPart.SetActive(false);
        InvOpn = false;
        Information.GetComponent<Text>().text = "Name: \nAmount: \nMass: ";
        RightFinger.SetActive(true);
    }

    void Us()
    {

    }

    void C1()
    {
        i = 0;
        Info(i);
    }
    void C2()
    {
        i = 1;
        Info(i);
    }
    void C3()
    {
        i = 2;
        Info(i);
    }
    void C4()
    {
        i = 3;
        Info(i);
    }
    void C5()
    {
        i = 4;
        Info(i);
    }
    void C6()
    {
        i = 5;
        Info(i);
    }
    void C7()
    {
        i = 6;
        Info(i);
    }
    void C8()
    {
        i = 7;
        Info(i);
    }
    void C9()
    {
        i = 8;
        Info(i);
    }
    void C10()
    {
        i = 9;
        Info(i);
    }
    void C11()
    {
        i = 10;
        Info(i);
    }
    void C12()
    {
        i = 11;
        Info(i);
    }

    void Info(int i)
    {
        ChsdCell = i;        
        if(Inv[i, 0] != null && (Inv[i, 5] != "E" || Inv[i, 5] == "W" || Inv[i, 5] == "H"))
            Information.GetComponent<Text>().text = "Name: " + Inv[i, 0]+ "\nAmount: " + Inv[i, 1] + "\nMass: " + 
                Inv[i, 2];
        if (Inv[i, 0] != null && (Inv[i, 5] == "E" || Inv[i, 5] == "W" || Inv[i, 5] == "H"))
            Information.GetComponent<Text>().text = "Name: " + Inv[i, 0] + "\nAmount: " + Inv[i, 1] + "\nMass: " +
                Inv[i, 2] + "\nAdds: " + Inv[i, 4];
    }
}
