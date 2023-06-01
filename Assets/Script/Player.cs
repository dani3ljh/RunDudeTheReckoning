using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canWalk;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canWalk = true;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Walk(x);
    }

    void Walk(float x) {
        if (!canWalk) return;
        rb.velocity = new Vector2(x * speed, 0);
    }
}
