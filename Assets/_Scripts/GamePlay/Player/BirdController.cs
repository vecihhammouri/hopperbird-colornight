using _Scripts.Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts.GamePlay.Player
{
    public class BirdController : MonoBehaviour
    {
        public static BirdController Instance;
        
        private bool _isDead;
        private bool _jumping;
        private Rigidbody2D _rigidBody2D;
        private Animator _animator;

        private bool _hitSoundPlayed;
        private bool _dieSoundPlayed;
        [SerializeField] private AudioClip flapSound;
        [SerializeField] private AudioClip hitSound;
        [SerializeField] private AudioClip dieSound;
            
        [SerializeField] private float jumpForce = 250.0f;
        private static readonly int Flap = Animator.StringToHash("Flap");
        private static readonly int Died = Animator.StringToHash("Died");

        private void Singleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }
        
        private void Awake()
        {
            Singleton();
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
            if(EventSystem.current.IsPointerOverGameObject()) return;
            if (Input.GetMouseButtonDown(0))
            {
                _jumping = true;
            }
        }

        private void Jump()
        {
            _animator.SetTrigger(Flap);
            StartCoroutine(AudioManager.Instance.PlaySound(flapSound));
            _rigidBody2D.velocity = Vector2.zero;
            _rigidBody2D.AddForce(new Vector2(0,jumpForce));
            _jumping = false;
           
        }


        public void SetVelocityResume()
        {
            _rigidBody2D.velocity = Vector2.zero;
        }
        
        private void OnCollisionEnter2D()
        {
            _isDead = true;
            _animator.SetTrigger(Died);
            if (!_hitSoundPlayed)
            {
                StartCoroutine(AudioManager.Instance.PlaySound(hitSound));
                _hitSoundPlayed = true;
            }

            
            if (!_dieSoundPlayed)
            {
                StartCoroutine(AudioManager.Instance.PlaySound(dieSound));
                _dieSoundPlayed = true;
            }
            
            
            GameManager.Instance.GameOver();
        }
    }
}