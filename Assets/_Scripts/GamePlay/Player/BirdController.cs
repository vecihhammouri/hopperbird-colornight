using _Scripts.Manager;
using UnityEngine;

namespace _Scripts.GamePlay.Player
{
    public class BirdController : MonoBehaviour
    {
        private bool _isDead;
        private bool _jumping;
        private Rigidbody2D _rigidBody2D;
        private Animator _animator;
        [SerializeField] private float jumpForce = 250.0f;
        private static readonly int Flap = Animator.StringToHash("Flap");
        private static readonly int Died = Animator.StringToHash("Died");

        private void Awake()
        {
            GetReferences();
        }
        
        private void FixedUpdate()
        {
            if (_jumping)
            {
                Jump();
            }
        }

        private void Update()
        {
            CheckInput();
        }
        
        private void GetReferences()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void CheckInput()
        {
            if (_isDead) return;
            if (Input.GetMouseButtonDown(0))
            {
                _jumping = true;
            }
        }

        private void Jump()
        {
            _animator.SetTrigger(Flap);
            _rigidBody2D.velocity = Vector2.zero;
            _rigidBody2D.AddForce(new Vector2(0,jumpForce));
            _jumping = false;
        }

        private void OnCollisionEnter2D()
        {
            _isDead = true;
            _animator.SetTrigger(Died);
            GameManager.Instance.GameOver();
        }
    }
}