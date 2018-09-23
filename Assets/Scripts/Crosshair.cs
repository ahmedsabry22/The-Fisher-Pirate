using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private void LateUpdate()
    {
        Vector2 targetPoition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(targetPoition.x >= -1)
            transform.position = targetPoition;
    }
}