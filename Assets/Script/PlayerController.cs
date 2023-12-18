using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public GameObject gameClearPanel; // ゲームクリアパネル
    public GameObject gameOverPanel;  // ゲームオーバーパネル

    private Rigidbody2D rb;
    private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ゲーム開始時にパネルを非表示にする
        gameClearPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void FixedUpdate()
    {
        // 左右の移動
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            // ゲームクリアパネルを表示
            gameClearPanel.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // ゲームオーバーパネルを表示
            gameOverPanel.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
