using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [SerializeField,Header("敵のプレハブの設定")]
    private GameObject enemyPrefab;
    [SerializeField,Header("敵のスポーン間隔")]
    private float spwenInterval;
    [SerializeField, Header("敵の落下スピード")]
    private float enemyDownSpeed;

    private Vector2 spawnRangeX = new Vector2(-2.48f, 2.48f);
    private float spawnY = 5.6f;

    private async void Start()
    {
        enemySpan().Forget();
        await UniTask.Delay(1000);
        enemyDown();
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
        float x = Random.Range(spawnRangeX.x, spawnRangeX.y);
        Vector3 spawnPosition = new Vector3(x, spawnY, 0.0f);

        Debug.Log("あはははは");

        Instantiate(enemyPrefab, spawnPosition , Quaternion.identity);
    }

    private async void enemyDown()
    {
        while (true)
        {
            // Enemy タグが付いたオブジェクトを全て取得
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                if (enemy == null) continue; // null のときだけスキップ

                enemy.transform.position +=
                    Vector3.down * enemyDownSpeed * Time.deltaTime;
            }

            //1フレーム
            await UniTask.Yield();
        }
    }

}
