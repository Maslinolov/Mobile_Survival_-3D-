using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePlaceScript : MonoBehaviour {
    public Camera Cam;
    Vector2 Center;
    public Text Timeleft;
    public GameObject[] Food;
    bool Fire = false;
    float Timer;
    int ChsdCell;
    public int CookingTime = 30;
    public Button Put, Take, Startfire, Use, Close;
    public string[] Items, Fuel;
    string[,] OvenInv = new string[3, 7];
    public GameObject FireplacePart, Inv, RightFinger, InvPart, InfoPart, CtrlPart, ItemC, FuelC, FoodC, FirePlace;
    RaycastHit Hit;
    public bool Active = false;


    void Start ()
    {
        OvenInv[0, 1] = "" + 0;
        OvenInv[1, 1] = "" + 0;
        OvenInv[2, 1] = "" + 0;
        Center.x = Screen.width / 2;
        Center.y = Screen.height / 2;
        Use.onClick.AddListener(Us);
        Close.onClick.AddListener(Clos);
        Put.onClick.AddListener(Pt);
        Startfire.onClick.AddListener(StrtFire);
        Take.onClick.AddListener(Tak);
        OvenInv[1, 1] = "" + 0;
	}
	
    void Pt()
    {
        if (Active == true)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (InventoryScript.Inv[ChsdCell, 6] == Items[i] && OvenInv[0, 0] == null)
                {
                    InventoryScript.Inv[ChsdCell, 1] = "" + (int.Parse(InventoryScript.Inv[ChsdCell, 1]) - 1);
                    for (int k = 0; k < 7; k++)
                        OvenInv[0, k] = InventoryScript.Inv[ChsdCell, k];
                    OvenInv[0, 1] = "" + 1;
                }
            }
            for (int i = 0; i < Fuel.Length; i++)
            {
                if (InventoryScript.Inv[ChsdCell, 6] == Fuel[i])
                {
                    if (OvenInv[1, 6] == InventoryScript.Inv[ChsdCell, 6] || OvenInv[1, 1] == "" + 0)
                    {
                        InventoryScript.Inv[ChsdCell, 1] = "" + (int.Parse(InventoryScript.Inv[ChsdCell, 1]) - 1);
                        for (int k = 0; k < 7; k++)
                            if (k != 1)
                                OvenInv[1, k] = InventoryScript.Inv[ChsdCell, k];
                        OvenInv[1, 1] = "" + (int.Parse(OvenInv[1, 1]) + 1);
                    }
                }
            }
        }
    }

    void Tak()
    {
        if (Active == true)
        {
            int o = 0;
            if (OvenInv[2, 0] != null && o == 0)
            {
                o = 1;
                if (int.Parse(OvenInv[2, 1]) != 0 && InventoryScript.Mass + float.Parse(OvenInv[2, 2]) <= InventoryScript.MaxMass)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        InventoryScript.NwItem[0, i] = OvenInv[2, i];
                        if (i != 1)
                            OvenInv[2, i] = null;
                        else
                            OvenInv[2, i] = "" + 0;
                    }
                }                
            }
            if (OvenInv[1, 0] != null && o == 0)
            {
                if (int.Parse(OvenInv[1, 1]) != 0)
                {
                    if (int.Parse(OvenInv[2, 1]) == 0 && InventoryScript.Mass +
                        (int.Parse(OvenInv[1, 2]) * int.Parse(OvenInv[1, 1])) <= InventoryScript.MaxMass)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            InventoryScript.NwItem[0, i] = OvenInv[1, i];
                            if (i != 1)
                                OvenInv[1, i] = null;
                            else
                                OvenInv[1, i] = "" + 0;
                        }
                    }
                }
            }            
        }
    }

    void StrtFire()
    {
        if (Active == true)
        {
            if (Fire == false)
                Fire = true;
            else
                Fire = false;
        }
    }
	
	void Update ()
    {
        AudioSource fire = FirePlace.GetComponent<AudioSource>();
        ChsdCell = InventoryScript.ChsdCell;
        if(Fire == true && int.Parse(OvenInv[1, 1]) != 0)
        {
            Timer += Time.timeScale / 10;                       
            if (fire.isPlaying == false)
                fire.Play();            
        }
        else
        {
            fire.Stop();
            Timer = 0;
            Fire = false;
        }
        if(Timer > CookingTime)
        {
            for(int i = 0; i < Items.Length; i++)
            {
                if(OvenInv[0, 6] == Items[i])
                {
                    for(int k = 0; k < 7; k++)
                    {
                        OvenInv[2, k] = Food[i].GetComponent<ItemScript>().Item[0, k];
                        if(k != 1)
                            OvenInv[0, k] = null;
                        else
                            OvenInv[0, k] = "" + 0;
                    }
                }
            }
            Timer = 0;
            Fire = false;
            OvenInv[1, 1] = "" + (int.Parse(OvenInv[1, 1]) - 1); 
        }
        if (Active == true)
        {
            if (OvenInv[0, 3] != null)
            {
                if (int.Parse(OvenInv[0, 1]) != 0)
                    ItemC.GetComponentInChildren<RawImage>().texture = InventoryScript.ICONS[int.Parse(OvenInv[0, 3])];
                else
                    ItemC.GetComponentInChildren<RawImage>().texture = null;
            }
            else
                ItemC.GetComponentInChildren<RawImage>().texture = null;
            if (OvenInv[1, 3] != null)
            {
                if (int.Parse(OvenInv[1, 1]) != 0)
                    FuelC.GetComponentInChildren<RawImage>().texture = InventoryScript.ICONS[int.Parse(OvenInv[1, 3])];
                else
                    FuelC.GetComponentInChildren<RawImage>().texture = null;
            }
            else
                FuelC.GetComponentInChildren<RawImage>().texture = null;
            if (OvenInv[2, 3] != null)
            {
                if (int.Parse(OvenInv[2, 1]) != 0)
                    FoodC.GetComponentInChildren<RawImage>().texture = InventoryScript.ICONS[int.Parse(OvenInv[2, 3])];
                else
                    FoodC.GetComponentInChildren<RawImage>().texture = null;
            }
            else

                FoodC.GetComponentInChildren<RawImage>().texture = null;
            Timeleft.GetComponent<Text>().text = Timer.ToString("f0") + " / 30";
        }
    }

    public void Us()
    {
        Ray ray = Cam.ScreenPointToRay(Center);
        if (Physics.Raycast(ray, out Hit, 3F) && Hit.collider.tag == "Fireplace")
        {
            Hit.collider.gameObject.GetComponent<FirePlaceScript>().Active = true;
            if (Active == true)
            {
                Inv.SetActive(true);
                FireplacePart.SetActive(true);
                InfoPart.SetActive(false);
                CtrlPart.SetActive(false);
                RightFinger.SetActive(false);
                InventoryScript.InvOpn = true;                
            }
        }     
    }

    void Clos()
    {
        if (Active == true)
        {
            Inv.SetActive(false);
            FireplacePart.SetActive(false);
            InfoPart.SetActive(true);
            CtrlPart.SetActive(true);
            RightFinger.SetActive(true);
            InventoryScript.InvOpn = false;
            Hit.collider.gameObject.GetComponent<FirePlaceScript>().Active = false;
        }
    }
}
