using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector2 mouseLook;
    Vector2 smoothV;
    Vector2 deltaScale;
    private float deltaX, deltaY;
    public float sensitivity = 2.0f;
    public float smoothing = 1.5f;

    GameObject character;

    void Start()
    {
        character = this.transform.parent.gameObject;
        deltaScale = new Vector2(sensitivity * smoothing, sensitivity * smoothing);
        deltaX = 0f;
        deltaY = 0f;
    }

    void LateUpdate()
    {
        deltaX += Input.GetAxis("Mouse X") * sensitivity * smoothing;
        deltaY += Input.GetAxis("Mouse Y") * sensitivity * smoothing;
        deltaY = Mathf.Clamp(deltaY, -90f, 90f);
        smoothV.x = Mathf.Lerp(smoothV.x, deltaX, 1.0f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, deltaY, 1.0f / smoothing);

        mouseLook += smoothV;

        transform.localRotation = Quaternion.Euler(-deltaY, 0f, 0f);
        character.transform.localRotation = Quaternion.Euler(0f, deltaX, 0f);
    }
}
