using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Board : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 1;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody2D.mass = 0;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void FixedUpdate ()
    {
        _rigidbody2D.velocity = Vector2.left * speed;
    }
}
