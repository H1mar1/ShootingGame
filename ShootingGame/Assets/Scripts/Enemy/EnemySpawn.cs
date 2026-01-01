using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField, Header("“G‚Ì¶¬‚³‚ê‚éŠÔŠu")]
    private float spawnInterval = 1.5f;
    [SerializeField,Header("¶¬‚³‚ê‚é”")]
    private int maxEnemyCount = 5;



    private float timer;

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            if (EnemyObjectPool.Instance.ActiveEnemyCount < maxEnemyCount)
            {
                EnemyObjectPool.Instance.GetPoolEnemy();
            }

            timer = 0f;
        }
    }
}
