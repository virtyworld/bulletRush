using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static LevelScript Instance;

    [Header("Level Enemy")] public int TotalEnemies;
    public int EnemyInScene;
    [SerializeField] private Transform enemyParent;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TotalEnemies = enemyParent.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyInScene = enemyParent.childCount;
    }
}