using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newRotation = new Vector3(0, 0, 0);
        this.transform.eulerAngles = newRotation;
    }

}
