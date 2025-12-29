using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [SerializeField,Header("敵のプレハブの設定")]
    private GameObject enemyPrefab;
    [SerializeField,Header("敵のスポーン間隔")]
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
        float x = Random.Range(spawnRangeX.x, spawnRangeX.y);
        Vector3 spawnPosition = new Vector3(x, spawnY, 0.0f);


        /// ObjectPool から Enemy を取得
    Enemy enemy = EnemyObjectPool.Instance.GetPoolEnemy();
        enemy.transform.position = spawnPosition;
        enemy.transform.rotation = Quaternion.identity;
    }

}
