using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsScript : MonoBehaviour {
    public GameObject Cam;
    public Slider HP, Hunger, Thirst, Stamina, Fatigue;
    public  static float Hlth = 100, Hngr = 100, Thrst = 100, Stmn = 100, Ftg = 100;
    public float Stmn_Mns = 0.2F, Stmn_Pls = 0.1F, Thrst_Cnsmptn_Mns = 0.02F, Thrst_Cnsmptn_Stndrt = 0.005F,
                 Thrst_Cnsmptn = 0.005F, Hngr_Cnsmptn = 0.001F, Hngr_Cnsmptn_Stndrt = 0.001F, Hngr_Cnsmptn_Mns = 0.002F,
                 Ftg_Cnsmptn = 0.0005F, Ftg_Cnsmptn_Stndrt = 0.0005F, Ftg_Cnsmptn_Mns = 0.0015F, HP_Mns = 1,
                 HP_Mns_Stndrt = 1, HP_Dmg = 1;
    bool Stmn_deny = false;
    public static bool Death = false;
    AudioSource HBreath;
    public AudioClip BreathSound;


    // Use this for initialization
    void Start ()
    {
        HBreath = Cam.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        HP.value = Hlth;
        Hunger.value = Hngr;
        Thirst.value = Thrst;
        Stamina.value = Stmn;
        Fatigue.value = Ftg;
        //Stamina
        if (PlayerControlScript.Stamina_x == 1 && Stmn > 0 || PlayerControlScript.Stamina_y == 1 && Stmn > 0)
        {            
            Stmn -= Stmn_Mns;
            Thrst_Cnsmptn = Thrst_Cnsmptn_Mns;
            Hngr_Cnsmptn = Hngr_Cnsmptn_Mns;
            Ftg_Cnsmptn = Ftg_Cnsmptn_Mns;
        }
        else
        {
            Thrst_Cnsmptn = Thrst_Cnsmptn_Stndrt;
            Hngr_Cnsmptn = Hngr_Cnsmptn_Stndrt;
            Ftg_Cnsmptn = Ftg_Cnsmptn_Stndrt;
            if (Stmn < 100)
                Stmn += Stmn_Pls;
        }
        if (Stmn > 0 && Stmn_deny == false)
        {
            PlayerControlScript.Spd = 60;
        }
        if (Stmn < 1)
        {
            PlayerControlScript.Spd = 30;
            Stmn_deny = true;
            HBreath.clip = BreathSound;
            if(HBreath.isPlaying == false)                         
            HBreath.Play();
        }
        if (Stmn > 20)
            Stmn_deny = false;

        //Thirst
        if(Thrst > 0)
            Thrst -= Thrst_Cnsmptn;

        //Hinger
        if(Hngr > 0)
            Hngr -= Hngr_Cnsmptn;

        //Fatigue
        if (Ftg > 0)
            Ftg -= Ftg_Cnsmptn;

        //HP
        if((Thrst < 1 || Hngr < 1 || Ftg < 1) && Hlth > 0.5F)
        {
            Hlth -= HP_Mns;
        }
        if (Hlth < 0.5F)
        {
            Death = true;
        }
            
	}
}
