using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _pushPower;
    private Vector3 _mousePos;
    private float _currentRotationSpeed;
    private float _smoothTime;
    private float _angle;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProjecttileareaRotatewithMouse();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && Input.GetKey(KeyCode.Mouse0))
        {
            var direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * _pushPower, ForceMode2D.Impulse);
        }
        
    }
    private void ProjecttileareaRotatewithMouse()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = _mousePos - transform.position;
        var targetangle = Vector2.SignedAngle(Vector2.up, direction);
        _angle = Mathf.SmoothDampAngle(_angle, targetangle, ref _currentRotationSpeed, _smoothTime);
        transform.eulerAngles = new Vector3(0, 0, _angle);
    }
}
