using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class KeyboardMouseInput : IInputSystem
{
    private const KeyCode KeyS = KeyCode.S;
    private const KeyCode KeyW = KeyCode.W;

    private static string MouseAxisX = "Mouse X";
    private static string MouseAxisY = "Mouse Y";

    private const int Forward = 1;
    private const int Backward = -1;
    private const int NoDirection = 0;

    private Camera _camera;
    private Transform _cameraTarget;

    private float _cameraDistance = 13.5f;
    private float _cameraSpeedX = 2f;
    private float _cameraSpeedY = 2f;
    private float _cameraMinDistance = 8f;
    private float _cameraMaxDistance = 20f;
    private float _cameraZoomSpeed = 10f;
    private float _cameraRotationY;
    private float _cameraRotationX;
    private float _smoothTime = 0.2f;
    private float _cameraOffsetY = 4f;

    private Vector3 _cameraCurrentRatation;
    private Vector3 _smoothVelocity = Vector3.zero;
    private Vector2 _rotationYMinMax = new Vector2(-60, 60);

    public event Action<int> KeyDirectionPressed;
    public event Action<Vector2> MouseInput;

    private int _moveDirection;

    public void Initialize(Camera camera, Transform cameraTarget)
    {
        _cameraTarget = cameraTarget;
        _camera = camera;
    }

    public void Update()
    {
        UseKeyboardInput();
        UseMouseInput();
    }

    private async void UseKeyboardInput()
    {
        if (Input.GetKey(KeyW) && _moveDirection != Forward)
        {
            _moveDirection = Forward;
            KeyDirectionPressed?.Invoke(_moveDirection);
        }
        else if (Input.GetKey(KeyS) && _moveDirection != Backward)
        {
            _moveDirection = Backward;
            KeyDirectionPressed?.Invoke(_moveDirection);
        }
        else if (_moveDirection != NoDirection && Input.GetKey(KeyW) == false && Input.GetKey(KeyS) == false)
        {
            _moveDirection = NoDirection;
            KeyDirectionPressed?.Invoke(_moveDirection);
        }
        await UniTask.WaitForFixedUpdate();
    }

    private async void UseMouseInput()
    {
        float mouseX = Input.GetAxis(MouseAxisX) * _cameraSpeedX;
        float mouseY = Input.GetAxis(MouseAxisY) * _cameraSpeedY;

        _cameraDistance = Mathf.Clamp(_cameraDistance - Input.GetAxis("Mouse ScrollWheel") * _cameraZoomSpeed, _cameraMinDistance, _cameraMaxDistance);
        _cameraRotationX += mouseX;
        _cameraRotationY -= mouseY;

        // Apply clamping for x rotation 
        _cameraRotationY = Mathf.Clamp(_cameraRotationY, _rotationYMinMax.x, _rotationYMinMax.y);

        Vector3 nextRotation = new Vector3(_cameraRotationY, _cameraRotationX);

        // Apply damping between rotation changes
        _cameraCurrentRatation = Vector3.SmoothDamp(_cameraCurrentRatation, nextRotation, ref _smoothVelocity, _smoothTime);
        _camera.transform.localEulerAngles = _cameraCurrentRatation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        _camera.transform.position = 
            new Vector3(_cameraTarget.position.x, _cameraTarget.position.y, _cameraTarget.position.z) - 
            _camera.transform.forward * _cameraDistance + _cameraTarget.up * _cameraOffsetY;

        await UniTask.WaitForFixedUpdate();
    }
}
