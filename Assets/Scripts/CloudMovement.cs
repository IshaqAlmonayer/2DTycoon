using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private float _direction = 1;

    public float speed = 2f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector2(_direction, 0f);
    }

    void FixedUpdate()
    {
        //movement
        float HorizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(HorizontalVelocity, _rigidbody.velocity.y);
    }

}
