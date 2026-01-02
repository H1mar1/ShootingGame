using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField,Header("EnemyPool1ÇÃê›íË")]
    private EnemyObjectPool1 enemyObjectPool1;
    [SerializeField, Header("EnemyPool2ÇÃê›íË")]
    private EnemyObjectPool2 enemyObjectPool2;
    [SerializeField, Header("EnemyPool3ÇÃê›íË")]
    private EnemyObjectPool3 enemyObjectPool3;

    [SerializeField,Header("ìGÇÃÉXÉ|Å[Éìä‘äu")]
    private float spwenInterval;
    

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
        //    float x = Random.Range(spawnRangeX.x, spawnRangeX.y);
        //    //Vector3 spawnPosition = new Vector3(x, spawnY, 0.0f);


        //    /// ObjectPool Ç©ÇÁ Enemy ÇéÊìæ
        //Enemy enemy = EnemyObjectPool1.Instance.GetPoolEnemy();
        //    enemy.transform.position = spawnPosition;
        //    enemy.transform.rotation = Quaternion.identity;

        float x = Random.Range(spawnRangeX.x, spawnRangeX.y);

        Enemy enemy1 = enemyObjectPool1.GetPoolEnemy();
        enemy1.transform.position = new Vector3(x, spawnY, 0f);
        enemy1.transform.rotation = Quaternion.identity;


        Enemy enemy2 = enemyObjectPool2.GetPoolEnemy();
        enemy2.transform.position = new Vector3(x, spawnY, 0f);
        enemy2.transform.rotation = Quaternion.identity;

        Enemy enemy3 = enemyObjectPool3.GetPoolEnemy();
        enemy3.transform.position = new Vector3(x, spawnY, 0f);
        enemy3.transform.rotation = Quaternion.identity;

    }

}
