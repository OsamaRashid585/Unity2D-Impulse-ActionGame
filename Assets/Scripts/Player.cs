using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movementInput;
    private float _moveSpeed = 20f;
    
   [SerializeField] private GameObject _projectArea;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //getting input for movement
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
   

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _rb.AddForce(_movementInput * _moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
