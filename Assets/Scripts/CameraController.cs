using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 2f;
    public float _minX = -2.5f;
    public float _maxX = 3f;

    private Rigidbody2D _rigidbody;
    private float _direction;
    private Vector2 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(_direction, 0f);
    }


    void FixedUpdate()
    {
        float HorizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(HorizontalVelocity, _rigidbody.velocity.y);
    }


}
