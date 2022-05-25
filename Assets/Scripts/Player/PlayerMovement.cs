using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpHeight;

    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    private bool isJumping;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    public Vector3 respawnPoint;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        respawnPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * Speed, body.velocity.y);
        
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
        if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            SoundManager.Instance.PlaySound(jumpSound);
            body.velocity = new Vector2(body.velocity.x, JumpHeight);
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                body.velocity = new Vector2(body.velocity.x, JumpHeight);
                jumpTimeCounter-=Time.deltaTime;
            }
            else
                isJumping = false;
        }
        if(Input.GetKeyUp(KeyCode.Space))
            isJumping=false;
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            foreach(ContactPoint2D contact in collision.contacts)
            {
                //Only from above
                if (contact.normal.y >= 0.9f)
                    collision.gameObject.GetComponent<Health>().TakeDamage(1);
            }
        }
    }

    public void Dead()
    {
        transform.position = respawnPoint;
    }
}