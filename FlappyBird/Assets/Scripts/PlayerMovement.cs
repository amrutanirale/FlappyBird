using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance = null;
    public float forceUp = 100f;
    public Rigidbody2D rb;
    private bool isDead = false;
    private Animator anim;
    public AudioClip flap;
    public AudioClip hit;
    private bool isHitAudioPlayer;
    private AudioSource source;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isHitAudioPlayer = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.isKinematic = true;
        anim.SetTrigger("Flap");
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isDead == false && UIManager.Instance.isGameStarted == true)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * forceUp);
            anim.SetTrigger("Flap");
            source.PlayOneShot(flap, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector3.zero;
        isDead = true;
        anim.SetTrigger("Die");
        if (isHitAudioPlayer == false)
        {
            source.PlayOneShot(hit, 1f);
            isHitAudioPlayer = true;
        }
        UIManager.Instance.BirdDied();

    }

}
