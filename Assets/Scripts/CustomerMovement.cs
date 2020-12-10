using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomerMovement : MonoBehaviour
{
    public float speed = 0.1f;

    //Movement
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private float _direction = 1;

    //Animation
    private Animator _animator;

    //Stop and wait at stands
    private bool _isAtStand = false;
    private float _waitTime = 0f;
    public float standWaitTime;

    //Added to make the xustomer stop in a queue
    private bool _inQueue = false;

    //Added to make the customer stop at diffirent stands not just one
    public string _standType;
    public GameObject CustomerBack;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        ////set layer equal to stand type (to avoid collisions between diffirent stands)
        switch (_standType)
        {
            case "1":
                gameObject.layer = 8;
                CustomerBack.layer = 8;
                break;
            case "2":
                gameObject.layer = 9;
                CustomerBack.layer = 9;
                break;
            case "3":
                gameObject.layer = 10;
                CustomerBack.layer = 10;
                break;
            case "4":
                gameObject.layer = 12;
                CustomerBack.layer = 12;
                break;
            case "5":
                gameObject.layer = 14;
                CustomerBack.layer = 14;
                break; 
            case "6":
                gameObject.layer = 15;
                CustomerBack.layer = 15;
                break;
            case "7":
                gameObject.layer = 16;
                CustomerBack.layer = 16;
                break;
            case "8":
                gameObject.layer = 17;
                CustomerBack.layer = 17;
                break;
            case "9":
                gameObject.layer = 18;
                CustomerBack.layer = 18;
                break;
            case "10":
                gameObject.layer = 19;
                CustomerBack.layer = 19;
                break;
        }
    }

    void Update()
    {
        //movement and waiting in queue and stands
        if (!_isAtStand && !_inQueue)
        {
            _movement = new Vector2(_direction, 0f);
        }
        else
        {
            _movement = new Vector2(0f, 0f);
        }

        if (_waitTime > 0)
            _waitTime -= Time.deltaTime;
        else
            _isAtStand = false;

    }

    void FixedUpdate()
    {
        //movement
        float HorizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(HorizontalVelocity, _rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //stop at stands
        if (other.gameObject.tag.Equals("Stand"))
        {
            _isAtStand = true;
            _waitTime = standWaitTime;
        }

        if (other.gameObject.tag.Equals("CustomerBack"))
        {
            _inQueue = true;
        }
    }

    //stop in queue
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("CustomerBack"))
        {
            _inQueue = false;
        }
    }

    private void LateUpdate()
    {
        if (_isAtStand || _inQueue)
            _animator.SetBool("isIdle", true);
        else
            _animator.SetBool("isIdle", false);
    }

}
