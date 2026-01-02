using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField,Header("EnemyPoolÇÃê›íË")]
    private EnemyObjectPool1 enemyObjectPool1;


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

        Enemy enemy = enemyObjectPool1.GetPoolEnemy();

        float x = Random.Range(spawnRangeX.x, spawnRangeX.y);
        enemy.transform.position = new Vector3(x, spawnY, 0f);
        enemy.transform.rotation = Quaternion.identity;
    }

}
