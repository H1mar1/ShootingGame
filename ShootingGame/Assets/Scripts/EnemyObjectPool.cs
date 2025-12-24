using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    //シングルトン
    // どこからでも EnemyObjectPool.Instance でアクセスできるようにする
    public static EnemyObjectPool Instance;

    [SerializeField,Header("敵のプレハブを設定")]
    private Enemy enemyPrefab;

    // Enemy を生成・管理・再利用するためのプール
    private ObjectPool<Enemy> enemyPool;

    private void Awake()
    {
        // シングルトンの設定
        Instance = this;

        // Enemy 用の ObjectPool を作成
        enemyPool = new ObjectPool<Enemy>(
            CreateEnemy,     // プールに在庫が無いとき、新しく Enemy を生成する
            OnGetEnemy,      // プールから Enemy を取り出したときの処理（出現時）
            OnReleaseEnemy,  // Enemy をプールに返したときの処理（退場時）
            OnDestroyEnemy,  // プールから完全に削除するときの処理
            false,           // collectionCheck（通常は false でOK）
            10,              // defaultCapacity：最初に作っておく Enemy の数
            10               // maxSize：プールで管理できる最大数
        );
    }

    // Create（足りない時に新しく作る）
    private Enemy CreateEnemy()
    {
        // Enemy プレハブを生成し、Pool の子オブジェクトにする
        return Instantiate(enemyPrefab, transform);
    }

    // Get（使う時・出現時）
    private void OnGetEnemy(Enemy enemy)
    {
        // 出現位置をランダムに設定（画面上部）
        enemy.transform.position = new Vector3(
            Random.Range(-2.5f, 2.5f),
            6f,
            0
        );

        // Enemy に「プールへ戻る方法」を教える
        // Enemy 側で Release() が呼ばれると、この処理が実行される
        enemy.Initialize(() => enemyPool.Release(enemy));

        // Enemy を表示（使用開始）
        enemy.gameObject.SetActive(true);
    }

    // Release（返す時・退場時）
    private void OnReleaseEnemy(Enemy enemy)
    {
        // Enemy を非表示にして再利用可能な状態にする
        enemy.gameObject.SetActive(false);
    }

    // Destroy（完全に消す時）
    private void OnDestroyEnemy(Enemy enemy)
    {
        // プールの最大数超過や Clear() 時に完全削除される
        Destroy(enemy.gameObject);
    }

    // 外部から Enemy を取得するための関数
    public Enemy GetEnemy()
    {
        // プールから Enemy を1体取得する
        // 在庫がなければ CreateEnemy が呼ばれる
        return enemyPool.Get();
    }
}
