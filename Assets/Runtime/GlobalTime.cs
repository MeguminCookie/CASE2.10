using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTime : MonoBehaviour
{
    private static float elapsedTime = 0f;

    public static float ElapsedTime
    {
        get { return elapsedTime; }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime);
    }
}