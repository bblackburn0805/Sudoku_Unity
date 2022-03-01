using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuBehaviour : MonoBehaviour
{

    public GameObject Selection;
    public GameObject RegularText;
    List<GameObject> Options;

    // Start is called before the first frame update
    void Start()
    {
        Options = new List<GameObject>();
        Options.Add(Instantiate(RegularText,
                    new Vector2(0, 15),
                    Quaternion.identity));
        Options.Add(Instantiate(Selection,
                    new Vector2(0, 7),
                    Quaternion.identity));
        Options.Add(Instantiate(Selection,
                    new Vector2(0, 0),
                    Quaternion.identity));

        Options[1].GetComponent<TextMesh>().text = "Play Again";
        Options[2].GetComponent<TextMesh>().text = "Quit";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Click(hit.transform.gameObject);
            }
        }
    }

    void Click(GameObject go) {
        if (go == Options[1])
            Application.LoadLevel("MainMenu");
        if (go == Options[2])
                Application.Quit();
    }
}
