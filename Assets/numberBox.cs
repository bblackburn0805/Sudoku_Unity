using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class numberBox : MonoBehaviour
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

    void OnMouseDown()
    {
        if (!isSelected)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            isSelected = true;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
            isSelected = false;
        }
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
    void Selected()
    {

    }
    void Unselect() {
        GetComponent<Renderer>().material.color = startcolor;
        this.isSelected = false;
    }
}
