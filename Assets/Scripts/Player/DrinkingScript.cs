using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrinkingScript : MonoBehaviour {

    Vector2 Center;
    public Camera Cam;
    public Button Use;    
    RaycastHit Hit;
    AudioSource SourceSound;
    public AudioClip DrinkingSound;
    public int WaterAdd = 10;
    Ray ray;


	// Use this for initialization
	void Start () {
        Center.x = Screen.width / 2;
        Center.y = Screen.height / 2;
        Use.onClick.AddListener(Us);
        ray = Cam.ScreenPointToRay(Center);
    }

    void Us()
    {
        ray = Cam.ScreenPointToRay(Center);
        if (Physics.Raycast(ray, out Hit, 3F) && Hit.collider.tag == "WaterSource" && BarsScript.Thrst < 100)
        {
            SourceSound = Cam.GetComponent<AudioSource>();                    
            SourceSound.clip = DrinkingSound;            
            if (SourceSound.isPlaying == false)
            {
                SourceSound.Play();
                BarsScript.Thrst += WaterAdd;
            }                           
        }        
    }
}
