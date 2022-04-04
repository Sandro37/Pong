using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        float Xvelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float Yvelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        rig.velocity = new Vector2(Xvelocity, Yvelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            rig.velocity *= velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal1"))
        {
            GameManager.Instance.Paddle2Scored();
            GameManager.Instance.Restart();
            Launch();
        }else if (collision.CompareTag("Goal2"))
        {
            GameManager.Instance.Paddle1Scored();
            GameManager.Instance.Restart();
            Launch();
        }
    }
}
