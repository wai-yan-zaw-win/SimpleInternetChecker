using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HarioGames.SimpleInternetChecker;

public class TestScript : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if(SimpleInternetChecker.Instance != null)
        {
            if(!SimpleInternetChecker.Instance.isInternetOn  && !SimpleInternetChecker.Instance.hasInternetConnection)
            {
                Debug.Log("No Internet");
                //Show no internet pop up or do something
            }
            else
            {
                if(!SimpleInternetChecker.Instance.hasInternetConnection)
                {
                    Debug.Log("Checking internet connection");
                }
            }
        }
    }
}
