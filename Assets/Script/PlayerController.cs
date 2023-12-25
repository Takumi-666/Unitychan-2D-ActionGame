using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float gravity; //重力
    public float jumpSpeed;//ジャンプする速度
    public float jumpHeight;//高さ制限
    public float jumpLimitTime;//ジャンプ制限時間
    public GroundCheck ground; //接地判定
    public GroundCheck head;//頭ぶつけた判定

    public AudioClip jumpSound; // ジャンプの効果音
    private AudioSource audioSource;

    // SpriteRendererコンポーネントのインスタンスを取得
    private SpriteRenderer spriteRenderer = null;

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        // スペースキー入力をチェック
        bool jumpKey = Input.GetKey(KeyCode.Space);

        if (isGround)
        {
            if (jumpKey)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
                // 効果音を再生
                audioSource.PlayOneShot(jumpSound);
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            // スペースキーを押し続けているか
            bool pushUpKey = jumpKey;
            // その他の条件は変更なし
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }
        if (horizontalKey > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("Run", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("Run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("Run", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        anim.SetBool("Jamp", isJump); //New
        anim.SetBool("Ground", isGround); //New
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}