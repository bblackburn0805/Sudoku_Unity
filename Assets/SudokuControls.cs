using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuControls : MonoBehaviour
{
    public GameObject Box;
    public GameObject horizontalLine;
    public GameObject verticalLine;
    public GameObject checkMark;
    public TextMesh Number;


    List<GameObject> boxList;
    List<int> numberList;
    List<int> errorList;
    List<int> puzzle;
    List<int> digitUsed;
    List<GameObject> checkMarkList;
    int selectedBox;
    int boxNumber;
    int difficulty;


    //TODO: Fix bug where errors dont go away after entering value twice. 

    //TODO: Fix bug where last row never removes any numbers.

    // Start is called before the first frame update
    void Start()
    {
        difficulty = ChangeScene.Difficulty;
        MakeCheckMarkList();
        // No selected box yet.
        digitUsed = new List<int>();
        for (int i = 0; i < 10; i++)
            digitUsed.Add(0);
        selectedBox = -1;
        boxList = new List<GameObject>();
        numberList = new List<int>();
        errorList = new List<int>();
        int boxNum = 0;
        puzzle = new List<int>();
        getSudoku();
        numberList = puzzle;

        for (int i = 0; i < 9; i++)
        {

            for (int j = 0; j < 9; j++)
            {

                // Make boxes. Box number increases as column goes down,
                // then starts the next column. 
                boxList.Add((GameObject)Instantiate(Box,
                new Vector2(-9 + i, 5 - j),
                Quaternion.identity));



                // Name the boxes after their box number.
                boxList[boxNum].name = (i * 9 + j).ToString();

                int value = numberList[i * 9 + j];
                if (value != 0)
                {
                    TextMesh text = boxList[boxNum].GetComponentInChildren<TextMesh>();
                    text.GetComponent<TextMesh>().text = numberList[i * 9 + j].ToString();
                }


                // Box increment
                boxNum++;

                

            }
        }

        // Make the fancy lines to seperate sections of 9.
        Instantiate(horizontalLine, new Vector2(-5, -.48f), Quaternion.identity);
        Instantiate(horizontalLine, new Vector2(-5, 2.5f), Quaternion.identity);
        Instantiate(verticalLine, new Vector2(-6.53f, 1), Quaternion.identity);
        Instantiate(verticalLine, new Vector2(-3.5f, 1), Quaternion.identity);

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void UpdateSelectedBox(GameObject go) {

        // This method called by SendMessage. Recieve the box object,
        // convert name to int.
        int boxNum = int.Parse(go.name);


        // If selected box is clicked again, unselect it.
        if (selectedBox == boxNum)
        {
            selectedBox = -1;
            go.GetComponent<Box>().Unselect();
        }
        
        // Select new box, unselect old box. 
        else
        {
            go.GetComponent<Box>().Select();
            if(selectedBox != -1)
                boxList[selectedBox].GetComponent<Box>().Unselect();
            selectedBox = boxNum;
        }

        if(errorList.Count != 0)
        {
            ClearErrors();
        }
    }





    // Attempts to put number into box.
    void PutNumber(int input) {
        int temp;
        if (selectedBox != -1)
            {
            // TextMesh is the child of the box, which displays the number
            temp = numberList[selectedBox];
            numberList[selectedBox] = input;
            if (CheckLists(selectedBox))
            {
                TextMesh text = boxList[selectedBox].GetComponentInChildren<TextMesh>();
                text.GetComponent<TextMesh>().text = input.ToString();
            }
            else
            {
                numberList[selectedBox] = temp;
            }
            }
        CheckFinished();
        }




    void CheckFinished() {
        bool winner = true;
        for (int i = 1; i < 10; i++)
            digitUsed[i] = 0;
        foreach (int digit in numberList)
        {
            if (digit > 0) 
                digitUsed[digit] += 1;
        }

        for(int i = 1; i < 10; i++) {
            int digit = digitUsed[i];
            if (digit == 9)
                checkMarkList[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            else
            {
                checkMarkList[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                winner = false;
            }
        }

        if (winner)
        {
            print("Chicken Dinner");
        }
        
    }


    void MakeCheckMarkList() {
        checkMarkList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
            checkMarkList.Add((GameObject)Instantiate(checkMark, new Vector2(1.87f, 5.85f - (i * .835f)), Quaternion.identity));
    }




    public void HighlightErrors() {
        foreach (int e in errorList) {
            boxList[e].GetComponent<Box>().Incorrect();
        }
    }


    void ClearErrors()
    {
        foreach (int e in errorList)
        {
            boxList[e].GetComponent<Box>().Unselect();
        }
        errorList.Clear();
    }



    void getSudoku() {
        int amountRemoved = difficulty;
        
        int[,] puzzleArray = this.GetComponent<PuzzleGenerator>().MakePuzzle(9, amountRemoved);
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
                puzzle.Add(puzzleArray[i, j]);
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////
    // Algorithms placed here.





    bool CheckLists(int boxNum) {
        ClearErrors();
        bool rows = CheckRows(boxNum);
        bool columns = CheckColumns(boxNum);
        bool section = CheckSection(boxNum);
        if (rows && columns && section)
            return true;
        return false;
    }







    bool CheckRows(int boxNum) {
        int rowNumber = boxNum % 9;
        List<int> checkRow = new List<int>();
        for (int i = rowNumber; i < 81; i = i + 9)
        {
            if(boxNum != i)
                if (numberList[i] == numberList[boxNum])
                    errorList.Add(i);
        }


        if (errorList.Count != 0)
        {
            HighlightErrors();
            return false;
        }        
        return true;
    }







    bool CheckColumns(int boxNum)
    {
        int columnNumber = boxNum / 9;
        List<int> checkColumn = new List<int>();
        for (int i = columnNumber * 9; i < (columnNumber * 9) + 9; i++)
        {
            if (boxNum != i)
                if (numberList[i] == numberList[boxNum])
                    errorList.Add(i);
        }


        if (errorList.Count != 0)
        {
            HighlightErrors();
            return false;
        }
    

        return true;
    }







    bool CheckSection(int boxNum) {
        int row = boxNum % 9;
        int column = boxNum / 9;

        // Box sections are numbered the same way box numbers are numbered.
        // 1 4 7
        // 2 5 8
        // 3 6 9

        int[] section1 = { 0, 1, 2, 9, 10, 11, 18, 19, 20 };
        int[] section2 = { 3, 4, 5, 12, 13, 14, 21, 22, 23 };
        int[] section3 = { 6, 7, 8, 15, 16, 17, 24, 25, 26 };
        int[] section4 = { 27, 28, 29, 36, 37, 38, 45, 46, 47 };
        int[] section5 = { 30, 31, 32, 39, 40, 41, 48, 49, 50 };
        int[] section6 = { 33, 34, 35, 42, 43, 44, 51, 52, 53 };
        int[] section7 = { 54, 55, 56, 63, 64, 65, 72, 73, 74 };
        int[] section8 = { 57, 58, 59, 66, 67, 68, 75, 76, 77 };
        int[] section9 = { 60, 61, 62, 69, 70, 71, 78, 79, 80 };

        int[] boxSection;



        // Assigin the box to the appropriate section.
        if (row < 3)
        {

            if (column < 3)
                boxSection = section1;
            else if (column < 6)
                boxSection = section4;
            else
                boxSection = section7;
        }


        else if (row < 6)
        {
            if (column < 3)
                boxSection = section2;

            else if (column < 6)
                boxSection = section5;

            else
                boxSection = section8;
        }


        else
        {
            if (column < 3)
                boxSection = section3;

            else if (column < 6)
                boxSection = section6;

            else
                boxSection = section9;
        }

        // Values of all the boxes in the section added to a list
        List<int> sectionBoxValues= new List<int>();
        foreach (int i in boxSection)
        {
            if (boxNum != i)
                if (numberList[i] == numberList[boxNum])
                    errorList.Add(i);
        }


        if (errorList.Count != 0)
        {
            HighlightErrors();
            return false;
        }


        return true;


    }//end CheckSection






}

