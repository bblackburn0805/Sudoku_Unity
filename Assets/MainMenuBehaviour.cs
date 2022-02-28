using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour

{

    public GameObject Text;
    List<GameObject> Options;
    // Start is called before the first frame update

    void Start()
    {
        Options = new List<GameObject>();
        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, 15),
                    Quaternion.identity));
        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, 8),
                    Quaternion.identity));
        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, 1),
                    Quaternion.identity));
        Options[0].GetComponent<TextMesh>().text = "New Game";
        Options[0].name = "NewGame";
        Options[1].GetComponent<TextMesh>().text = "Resume";
        Options[1].name = "Resume";
        Options[2].GetComponent<TextMesh>().text = "Quit";
        Options[2].name = "Quit";
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
                Click(hit.transform.gameObject.name);
            }
        }
    }

    void Click(string input) {
        if (input.Equals("NewGame"))
            NewGame();
        if (input.Equals("Resume"))
            Resume();
        if (input.Equals("Quit"))
            Application.Quit();


        if (input.Equals("Easy"))
            CreateGame(20);
        if (input.Equals("Medium"))
            CreateGame(30);
        if (input.Equals("Hard"))
            CreateGame(45);
        if (input.Equals("Expert"))
            CreateGame(60);
        if (input.Equals(""))
        {
            foreach (GameObject go in Options)
                Destroy(go);
            Start();
        }
    }

    void NewGame() {
        foreach (GameObject go in Options)
            Destroy(go);
        Options.Clear();


        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, 17),
                    Quaternion.identity));
        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, 10),
                    Quaternion.identity));
        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, 3),
                    Quaternion.identity));
        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, -4),
                    Quaternion.identity));
        Options.Add(Instantiate(Text,
                    new Vector2(4.4f, -13),
                    Quaternion.identity));


        Options[0].GetComponent<TextMesh>().text = "Easy";
        Options[0].name = "Easy";
        Options[1].GetComponent<TextMesh>().text = "Medium";
        Options[1].name = "Medium";
        Options[2].GetComponent<TextMesh>().text = "Hard";
        Options[2].name = "Hard";
        Options[3].GetComponent<TextMesh>().text = "Expert";
        Options[3].name = "Expert";
        Options[4].GetComponent<TextMesh>().text = "Back";
        Options[4].name = "Back";


    }

    void Resume() {
        print("resume");
    }




    void CreateGame(int difficutly) {
        ChangeScene.Difficulty = difficutly;
        Application.LoadLevel("SampleScene");

        //SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        foreach (GameObject go in Options)
            Destroy(go);

    }
}
