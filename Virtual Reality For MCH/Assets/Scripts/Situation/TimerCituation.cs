using UnityEngine;
using UnityEngine.UI;

public class TimerCituation : MonoBehaviour
{
    [SerializeField] private int minets;
    private float seconds = 60f;

    private Text CanvasText;

    public static bool FalseLevel;
    private void Start()
    {
        FalseLevel = false;
        CanvasText = GetComponent<Text>();
    }

    private void Update()
    {
        if (minets >= 0 && seconds != 0)
        {
            CanvasText.text = (seconds >= 10) ? (minets + " : " + (int)seconds) : (minets + " : " + "0" + (int)seconds);

            if (seconds > 0)
            {
                seconds -=Time.deltaTime;
            }
            else
            {
                minets--;
                seconds = 59f;
            }
        }
        else
        {
            FalseLevel = true;
        }

    }

}
