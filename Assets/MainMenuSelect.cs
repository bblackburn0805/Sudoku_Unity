using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMesh text = this.GetComponentInChildren<TextMesh>();
        text.GetComponent<TextMesh>().color = Color.black;
    }

    void OnMouseEnter()
    {
        TextMesh text = this.GetComponentInChildren<TextMesh>();
        text.GetComponent<TextMesh>().color = Color.red;
    }

    void OnMouseExit()
    {
        TextMesh text = this.GetComponentInChildren<TextMesh>();
        text.GetComponent<TextMesh>().color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
