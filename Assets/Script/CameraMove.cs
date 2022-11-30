using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private FixedJoystick joystick;
    private Vector3 newPos;
    private float moveSpeed;

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }

    private void Update()
    {
        newPos = transform.position;
        moveSpeed = joystick.Horizontal * 1f * Time.deltaTime;
        newPos.x += moveSpeed;
        newPos.x = Mathf.Clamp(newPos.x, -2.5f, 2.5f);
        transform.position = newPos;
    }
}
