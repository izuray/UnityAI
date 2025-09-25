public class EnemyController
{


    public GameObject EnemyPrefabs;
    public int Score = 0;

    public string name = "dinhbv";

    public float test = 10.5f;


    void Start()
    {
        EnemyPrefabs.SetActive(false);
        Debug.Log("test");
    }
    void Update()
    {

    }


}