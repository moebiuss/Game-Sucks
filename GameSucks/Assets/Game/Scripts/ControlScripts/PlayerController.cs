using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float swerveSpeed;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    [SerializeField] private float _movementClampNegative;
    [SerializeField] private float _movementClampPositive;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private PlayerControlState playerControlState;
    public float MoveFactorX => _moveFactorX;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (playerControlState)
        {
            case PlayerControlState.MOBILE:
                HorizontalMovementMobile();
                break;
            case PlayerControlState.PC:
                MovementInputPc();
                break;
            default:
                break;
        }
    }

    private void MovementInputPc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _moveFactorX = Mathf.Clamp(MoveFactorX, -2, 2);
            print(_moveFactorX);
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
        float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
        //transform.Translate(swerveAmount, 0, 0);
    }

    private void HorizontalMovementMobile()
    {
        if (Input.touchCount > 0)
        {
            Touch _theTouch = Input.GetTouch(0);

            if (_theTouch.phase == TouchPhase.Moved)
            {
                Vector2 touchPos = _theTouch.deltaPosition;
                if (touchPos != Vector2.zero)
                {
                    
                    //transform.Translate(touchPos.x * (horizontalSpeed / 100) * Time.deltaTime, 0, 0);
                    //transform.position = new Vector3(Mathf.Clamp(transform.position.x, _movementClampNegative, _movementClampPositive), transform.position.y, transform.position.z);
                }
            }
        }
    }
}
