using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public GameManager gameManager;
    public float maxSpeed;
    public float jumpPower;
    public bool isJumping = false;
    public float jumpTimer=0;
    public float jumpTimeLimit=0.1f;
    BoxCollider2D boxCol;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public GameObject bubble;
    public AudioClip pop;

    public AudioClip damaged;
    public AudioClip jump;
    public AudioClip die;
    new AudioSource audio;

    int playerL, playerL2, platformL;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        audio = this.gameObject.GetComponent<AudioSource>();

        playerL = LayerMask.NameToLayer("Player");
        playerL2 = LayerMask.NameToLayer("PlayerDamaged");
        platformL = LayerMask.NameToLayer("Platform");
    }

    void Update()
    {
        // Jump
        if (gameManager.health > 0)
        {
            if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping") && rigid.velocity.y == 0)
            {
                anim.SetBool("isJumping", true);
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                audio.clip = jump;
                this.audio.Play();
            }


            //stop speed
            if (Input.GetButtonUp("Horizontal"))
            {
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.0000000001f, rigid.velocity.y);
            }

            // direction sprite
            if (Input.GetButton("Horizontal"))
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            }

            // Animation
            if (rigid.velocity.normalized.x == 0)
                anim.SetBool("isWalking", false);
            else
                anim.SetBool("isWalking", true);

            // layer
            if (rigid.velocity.y > 0)
            {
                Physics2D.IgnoreLayerCollision(playerL, platformL, true);
                Physics2D.IgnoreLayerCollision(playerL2, platformL, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(playerL, platformL, false);
                Physics2D.IgnoreLayerCollision(playerL2, platformL, false);
            }
        }
    }
    void FixedUpdate()
    {
        // bubble
        if (gameManager.isBubbled) bubble.gameObject.SetActive(true);
        else bubble.gameObject.SetActive(false);

        // move speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // max speed
        if (rigid.velocity.x > maxSpeed)// right max speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))// left max speed
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.BoxCast(boxCol.bounds.center - new Vector3(0,0.5f,0), boxCol.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.1f)
                    anim.SetBool("isJumping", false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (gameManager.isBubbled)
            {
                Destroy(collision.gameObject);
                gameManager.isBubbled = false;
                audio.clip = pop;
                audio.Play();
            }
            else
            {
                Destroy(collision.gameObject);
                OnDamaged(collision.transform.position);
            }
        }
    }

    public void OnDamaged(Vector2 targetPos)
    {
        audio.clip = damaged;
        this.audio.Play();

        // change layer
        gameObject.layer = 9;

        // call func
        gameManager.HealthDown();

        // view alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // reaction force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 2.5f, ForceMode2D.Impulse);

        Invoke(nameof(OffDamaged), 1.5f);
    }

    void OffDamaged()
    {
        gameObject.layer = 8;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void OnDie()
    {
        audio.clip = die;
        this.audio.Play();
        // sprite alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        // sprite flip
        spriteRenderer.flipY = true;
        // collider disable
        boxCol.enabled = false;
        // die effect jump
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }
}
