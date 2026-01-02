using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField,Header("PoolÇÃê›íË")]
    public EnemyObjectPool1 enemyObjectPool1;
    public EnemyObjectPool2 enemyObjectPool2;
    public EnemyObjectPool3 enemyObjectPool3;

    [SerializeField, Header("ìGÇÃê∂ê¨Ç≥ÇÍÇÈä‘äu")]
    private float spawnInterval = 1.5f;
    [SerializeField,Header("ê∂ê¨Ç≥ÇÍÇÈêî")]
    private int maxEnemyCount = 5;

    private Vector2 spawnRangeX = new Vector2(-2.5f, 2.5f);
    private float spawnY = 6f;



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
            int totalActive = enemyObjectPool1.ActionCount + enemyObjectPool2.ActionCount + enemyObjectPool3.ActionCount;

            if (totalActive < maxEnemyCount)
            {
                SpawnRandomEnemy();
            }

            await UniTask.Delay((int)spawnInterval * 1000);
        }
    }


   private void SpawnRandomEnemy()
    {
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
        }
    }
    //private void SpawnEnemy()
    //{
    //    timer += Time.deltaTime;

    //    if (timer >= spawnInterval)
    //    {
    //        if (EnemyObjectPool.Instance.ActiveEnemyCount < maxEnemyCount)
    //        {
    //            EnemyObjectPool.Instance.GetPoolEnemy();
    //        }

    //        timer = 0f;
    //    }
}
