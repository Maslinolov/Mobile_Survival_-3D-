using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRemoveScript : MonoBehaviour {
    public Camera Cam;
    Vector2 Center;
    public Button Use;
    public Button Drop;
    public GameObject[] Items;
    public GameObject Player;

    // Use this for initialization
    void Start ()
    {
        Drop.onClick.AddListener(Drp);
        Use.onClick.AddListener(Us);
        Center.x = Screen.width / 2;
        Center.y = Screen.height / 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
    }
    void Us()
    {        
        RaycastHit Hit;
        Ray ray = Cam.ScreenPointToRay(Center);        
        if (Physics.Raycast(ray, out Hit, 3F) && Hit.collider.tag == "Item" && InventoryScript.Mass < 50)
        {
            float m = float.Parse(Hit.collider.gameObject.GetComponent<ItemScript>().Item[0, 2]);            
            if (InventoryScript.Mass + m < 50)
            {
                InventoryScript.NwItem = Hit.collider.gameObject.GetComponent<ItemScript>().Item;
                Destroy(Hit.collider.gameObject);
            }
        }
    }
    void Drp()
    {
        int i = InventoryScript.ChsdCell;        
        Vector3 pos = Player.transform.position;           
        if (InventoryScript.Inv[i, 0] != null)
        {
            int r = int.Parse(InventoryScript.Inv[i, 3]);
            if (int.Parse(InventoryScript.Inv[i, 1]) >= 0)
            {
                InventoryScript.Inv[i, 1] = "" + (int.Parse(InventoryScript.Inv[i, 1]) - 1);
                Instantiate(Items[r], pos, Quaternion.identity);
            }
        }
    } 
}
