using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekaExitExtinguisher : MonoBehaviour
{
    public static bool isExitCheck;

    private void Start()
    {
        isExitCheck = false;
    }

    void Update()
    {
        if (this.gameObject.GetComponent<Rigidbody>().useGravity) isExitCheck = true;
    }
}
