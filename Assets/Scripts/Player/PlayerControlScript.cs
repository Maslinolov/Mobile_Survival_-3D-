using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlScript : MonoBehaviour {

    public GameObject Jump, Position, Player, Cam, text;
    public Button Use;
    float Rot = 1.3F;
    public float Cntrl = 0;
    public static int Onclldrntr = 0, Stamina_x = 0, Stamina_y = 0;
    int jump = 0, Crouch = 0, u = 0, U = 0, TchL = 0, TchR = 0, o = 0, O = 0;
    float dl = 0, grvt = 0;
    Vector2 StartPosRight, StartPosLeft, DirectionRight, DirectionLeft;
    public float speed = 6.0F; //Скорость передвижения
    static public float Spd = 60;
    public float jumpSpeed = 6.0F; //Начальная скорость прыжка
    public float gravity = 20.0F; //Сила гравитации
    private Vector3 moveDirection = Vector3.zero; //Направление персонажа


    // Use this for initialization
    void Start ()
    {
        Button Pstn = Position.GetComponent<Button>();
        Button Jmp = Jump.GetComponent<Button>();
        Pstn.onClick.AddListener(Positn);
        Jmp.onClick.AddListener(Jum);
        DirectionLeft.x = 0;
        DirectionLeft.y = 0;
        DirectionRight.x = 0;
        DirectionRight.y = 0;
    }
    // Update is called once per frame
    void Update ()
    {
        CharacterController controller = Player.GetComponent<CharacterController>();        
        moveDirection = new Vector3(0, 0, 0);          
        //Управление клавой
        if (Cntrl == 1 && InventoryScript.InvOpn == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection.x = (-0.1F * Spd);
                Stamina_x = 1;
            }
            else
            {
                moveDirection.x = 0;
                Stamina_x = 0;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection.x = (0.1F * Spd);
                Stamina_x = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection.z = (0.1F * Spd);
                Stamina_y = 1;
            }
            else
            {
                moveDirection.z = 0;
                Stamina_y = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection.z = (-0.1F * Spd);
                Stamina_y = 1;
            }
            if (Input.GetKey(KeyCode.RightArrow))                
                Player.transform.Rotate(0, Rot, 0);
            if (Input.GetKey(KeyCode.LeftArrow))
                Player.transform.Rotate(0,-Rot, 0);
            if (Input.GetKey(KeyCode.UpArrow) && Cam.transform.localRotation.x >= -0.34)
                Cam.transform.Rotate(-Rot, 0, 0);
            if (Input.GetKey(KeyCode.DownArrow) && Cam.transform.localRotation.x <= 0.34)
                Cam.transform.Rotate(Rot, 0, 0);            
        }

        //стики
        if (Input.touchCount > 0)
        {            
            if(Input.touchCount == 1)
            {                
                Touch touchZ = Input.GetTouch(0);
                if (touchZ.position.x >= Screen.width / 2 && u == 0)
                {                    
                    o = 1;
                    u = 1;
                    TchR = 0;
                }
                if (touchZ.position.x <= Screen.width / 2 && u == 0)
                {
                    o = 2;
                    u = 1;
                    TchL = 0;
                }
                Touch touchleft = Input.GetTouch(TchL);
                Touch touchright = Input.GetTouch(TchR);
                TouchPart(touchleft, touchright);
            }
            if (Input.touchCount == 2)
            {
                Touch touchZ = Input.GetTouch(0);
                Touch touchO = Input.GetTouch(1);                
                if (touchZ.position.x >= Screen.width / 2 && u == 0)
                {                      
                    u = 1;              
                    TchR = 0;
                    o = 3;
                }
                if (touchZ.position.x <= Screen.width / 2 && u == 0)
                {                    
                    u = 1;                 
                    TchL = 0;
                    O = 4;
                }
                if (touchO.position.x >= Screen.width / 2 && U == 0)
                {                    
                    U = 1;                  
                    TchR = 1;
                    o = 3;
                }
                if (touchO.position.x <= Screen.width / 2 && U == 0)
                {                    
                    U = 1;                   
                    TchL = 1;
                    O = 4;
                }              
                Touch touchleft = Input.GetTouch(TchL);
                Touch touchright = Input.GetTouch(TchR);
                TouchPart(touchleft, touchright);
            }
        }
        if (Input.touchCount == 0)
        {
            DirectionLeft.x = 0;
            DirectionLeft.y = 0;
            DirectionRight.x = 0;
            DirectionRight.y = 0;
            u = 0;
            U = 0;
            o = 0;
            O = 0;
            TchL = 0;
            TchR = 0;
        }     
        
        if (Cntrl == 0 && InventoryScript.InvOpn == false)
        {
            if (DirectionLeft.x >= 40)
            {               
                if (DirectionLeft.x <= 300)
                    moveDirection.x = ((DirectionLeft.x / Screen.width) / 2.5F * Spd);
                else
                    moveDirection.x = (0.1F * Spd);
            }
            if (DirectionLeft.x <= -40)
            {                
                if (DirectionLeft.x >= -300)
                    moveDirection.x = ((DirectionLeft.x / Screen.width) / 2.5F * Spd);
                else
                    moveDirection.x = (-0.1F * Spd);
            }
            if (DirectionLeft.y >= 40)
            {               
                Climbing();
                if (DirectionLeft.y <= 300)
                    moveDirection.z = ((DirectionLeft.y / Screen.height) / 2.5F * Spd);
                else
                    moveDirection.z = (0.1F * Spd);
            }
            if (DirectionLeft.y <= -40)
            {            
                Climbing();
                if (DirectionLeft.y >= -300)
                    moveDirection.z = ((DirectionLeft.y / Screen.height) / 2.5F * Spd);
                else
                    moveDirection.z = (-0.1F * Spd);
            }
            if (DirectionLeft.y < 40 && DirectionLeft.y >= -40)
            {
                ReturnClimbing();
            }
            if (DirectionLeft.x > 200 || DirectionLeft.x < -200)
                Stamina_x = 1;
            else
                Stamina_x = 0;
            if (DirectionLeft.y > 200 || DirectionLeft.y < -200)
                Stamina_y = 1;
            else
                Stamina_y = 0;
        }
        if (InventoryScript.InvOpn == true)
        {
            Stamina_x = 0;
            Stamina_y = 0;
        }      
        
        if (controller.isGrounded)
        {
            grvt = 0;
            if (jump == 1)
            {
                jump = 0;
                grvt = jumpSpeed;
            }            
        }
        grvt -= gravity * Time.deltaTime;
        moveDirection.y = grvt;
        moveDirection = Player.transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);

        if (InventoryScript.InvOpn == false)
        {
            //Кнопки управления справа и стик
            if (DirectionRight.x >= 40)
                Player.transform.Rotate(0, DirectionRight.x / Screen.width * 10, 0);
            if (DirectionRight.x <= -40)
                Player.transform.Rotate(0, DirectionRight.x / Screen.width * 10, 0);
            if (DirectionRight.y >= 40 && Cam.transform.localRotation.x >= -0.34)
                Cam.transform.Rotate(-(DirectionRight.y / Screen.height) * 5, 0, 0);
            if (DirectionRight.y <= -40 && Cam.transform.localRotation.x <= 0.34)
                Cam.transform.Rotate(-(DirectionRight.y / Screen.height) * 5, 0, 0);


            //Приседание       
            if (Crouch == 1 && controller.height > 1F)
            {
                controller.height -= 0.1F;
                Position.GetComponentInChildren<Text>().text = "Stand";
            }
            if (Crouch == 0 && controller.height < 2F)
            {
                controller.height += 0.1F;
                Position.GetComponentInChildren<Text>().text = "Crouch";
            }
        }      
    }

    void TouchPart(Touch touchleft, Touch touchright)
    {
        if(o == 2 || O == 4)
        switch (touchleft.phase)
        {
            case TouchPhase.Began:
                StartPosLeft = touchleft.position;
                break;
            case TouchPhase.Moved:
                DirectionLeft = touchleft.position - StartPosLeft;
                break;
            case TouchPhase.Ended:
                DirectionLeft.x = 0;
                DirectionLeft.y = 0;
                u = 0;
                U = 0;
                o = 0;
                O = 0;
                TchL = 0;                
                break;
        }
        if(o == 1 || o == 3)
        switch (touchright.phase)
        {
            case TouchPhase.Began:
                StartPosRight = touchright.position;
                break;
            case TouchPhase.Moved:
                DirectionRight = touchright.position - StartPosRight;
                break;
            case TouchPhase.Ended:
                DirectionRight.x = 0;
                DirectionRight.y = 0;
                u = 0;
                U = 0;
                o = 0;                
                TchR = 0;
                break;
        }
    }
    //Покачивание камеры
    void Climbing()
    {             
        if (Cam.transform.localRotation.z <= 0.02F && dl <= 3)
        {
            Cam.transform.Rotate(0, 0, 0.03F);            
        }
        if(Cam.transform.localRotation.z >= -0.02F && dl >= 3)
        {
            Cam.transform.Rotate(0, 0, -0.03F);           
        }
        dl += Time.deltaTime * 5;
        if (dl >= 6)
        {
            dl = 0;
        }

    }

    void ReturnClimbing()
    {
        if (Cam.transform.localRotation.z < 0)
        {
            Cam.transform.Rotate(0, 0, 0.03F);
        }
        if (Cam.transform.localRotation.z > 0)
        {
            Cam.transform.Rotate(0, 0, -0.03F);
        }
        dl += Time.deltaTime * 5;
        if (dl >= 4)
        {
            dl = 0;
        }
    }

    void Jum()
    {       
            jump = 1;
    }

    void Positn()
    {
        if (Crouch == 0)        
            Crouch = 1;
        else
            Crouch = 0;        
    }
}
