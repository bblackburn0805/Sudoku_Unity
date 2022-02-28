using UnityEngine;
using System.Collections;
using System;

public class Box : MonoBehaviour
{
    bool isSelected;
    private Color startcolor;


    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        startcolor = GetComponent<Renderer>().material.color;

    }

    void Update()
    {
        
    }


    void OnMouseEnter()
    {
        if (!isSelected)
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    void OnMouseExit()
    {
        if (!isSelected)
            GetComponent<Renderer>().material.color = startcolor;
    }
    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        isSelected = true;
    }
    public void Unselect()
    {
        GetComponent<Renderer>().material.color = startcolor;
        this.isSelected = false;
    }

    public void Incorrect()
    {
        GetComponent<Renderer>().material.color = Color.red;

    }
}