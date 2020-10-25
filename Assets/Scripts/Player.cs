using UnityEngine;

public class Player : MonoBehaviour {
    public Joystick joystick;
    private Rigidbody2D _rigidbody2D;

    public float speed = 3f;
    private float _horizontal;
    private float _vertical;
    private float _rotZ;

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        _horizontal = joystick.Horizontal;
        _vertical = joystick.Vertical;

        RotationPlayer();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MovePlayer() {
        Vector2 position = _rigidbody2D.position;

        position.x = position.x + speed * _horizontal * Time.deltaTime;
        position.y = position.y + speed * _vertical * Time.deltaTime;

        _rigidbody2D.MovePosition(position);
    }

    private void RotationPlayer() {
        _rotZ = Mathf.Atan2(-_vertical, -_horizontal) * Mathf.Rad2Deg;

        if (_horizontal != 0 || _vertical != 0) {
            transform.rotation = Quaternion.Euler(0f, 0f, _rotZ);
        }
    }
}