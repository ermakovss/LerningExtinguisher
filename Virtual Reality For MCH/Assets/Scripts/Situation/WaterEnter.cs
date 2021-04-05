using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnter : MonoBehaviour
{
    public static bool isWaterEnter;

    private void Start()
    {
        isWaterEnter = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire") isWaterEnter = true;
        else isWaterEnter = false; 

    }
}
