using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FatigueScript : MonoBehaviour {

    RaycastHit Hit;
    Vector2 Center;
    public Camera Cam;
    public GameObject Fogging;
    public AudioClip SleepingSound;
    public Button Use;
    AudioSource Audio;
    public int SleepingValue = 60, SleepingTime = 10, WaterCnsmptn = 40, FoodCnsmptn = 30;
    public static bool Sleep = false;
    float i = 0;

	void Start ()
    {
        Use.onClick.AddListener(Us);
        Center.x = Screen.width / 2;
        Center.y = Screen.height / 2;
        Audio = Cam.GetComponent<AudioSource>();
    }
	
	void Us()
    {
        Ray ray = Cam.ScreenPointToRay(Center);
        if (Physics.Raycast(ray, out Hit, 3F) && Hit.collider.tag == "Bed" && BarsScript.Ftg < 100)
        {
            Sleep = true;
            Fogging.SetActive(true);            
        }
    }

    void Update()
    {
        if (Sleep == true)
        {            
            Audio.clip = SleepingSound;
            i += Time.timeScale / 60;           
            if (Audio.isPlaying == false)
            {                
                Audio.Play();
            }            
            if (i >= SleepingTime)
            {
                if (BarsScript.Ftg + SleepingTime < 100)
                    BarsScript.Ftg += SleepingValue;
                else
                    BarsScript.Ftg = 100;
                BarsScript.Thrst -= WaterCnsmptn;
                BarsScript.Hngr -= FoodCnsmptn;
                Audio.Stop();
                Fogging.SetActive(false);
                Sleep = false;
                i = 0;
            }
        }
    }    
}
