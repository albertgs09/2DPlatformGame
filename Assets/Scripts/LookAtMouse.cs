using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform m_transform;
    void Start()
    {
        m_transform = this.transform;
    }

    void Update()
    {
        LAMouse();
    }

    private void LAMouse()
    {
        //gets main camera and gets direction from this position to mousePosition
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        //create a float and get its  tangent between direction x and y then convert it to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;
        //AngleAxis rotates something around an axis, give angle you want it to rotate towards, -90 if art is facing right, +90 if racing left
        Quaternion rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
        //update the transforms rotation
        m_transform.rotation = rotation;
    }
}
