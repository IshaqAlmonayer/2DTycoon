using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 startPos;
    private Vector2 _touchDirection;

    private Rigidbody2D _rigidbody;
    private float _moveDirection = 0;
    private Vector2 _movement;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
            _moveDirection = horizontalInput;
        else
            _moveDirection = 0;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    _touchDirection = touch.position - startPos;
                    if(_touchDirection.x > 0)
                    {
                        _moveDirection = -1f;
                    }
                    if (_touchDirection.x < 0)
                        _moveDirection = 1f;
                    break;
                case TouchPhase.Ended:
                    _moveDirection = 0f;
                    break;
            }

          
        }

        _movement = new Vector2(_moveDirection, 0f);

    }


    void FixedUpdate()
    {
        float HorizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(HorizontalVelocity, _rigidbody.velocity.y);
    }


}
