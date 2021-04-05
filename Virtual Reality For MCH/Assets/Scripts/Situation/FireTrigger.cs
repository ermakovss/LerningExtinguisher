using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    [SerializeField] private float enabledFirenum;
    private ParticleSystem FireObject;

    int Proverka;

    private void Start()
    {
        FireObject = GetComponent<ParticleSystem>();
        Proverka = 0;
    }

    private void Update()
    {
        ParticleSystem.MainModule main = FireObject.main;
        if (WaterEnter.isWaterEnter && main.startSizeMultiplier > 0.00)
        {
            main.startSizeMultiplier -= enabledFirenum;
        }

        if (main.startSizeMultiplier == 0 && Proverka == 0)
        {
            ChethicFireSize.checthic++;
            Proverka++;
        }
    }

}
