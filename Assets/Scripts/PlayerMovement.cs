using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public float minJump;
    [SerializeField] public float maxJump;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    public Vector3 respawnPoint;
    
    private float jumpHeight;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        respawnPoint = transform.position;

        jumpHeight = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //Flip sprite when moving left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (horizontalInput < - 0.01f)
        {
            transform.localScale = new Vector3(-0.3f,0.3f,0.3f);
        }
        //Jump logic
        if (isGrounded())
        {
            body.velocity = new Vector2(0f, 0f);
            if (!Input.GetKey(KeyCode.Space) && 
                (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                )
            {
                jump(minJump, minJump);
            }

            //Charge jump
            if (Input.GetKey(KeyCode.Space))
            {
                if (jumpHeight < maxJump)
                {
                    jumpHeight += Time.deltaTime * maxJump;
                }
                else
                {
                    jumpHeight = maxJump;
                }
            }
            //Do jump action
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (jumpHeight < minJump) { jumpHeight = minJump; }
                jump(jumpHeight / 2, jumpHeight);
                jumpHeight = 0;
            }
        }
            
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        return raycastHit.collider != null;
    }
    private void jump(float length, float height)
    {
        if (transform.localScale.x < 0f)
            body.velocity = new Vector2( length * -1,  height);
        else if (transform.localScale.x > 0f)
            body.velocity = new Vector2( length * 1,  height);
        print("jump");
    }

    public void Dead()
    {
        transform.position = respawnPoint;
    }
}