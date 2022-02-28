using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Controls : MonoBehaviour
{
    public GameObject target;


    void Start()
    {
        
    }

    void Update()
    {
        //If using keyboard, use Button functions
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) { Button1(); }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) { Button2(); }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) { Button3(); }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) { Button4(); }
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)) { Button5(); }
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6)) { Button6(); }
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7)) { Button7(); }
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8)) { Button8(); }
        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9)) { Button9(); }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                gameObject.SendMessage("UpdateSelectedBox", hit.transform.gameObject);
            }
        }
    }


    void Button1() { gameObject.SendMessage("PutNumber", 1); }
    void Button2() { gameObject.SendMessage("PutNumber", 2); }
    void Button3() { gameObject.SendMessage("PutNumber", 3); }
    void Button4() { gameObject.SendMessage("PutNumber", 4); }
    void Button5() { gameObject.SendMessage("PutNumber", 5); }
    void Button6() { gameObject.SendMessage("PutNumber", 6); }
    void Button7() { gameObject.SendMessage("PutNumber", 7); } 
    void Button8() { gameObject.SendMessage("PutNumber", 8); }
    void Button9() { gameObject.SendMessage("PutNumber", 9); }


}