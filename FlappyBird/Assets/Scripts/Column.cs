using UnityEngine;

public class Column : MonoBehaviour
{
    public bool isScore;

    // Use this for initialization
    void Start()
    {
        isScore = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isScore == false)
            {
                UIManager.Instance.BirdScore();
                isScore = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isScore = false;
    }
}
