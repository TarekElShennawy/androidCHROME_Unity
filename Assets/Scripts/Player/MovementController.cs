using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    //Start() Variables
    private Rigidbody2D _rigidbody;
    private BoxCollider2D coll;

    public ParticleSystem dust;

    //Inspector Variables
    public float MovementSpeed;
    public float JumpForce = 1f;
    public Animator animator;
    public bool shootingUp;
    private bool aimRight;
    public bool doubleJumpEnabler;
    private bool doubleJumpCooldown;
    public int speedMultiplier;

    //Audio Variables
    public AudioSource playerAudioSource;
    public AudioSource playerFootsteps;
    public AudioClip jumpSFX;
    public AudioClip doubleJumpSFX;

    //Test Var

    public Vector2 move;
    
    //Private variables
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        doubleJumpEnabler = false;

        speedMultiplier = 1;
        
    }

    bool IsGrounded() {
        //Thank you kylewblanks.com for the explanation! (swapped this raycast instead of a boxcast)
    Vector2 position = transform.position;
    Vector2 direction = Vector2.down;
    float distance = 1.0f;
    
    RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

    if (hit.collider != null) {
        return true;
    }
    
    return false;
    }

    

    private void DoubleJump()
    {
        if(doubleJumpCooldown == true && doubleJumpEnabler == true)
            {
                playerAudioSource.PlayOneShot(doubleJumpSFX);
                _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                doubleJumpCooldown = false;
            }
    }

    private void Jump()
    {
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            playerAudioSource.PlayOneShot(jumpSFX);
    }

    private void Footsteps()
    {
        playerFootsteps.Play();
    }

    //Thank you Brackeys for the Flip logic :)
    private void Flip()
	{
        //Dust effect for Zoom upgrade
        if(speedMultiplier > 1)
        {
            dust.Play();
        }

		// Switch the way the player is labelled as facing.
		aimRight = !aimRight;

		transform.Rotate(0f, 180f, 0f);
	}
    private void Rotate(float movement)
    {
        //Rotation logic
        if (movement > 0 && aimRight)
        {
            //Right
            Flip();
        }
        else if(movement < 0 && !aimRight)
        {
            //Left
            Flip();
        }
    }

    private void Update()
    {
        var height = _rigidbody.velocity.y;
        animator.SetFloat("height", Mathf.Abs(height));

        //Jump logic re-worked, if statements are now in update to detect player input as soon as possible

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }   
        else if (Input.GetButtonDown("Jump") && height > 0)
        {
            DoubleJump();
        }

        //allow double jump when player falls on ground

        if (IsGrounded() && doubleJumpEnabler == true)
        {
            doubleJumpCooldown = true;
        }

        
        move.x = Input.GetAxis("Horizontal") * MovementSpeed;
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(move.x * MovementSpeed * Time.deltaTime, _rigidbody.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(move.x));
        Rotate(move.x);
    }
}
