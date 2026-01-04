using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Header("EnemyPool1の設定")]
    private EnemyObjectPool1 enemyObjectPool1;
    [SerializeField, Header("EnemyPool2の設定")]
    private EnemyObjectPool2 enemyObjectPool2;
    [SerializeField, Header("EnemyPool3の設定")]
    private EnemyObjectPool3 enemyObjectPool3;

    [SerializeField, Header("敵のスポーン間隔")]
    private float spwenInterval;

    [SerializeField, Header("生成される数")]
    private int maxEnemyCount = 5;

    private Vector2 spawnRangeX = new Vector2(-2.48f, 2.48f);
    private float spawnY = 5.6f;

    private void Start()
    {
        enemySpanLoop().Forget();
    }

    async UniTask enemySpanLoop()
    {
        while (true)
        {
            SpawnEnemy();
            await UniTask.Delay((int)(spwenInterval * 1000));
        }
    }

    private void SpawnEnemy()
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
            enemy = enemyObjectPool1.GetPoolEnemy();
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
        else
        {
            if (rand < 60)
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
            enemy.transform.rotation = Quaternion.identity;
        }
    }
}
