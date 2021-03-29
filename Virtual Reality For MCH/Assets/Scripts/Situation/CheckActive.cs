using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    private GameObject water;

    private void Start()
    {
        water = GameObject.Find("Water");
        water.SetActive(false);
    }

    private void Update()
    {
        if(ChekaExitExtinguisher.isExitCheck && TransformHandle.isInputHandle)
        {
            water.SetActive(true);
        }
        else
        {
            water.SetActive(false);
        }
    }
}
