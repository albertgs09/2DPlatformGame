using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpSpeed = 16f;
    [SerializeField] private Transform[] points;
    private Animator anim;
    private Rigidbody2D rb;
    private int currentPoint = 0;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, points[currentPoint].position) >= 0)
        {
            transform.Translate(points[currentPoint].position * moveSpeed * Time.deltaTime);

        }
        else
        {
        }
    }
}
