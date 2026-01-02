using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField,Header("Poolの設定")]
    public EnemyObjectPool1 enemyObjectPool1;
    public EnemyObjectPool2 enemyObjectPool2;
    public EnemyObjectPool3 enemyObjectPool3;

    [SerializeField, Header("敵の生成される間隔")]
    private float spawnInterval = 1.5f;
    [SerializeField,Header("生成される数")]
    private int maxEnemyCount = 5;

    private Vector2 spawnRangeX = new Vector2(-2.5f, 2.5f);
    private float spawnY = 6f;

    private int currentEnemyCount = 0;//現在の敵の数

    //private float timer;

    //private void Update()
    //{
    //    SpawnEnemy();
    //}

    private void Start()
    {
        SpawnLoop().Forget();
    }


    private async UniTask SpawnLoop()
    {
        while (true)
        {
            //現在のアクティブな敵の数の合計
            //int totalActive = enemyObjectPool1.ActionCount + enemyObjectPool2.ActionCount + enemyObjectPool3.ActionCount;

            //if (totalActive < maxEnemyCount)
            //{
            //    SpawnRandomEnemy();
            //}

            //await UniTask.Delay((int)spawnInterval * 1000);
            SpawnRandomEnemy(); 
            await UniTask.Delay((int)(spawnInterval * 1000));
        }
    }


   private void SpawnRandomEnemy()
    {
        //敵の合計をチェック
        int totalActive = enemyObjectPool1.ActionCount + enemyObjectPool2.ActionCount + enemyObjectPool3.ActionCount;
        if (totalActive + 1 > maxEnemyCount) return;

        int rand=Random.Range(0,3);
        Enemy enemy = null;

        switch (rand)
        {
            case 0:enemy=enemyObjectPool1.GetPoolEnemy(); break;
            case 1:enemy=enemyObjectPool2.GetPoolEnemy();break;
            case 2:enemy=enemyObjectPool3.GetPoolEnemy();break;
        }

        if(enemy != null)
        {
            float x = Random.Range(spawnRangeX.x, spawnRangeX.y);
            enemy.transform.position=new Vector3(x, spawnY, 0f);

            currentEnemyCount++;
            enemy.OnReleased += OnEnemyReleased;

            float currentScore = GameManager.Instance.score;
            Debug.Log("現在のスコア：" + currentScore);
        }
    }

    private void OnEnemyReleased()
    {
        currentEnemyCount--;
    }
}
