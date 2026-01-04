using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField, Header("Poolの設定")]
    public EnemyObjectPool1 enemyObjectPool1;
    public EnemyObjectPool2 enemyObjectPool2;
    public EnemyObjectPool3 enemyObjectPool3;

    [SerializeField, Header("敵の生成される間隔")]
    private float spawnInterval = 1.5f;
    [SerializeField, Header("生成される数")]
    private int maxEnemyCount = 5;

    private Vector2 spawnRangeX = new Vector2(-2.5f, 2.5f);
    private float spawnY = 6f;

    private void Start()
    {
        SpawnLoop().Forget();
    }

    private async UniTask SpawnLoop()
    {
        while (true)
        {
            SpawnRandomEnemy();
            await UniTask.Delay((int)(spawnInterval * 1000));
        }
    }

    private void SpawnRandomEnemy()
    {
        //敵の合計をチェック
        int totalActive =
            enemyObjectPool1.ActionCount +
            enemyObjectPool2.ActionCount +
            enemyObjectPool3.ActionCount;

        if (totalActive + 1 > maxEnemyCount) return;

        float currentScore = GameManager.Instance.score;

        int rand = Random.Range(0, 100);
        Enemy enemy = null;

        //スコアによる敵の排出率制御
        if (currentScore < 20)
        {
            if (rand < 100)
            {
                enemy = enemyObjectPool1.GetPoolEnemy();
            }
        }
        else if (currentScore < 50)
        {
            if (rand < 70)
            {
                enemy = enemyObjectPool1.GetPoolEnemy();
            }
            else
            {
                enemy = enemyObjectPool2.GetPoolEnemy();
            }
        }
        else if (currentScore < 100)
        {
            if (rand < 50)
            {
                enemy = enemyObjectPool1.GetPoolEnemy();
            }
            else
            {
                enemy = enemyObjectPool2.GetPoolEnemy();
            }
        }
        else if (currentScore < 120)
        {
            if (rand < 40)
            {
                enemy = enemyObjectPool1.GetPoolEnemy();
            }
            else if (rand < 80)
            {
                enemy = enemyObjectPool2.GetPoolEnemy();
            }
            else
            {
                enemy = enemyObjectPool3.GetPoolEnemy();
            }
        }
        else
        {
            if (rand < 20)
            {
                enemy = enemyObjectPool1.GetPoolEnemy();
            }
            else if (rand < 60)
            {
                enemy = enemyObjectPool2.GetPoolEnemy();
            }
            else
            {
                enemy = enemyObjectPool3.GetPoolEnemy();
            }
        }

        if (enemy != null)
        {
            float x = Random.Range(spawnRangeX.x, spawnRangeX.y);
            enemy.transform.position = new Vector3(x, spawnY, 0f);

            //イベントの多重登録防止
            enemy.OnReleased -= OnEnemyReleased;
            enemy.OnReleased += OnEnemyReleased;

            Debug.Log("現在のスコア：" + currentScore);
        }
    }

    private void OnEnemyReleased()
    {
        //Pool側で管理しているため、ここでは処理しない
    }
}
