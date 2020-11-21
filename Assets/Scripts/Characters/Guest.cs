using UnityEngine;
using Random = System.Random;

namespace Characters
{
    public class Guest : MonoBehaviour
    {
        public float speed = 3f;
        private float _horizontal;
        private float _vertical;
        
        public int money;
        public int mood;

        private void Start()
        {
            var random = new Random();
            money = random.Next(5, 10);
            mood = random.Next(1, 5);
        }
        
        // private void Move()
        // {
        //     Vector2 position = _rigidbody2D.position;
        //
        //     position.x = position.x + speed * _horizontal * Time.deltaTime;
        //     position.y = position.y + speed * _vertical * Time.deltaTime;
        //
        //     _rigidbody2D.MovePosition(position);
        // }
        //
        // private void Rotation()
        // {
        //     _rotZ = Mathf.Atan2(-_vertical, -_horizontal) * Mathf.Rad2Deg;
        //
        //     if (_horizontal != 0 || _vertical != 0)
        //     {
        //         transform.rotation = Quaternion.Euler(0f, 0f, _rotZ);
        //     }
        // }
    }
}