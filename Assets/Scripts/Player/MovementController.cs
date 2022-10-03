using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public ParticleSystem dust;
    public float MovementSpeed = 5f;
    public float JumpForce = 1f;
    public Animator animator;
    public bool isCrouching;
    public bool shootingUp;
    private bool aimRight;
    public bool doubleJumpEnabler;
    private bool doubleJumpCooldown;

    public int speedMultiplier;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        isCrouching = false;

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

    private void Crouch()
    {
        //Crouch Logic
        if(Input.GetButtonDown("Crouch")){ 
            isCrouching = true; 
        }
        
        if(Input.GetButtonUp("Crouch")){
            isCrouching = false;
        }

        //Animation Logic
        if (isCrouching && IsGrounded()){
            animator.SetBool("IsCrouching", true);
        }
        else{
            animator.SetBool("IsCrouching", false);
        }
    }

    private void ShootUp()
    {

        //Shoot Up Logic
        if(Input.GetButtonDown("ShootUp")){ 
            shootingUp = true; 
        }
        
        if(Input.GetButtonUp("ShootUp")){
            shootingUp = false;
        }

        //Animation Logic
        if (shootingUp){
            animator.SetBool("isShootingUp", true);
        }
        else{
            animator.SetBool("isShootingUp", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("isJumping", true);
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        }
        else if (Input.GetButtonDown("Jump") && _rigidbody.velocity.y > 0) //Double Jump Upgrade!!!
        {   
            if(doubleJumpCooldown == true && doubleJumpEnabler == true)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                doubleJumpCooldown = false;
            }
        }
        else if (IsGrounded())
        {
            animator.SetBool("isJumping", false);
            doubleJumpCooldown = true;

        }
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

    private void Rotate(float movement, float height)
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

    private void Movement()
    {

        //Thank you Distorted Pixel Studios on Youtube for this!
        var movement = Input.GetAxis("Horizontal") * speedMultiplier;
        var height = _rigidbody.velocity.y;

        if(!isCrouching)
        {
            transform.position = transform.position + new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
        }
        

        animator.SetFloat("speed", Mathf.Abs(movement));
        animator.SetFloat("height", Mathf.Abs(height));

        //TODO: After player jumps, if holding LEFT or RIGHT while on a platform they get stuck in the middle of the jumping animation! FIX IT!

        Rotate(movement, height);
        
        Jump();

        Crouch();

        ShootUp();

    }

    private void Update()
    {
     Movement();  
    }
}
