using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HandleLine : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject sphereEndLine;

    [SerializeField] private Vector3 beginPos;
    [SerializeField] private Vector3 endPos;

    private GameObject extinguisher;

    private LineRenderer line;

    public static bool isStartCituation;

    private void Start()
    {
        isStartCituation = false;
        line = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        sphereEndLine.SetActive(true);
        transform.rotation = transform.parent.rotation;

        Vector3 position= new Vector3(transform.position.x, transform.position.y, transform.position.z + maxDistance);
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if(hit.collider.name == "ButtonExit" && OVRInput.Get(OVRInput.Button.One))
            {
                SceneManager.LoadScene("StartInfo");
            }
            
           if (hit.collider.gameObject.tag == "ActiveItem" || hit.collider.gameObject.tag == "extinguisher")
           {
                isStartCituation = true;

                if (hit.distance > 0.8f || hit.collider.gameObject.name == "DialogButton")
                {
                    sphereEndLine.transform.position = hit.point;
                    line.SetPosition(1, hit.point);

                    if (hit.collider.gameObject.tag == "extinguisher")
                    {
                        extinguisher = hit.collider.gameObject;
                        extinguisher.GetComponent<Renderer>().material.color = Color.yellow;

                    }else if (hit.collider.gameObject.tag != "extinguisher" && extinguisher)
                    {
                        extinguisher.GetComponent<Renderer>().material.color = Color.white;
                        extinguisher = null;
                    }

                }
                else
                {
                    sphereEndLine.SetActive(false);
                    line.startWidth = 0f;
                    line.endWidth = 0f;
                }

           }
           else
           {
              LineIsWorldRay();
           }
        }
        else
        {
          LineIsWorldRay(); 
        }

    }

    private void LineIsWorldRay()
    {
        line.startWidth = 0f;
        line.endWidth = 0.007f;

        Vector3 newBeginPos = transform.localToWorldMatrix * new Vector4(beginPos.x, beginPos.y, beginPos.z, 1);
        Vector3 newEndPos = transform.localToWorldMatrix * new Vector4(endPos.x, endPos.y, endPos.z, 1);

        sphereEndLine.transform.position = newEndPos;

        line.SetPosition(0, newBeginPos);
        line.SetPosition(1, newEndPos);
    }

}
