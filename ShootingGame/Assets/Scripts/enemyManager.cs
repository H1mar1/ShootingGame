using Cysharp.Threading.Tasks;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [SerializeField,Header("敵のプレハブの設定")]
    private GameObject enemyPrefab;
    [SerializeField,Header("敵のスポーン間隔")]
    private float spwenInterval;

    private void Start()
    {
        enemySpan().Forget();
    }

    async UniTask enemySpan()
    {
        while (true)
        {
            SpawnEnemy();
            await UniTask.Delay((int)(spwenInterval * 1000));
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
