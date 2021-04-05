using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHandle : MonoBehaviour
{
    private Vector3 PositionHandle;
    private Vector3 RotationHandle;

    private Vector3 newPositionHandle;
    private Vector3 newRotationHandle;

    public static bool isInputHandle;

    private void Start()
    {
        isInputHandle = false;

        PositionHandle = this.transform.localPosition;
        RotationHandle = this.transform.localEulerAngles;

        newPositionHandle = new Vector3(-0.0004f, 0.0004f, -0.0019f);
        newRotationHandle = new Vector3(6.8f, 2.33f, 4.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandLeft" && OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            this.transform.localPosition = newPositionHandle;
            this.transform.localEulerAngles = newRotationHandle;

            isInputHandle = true;
        }
        else if (other.tag == "HandRigth" && OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            this.transform.localPosition = newPositionHandle;
            this.transform.localEulerAngles = newRotationHandle;

            isInputHandle = true;
        }
        else
        {
            this.transform.localPosition = PositionHandle;
            this.transform.localEulerAngles = RotationHandle;

            isInputHandle = false;
        }
    }

}
