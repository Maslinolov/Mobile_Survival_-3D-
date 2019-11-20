using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchetScript : MonoBehaviour {
    public GameObject Hatchet, Inventory, RFinger;
    public Camera Cam;
    public Button UseInGame, UseInMenu, InvB;
    public AudioClip[] Sounds;
    AudioSource HatchetAudio;
    Vector2 Center;
    RaycastHit Hit;
    Ray ray;


    void Start () {
        UseInGame.onClick.AddListener(UseInGam);
        UseInMenu.onClick.AddListener(UseInMen);
        InvB.onClick.AddListener(Inv);
        HatchetAudio = Cam.GetComponent<AudioSource>();
        Center.x = Screen.width / 2;
        Center.y = Screen.height / 2;
    }

    void UseInMen()
    {
        if(InventoryScript.Inv[InventoryScript.ChsdCell, 6] == "StoneHatchet")
        {
            InventoryScript.InvOpn = false;
            Inventory.SetActive(false);
            Hatchet.SetActive(true);
            RFinger.SetActive(true);
        }
    }

    void Inv()
    {
        if(Hatchet.activeInHierarchy == true)
        {
            Hatchet.SetActive(false);
        }
    }

    void UseInGam()
    {        
        if (Hatchet.activeInHierarchy == true && HatchetAudio.isPlaying == false)
        {
            HatchetAudio.clip = Sounds[0];
            ray = Cam.ScreenPointToRay(Center);
            if (Physics.Raycast(ray, out Hit, 3F) && Hit.collider.tag == "Tree")
            {                
                HatchetAudio.clip = Sounds[1];
                Hit.collider.gameObject.GetComponent<TreeScript>().count++;
            }            
            HatchetAudio.Play();            
        }        
    }
}
