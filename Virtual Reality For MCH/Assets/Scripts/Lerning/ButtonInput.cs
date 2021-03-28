using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectIsNotActive;
    [SerializeField] private GameObject[] ExexcuterInfoImageActive;

    private Graphic buttonGR = null;
    private Button button = null;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.gameObject.tag == "Button")
            {
                ButtonInputController(hit);

                buttonGR = hit.collider.gameObject.GetComponent<Graphic>();
                button = hit.collider.gameObject.GetComponent<Button>();


                buttonGR.color = Color.yellow;
                button.transform.localScale = new Vector3(0.7f, 0.7f, button.transform.localScale.z);

            }
            else if (hit.collider.gameObject.tag != "Button" && buttonGR && button)
            {
                button.transform.localScale = new Vector3(0.6f, 0.6f, button.transform.localScale.z);
                buttonGR.color = Color.white;

                buttonGR = null;
                button = null;
            }

        }
    }

    private void ButtonInputController(RaycastHit hit)
    {
        if (OVRInput.GetDown(OVRInput.Button.Any) && hit.collider.gameObject.name != "DialogButton")
        {
            StartCoroutine(OnClickContinue());
            StartCoroutine(ContinueButton());
        }
    }

    private IEnumerator OnClickContinue()
    {
        for(int i = 0; i < ObjectIsNotActive.Length; i++)
        {
            ObjectIsNotActive[i].SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(0.01f);
    }

    private IEnumerator ContinueButton()
    {
        for (int i = 0; i < ExexcuterInfoImageActive.Length; i++)
        {
            ExexcuterInfoImageActive[i].SetActive(true);
            yield return new WaitForSeconds(0.6f);
        }

        yield return new WaitForSeconds(0.01f);
    }

}
