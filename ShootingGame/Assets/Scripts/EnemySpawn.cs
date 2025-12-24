using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField, Header("“G‚Ì¶¬‚³‚ê‚éŠÔŠu")]
    private float spawnInterval = 1.5f;


    private float timer;

    private void Update()
    {
        spawnenemy();
    }

    private void spawnenemy()
    {
        timer += Time.deltaTime;

        if(timer>= spawnInterval)
        {
            EnemyObjectPool.Instance.GetEnemy();
            timer = 0f;
        }
    }
}
