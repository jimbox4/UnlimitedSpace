using UnityEngine;

public class Movement
{
    public void MoveForward(Transform transform, float speed)
    {
        transform.position += Vector3.forward * speed;
    }

    public void MoveBackward(Transform transform, float speed)
    {
        transform .position -= Vector3.forward * speed;
    }
}
