using UnityEngine;
using UnityEngine.Pool;

public class PlayerBullerPool : MonoBehaviour
{
    [SerializeField, Header("敵の設定")]
    private Enemy _enemyPrefab;//オブジェクトプールで管理するオブジェクト

    private ObjectPool<Enemy> _enemyPool;//オブジェクトプール本体
    //アクセスしやすいようにシングルトン化
    private static PlayerBullerPool _instance;
    public static PlayerBullerPool Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PlayerBullerPool>();

            }
            return _instance;
        }
    }

    private void Start()
    {
        //_enemyPool = new ObjectPool<Enemy>(
        //    CreateEnemy,
        //    OnGetEnemy,
        //    actionOnReleaseEnemy,
        //    actionOnDestroyEnemy,
        //    false,
        //    10,
        //    30
            );
    }

    private Enemy CreateEnemy()
    {
        return Instantiate(_enemyPrefab, transform);
    }

    private void OnGetEnemy(Enemy enemy)
    {
        enemy.transform.position = new Vector3(0, 5, 0);
        enemy.gameObject.SetActive(true);
    }
        
    private void OnReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }
    
    private void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

}
