using System;
using UnityEngine;

public interface IInputSystem
{
    public event Action<int> KeyDirectionPressed;
    public event Action<UnityEngine.Vector2> MouseInput;

    public void Update();

    public void Initialize(Camera camera, Transform cameraTarget);
}
