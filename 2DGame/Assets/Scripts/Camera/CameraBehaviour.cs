using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] GameObject limiter;

    [SerializeField] GameObject mouse;

    [SerializeField] Transform cameraLock;

    [HideInInspector] public bool cameraLocked;

    // Update is called once per frame
    void Update()
    {
        /*if (mouse.transform.position.x > limiter.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x, mouse.transform.position.y, -10);
            cameraLocked = false;
        }
        else
        {
            transform.position = new Vector3(cameraLock.transform.position.x, cameraLock.transform.position.y, -10);
            cameraLocked = true;
        }*/

        transform.position = new Vector3(mouse.transform.position.x, -6, -10);
    }
}
