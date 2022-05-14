using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance = null;
    public GameObject[] obstacle;
    public int amountToPool = 3;
    private Vector2 objPoolPos = new Vector2(-20f, -30f);
    public GameObject obstaclePrefab;
    private float timer;

    private float spawnRate;
    [SerializeField]
    private float minSpawnRate = 1f;
    [SerializeField]
    private float maxSpawnRate = 4f;

    [SerializeField]
    private float minYPos = -2f;
    [SerializeField]
    private float maxYPos = 2f;
    private float spawnYPos;
    [SerializeField]
    private float spawnXPos = 7f;
    private int currentObstacle = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {

        timer = 0f;
        obstacle = new GameObject[amountToPool];

        for (int i = 0; i < amountToPool; i++)
        {
            obstacle[i] = (GameObject)Instantiate(obstaclePrefab, objPoolPos, Quaternion.identity);
            //obstacle[i].SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        timer += Time.deltaTime;
        if (timer >= spawnRate && UIManager.Instance.gameOver == false && UIManager.Instance.isGameStarted == true)
        {
            timer = 0;
            spawnYPos = Random.Range(minYPos, maxYPos);
            obstacle[currentObstacle].transform.position = new Vector2(spawnXPos, spawnYPos);
            currentObstacle++;
            if (currentObstacle >= amountToPool)
            {
                currentObstacle = 0;
            }
        }
    }
}
