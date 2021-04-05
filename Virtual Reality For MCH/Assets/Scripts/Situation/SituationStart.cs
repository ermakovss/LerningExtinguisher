using UnityEngine;
using UnityEngine.SceneManagement;

public class SituationStart : MonoBehaviour
{
    [SerializeField] private GameObject InfoStartText;

    private void Start()
    {
        InfoStartText.SetActive(true);
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("Cituation");
        }
    }

}
