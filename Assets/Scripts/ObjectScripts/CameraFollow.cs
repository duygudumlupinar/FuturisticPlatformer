using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private float Speed = 2f;

    void Update()
    {
        Vector3 newPosition = new Vector3(Target.position.x + 5f, transform.position.y , -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, Speed);
    }
}
