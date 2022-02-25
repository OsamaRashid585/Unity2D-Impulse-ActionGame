using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform _player;
    private Rigidbody2D _rb;
   [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pushPower = 1;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        var distance = (_player.position - transform.position).normalized;
        _rb.AddForce(distance * _moveSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            GameManger.Instance.Score += 25;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            var direction =  collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * _pushPower, ForceMode2D.Impulse);
            Debug.Log("hit");
        }

    }

}
