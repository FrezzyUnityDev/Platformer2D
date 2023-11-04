using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private Animator animator;
    [SerializeField] public Transform playerModelTransform;
    [SerializeField] private float speedX = -1f;
    [SerializeField] private FixedJoystick _fixedJoystick;

    private float _horizontal = 0f;
    private bool _isFacingRight = true;

    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFinish = false;
    private bool _isLevelArm = false;

    private Rigidbody2D _rb;
    private Finish _finish;
    private LevelArm _levelArm;
    

    const float speedxMultiplier = 50f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
        _levelArm = FindObjectOfType<LevelArm>();
    }

    void Update()
    {

        _horizontal = Input.GetAxis("Horizontal"); // -1 : 1
        //_horizontal = _fixedJoystick.Horizontal;
        animator.SetFloat("speedX", Mathf.Abs(_horizontal));
        if (Input.GetKeyDown(KeyCode.W) && _isGround)
        {
            _isJump = true;
            jumpSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_isFinish)
            {
                _finish.FinishLevel();
            }
            if (_isLevelArm)
            {
                _levelArm.ActivateLevelArm(); 
            }
        }
    }

    void FixedUpdate()
    {

        _rb.velocity = new Vector2(_horizontal * speedX * speedxMultiplier * Time.fixedDeltaTime, _rb.velocity.y);


        if (_isJump)
        {
            _rb.AddForce(new Vector2(0f, 500f));
            _isGround = false;
            _isJump = false;
        }
        if (_horizontal > 0f && !_isFacingRight)
        {
            Flip();
        }
        else if (_horizontal < 0f && _isFacingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = playerModelTransform.localScale;
        playerScale.x *= -1;
        playerModelTransform.localScale = playerScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelArm levelArmTemp = other.GetComponent<LevelArm>();
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Worked");
            _isFinish = true;
        }
        if (levelArmTemp != null)
        {
            _isLevelArm = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        LevelArm levelArmTemp = other.GetComponent<LevelArm>();
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Not worked");
            _isFinish = false;
        }
        if (levelArmTemp != null)
        {
            _isLevelArm = false;
        }
    }
}   
 


