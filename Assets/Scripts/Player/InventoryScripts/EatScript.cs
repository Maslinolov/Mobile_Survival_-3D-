using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatScript : MonoBehaviour {
    public Button Use;
    public GameObject Cam;
    public AudioClip[] EatSounds;
    int ChCell;
    AudioSource EatSound;

    // Use this for initialization
    void Start ()
    {
        Use.onClick.AddListener(Us);
        EatSound = Cam.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void Us()
    {
        ChCell = InventoryScript.ChsdCell;
        if (InventoryScript.Inv[ChCell, 5] == "E" && BarsScript.Hngr < 100)
        {
            InventoryScript.Inv[ChCell, 1] = "" + (int.Parse(InventoryScript.Inv[ChCell, 1]) - 1);
            EatSound.clip = EatSounds[0];
            EatSound.Play();
            BarsScript.Hngr += int.Parse(InventoryScript.Inv[ChCell, 4]);
        }
        if (InventoryScript.Inv[ChCell, 5] == "W" && BarsScript.Thrst < 100)
        {
            InventoryScript.Inv[ChCell, 1] = "" + (int.Parse(InventoryScript.Inv[ChCell, 1]) - 1);
            EatSound.clip = EatSounds[1];
            EatSound.Play();
            BarsScript.Thrst += int.Parse(InventoryScript.Inv[ChCell, 4]);
        }
    }
}
