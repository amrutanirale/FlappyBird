
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (UIManager.Instance.isGameStarted == true)
        {
            rb.velocity = new Vector2(-UIManager.Instance.speedLeft, 0);

        }
        if (UIManager.Instance.gameOver == true)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
