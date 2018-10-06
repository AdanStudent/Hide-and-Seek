using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will be used to determine the different buttons that might need to be pressed for the 
//Simon Says part of the game
public enum Colors { RED, GREEN, BLUE, YELLOW }


public class SimonSaysRandomizer : MonoBehaviour
{

    //holding all the Color States as they are generated
    [SerializeField]
    private Stack<Colors> playBackColors;

    //check if playBackColors has been filled
    [SerializeField]
    private bool isFilled;

    //how large of a stack should the Randomizer should make
    [SerializeField]
    private int colorsLimit = 10;

    // Use this for initialization
    void Start ()
    {
        playBackColors = new Stack<Colors>();
	}

    //Ranges min and max for use with the Random function call
    private float maxRange = 1000000;
    private float minRange = 0;

    //used to section off Range by 1/4's
    private float quarterRange;

    private float randOutput;

    // Update is called once per frame
    void Update ()
    {
        FillStack();

    }

    /// <summary>
    /// Checks if playBackColors isFilled, and stores random float in randOutput
    /// </summary>
    private void FillStack()
    {
        if (!isFilled)
        {
            //getting 1/4 of the maxRange
            quarterRange = maxRange / 4;

            //storing a Random number between minRange and maxRange
            randOutput = Random.Range(minRange, maxRange);

            CheckRandomOutput();
        }
        else
        {
            ClearStack();

        }
    }

    private void CheckRandomOutput()
    {
        Debug.Log(randOutput);

        if (randOutput < quarterRange)
        {
            AddToStack(Colors.RED);
        }
        else if (randOutput < (quarterRange * 2))
        {
            AddToStack(Colors.GREEN);
        }
        else if (randOutput < (quarterRange * 3))
        {
            AddToStack(Colors.BLUE);
        }
        else if (randOutput < maxRange)
        {
            AddToStack(Colors.YELLOW);
        }
    }

    private void AddToStack(Colors current)
    {
        if (playBackColors.Count < colorsLimit)
        {
            playBackColors.Push(current);
        }
        else
        {
            isFilled = true;
        }

    }

    private void ClearStack()
    {
        foreach (var color in playBackColors)
        {
            Debug.Log(color);
        }
        playBackColors.Clear();
        isFilled = false;
        Debug.Log("Done");
    }

    private void DebugCall(Colors current)
    {
        Debug.Log(current);
    }
}
