using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayLevelCituation : MonoBehaviour
{
    [SerializeField] private GameObject ReplayCanvas;
    [SerializeField] private GameObject CongratilutionCanvas;
    [SerializeField] private ParticleSystem[] FireSystem;

    private void Awake()
    {
        ReplayCanvas.SetActive(false);
        CongratilutionCanvas.SetActive(false);
    }

    private void Start()
    {
        for (int i = 0; i < FireSystem.Length; i++) FireSystem[i] = GetComponent<ParticleSystem>();
    }

    private void Update()
    {

        if (TimerCituation.FalseLevel && ChethicFireSize.checthic != 5)
        {
            StartCoroutine(ReturnLevel());
            if (OVRInput.Get(OVRInput.Button.One))
            {
                SceneManager.LoadScene("StartInfo");
            }
        }else if(!TimerCituation.FalseLevel && ChethicFireSize.checthic == 5)
        {
            StartCoroutine(CongratilutionLevel());
            if (OVRInput.Get(OVRInput.Button.One))
            {
                SceneManager.LoadScene("SampleScene");
            }       

        }

    }

    private IEnumerator ReturnLevel()
    {
        yield return new WaitForSeconds(5f);

        ReplayCanvas.SetActive(true);
    }

    private IEnumerator CongratilutionLevel()
    {
        yield return new WaitForSeconds(5f);

        CongratilutionCanvas.SetActive(true);
    }

}
