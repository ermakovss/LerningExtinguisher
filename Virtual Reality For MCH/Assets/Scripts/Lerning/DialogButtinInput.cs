using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogButtinInput : MonoBehaviour
{
    [SerializeField] private GameObject ExecuterInfo;
    [SerializeField] private GameObject InfoButtonPanel;
    [SerializeField] private GameObject KonstrucrorsInfo;

    private Graphic buttonGR = null;
    private Button button = null;

    private void Start()
    {
        ExecuterInfo.SetActive(false);
        InfoButtonPanel.SetActive(false);
        KonstrucrorsInfo.SetActive(false);
    }

    private void Update()
    {
        InfoButtonPanel.SetActive(false);

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.gameObject.name == "DialogButton")
            {
                DialogButtonInputPanel();

                buttonGR = hit.collider.gameObject.GetComponent<Graphic>();
                button = hit.collider.gameObject.GetComponent<Button>();

                buttonGR.color = Color.yellow;
                button.transform.localScale = new Vector3(26f, 26f, button.transform.localScale.z);

            }
            else if (hit.collider.gameObject.name != "DialogButton" && buttonGR && button)
            {
                button.transform.localScale = new Vector3(25, 25f, button.transform.localScale.z);
                buttonGR.color = Color.white;

                buttonGR = null;
                button = null;
            }

            if (hit.collider.gameObject.tag == "extinguisher" && hit.distance > 0.4f)
            {
                if (!ExecuterInfo.activeSelf) InfoButtonPanel.SetActive(true);

                if (OVRInput.GetDown(OVRInput.Button.Two))
                {
                    ExecuterInfo.SetActive(true);
                    InfoButtonPanel.SetActive(false);
                    KonstrucrorsInfo.SetActive(false);
                }
                else if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    InfoButtonPanel.SetActive(false);
                    KonstrucrorsInfo.SetActive(true);
                    ExecuterInfo.SetActive(false);
                }
            }


        }
    }


    private void DialogButtonInputPanel()
    {
        if (OVRInput.GetDown(OVRInput.Button.Any))
        {
            ExecuterInfo.SetActive(false);
            InfoButtonPanel.SetActive(true);
        }
    }


}
