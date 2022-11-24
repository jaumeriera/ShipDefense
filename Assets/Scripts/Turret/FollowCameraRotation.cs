using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraRotation : MonoBehaviour
{
    [Header("Object Dependencies")]
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject bodyToRotate;

    [Header("Limits configuration")]
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;


    Vector3 newRotation;
    float xAngle;
    float yAngle;

    const float ANGLE = 360f;

    void Update()
    {
        xAngle = mainCamera.transform.eulerAngles.x;
        
        if(xAngle < 180) {
            xAngle = Mathf.Clamp(xAngle, 0, maxX);
        } else {
            xAngle = Mathf.Clamp(xAngle, ANGLE - minX, ANGLE);
        }

        yAngle = mainCamera.transform.eulerAngles.y;
        
        if(yAngle < 180) {
            yAngle = Mathf.Clamp(yAngle, 0, maxY);
        } else {
            yAngle = Mathf.Clamp(yAngle, ANGLE - minY, ANGLE);
        }

        newRotation = new Vector3(xAngle, yAngle, 0);
        bodyToRotate.transform.eulerAngles = newRotation;
    }
}
