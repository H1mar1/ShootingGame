using UnityEngine;
using UnityEngine.Pool;

public class PlayerBullerPool : MonoBehaviour
{
    //シングルトン
    public static PlayerBullerPool Instance;

    [SerializeField, Header("プレイヤーの出す弾の設定")]
    private PlayerBullet playerBulletPrefab;
    [SerializeField, Header("プレイヤーの設定")]
    private GameObject playerObj;

    //プール
    private ObjectPool<PlayerBullet> playerBulletPool;

    private void Awake()
    {
        //シングルトンの設定
        Instance = this;

        //ObjectPoolの設定
        playerBulletPool = new ObjectPool<PlayerBullet>(
            CreatePlayerBullet,
            OnGetPlayerBullet,
            OnReleasePlayerBullet,
            OnDestroyPlayerBullet,
            false,
            50,
            100
        );
    }

    //Create(足りない時に新しく作る)
    private PlayerBullet CreatePlayerBullet()
    {
        return Instantiate(playerBulletPrefab, transform);
    }

    //Get(使う時・出現時）
    public void OnGetPlayerBullet(PlayerBullet playerBullet)
    {
        //プレイヤーの位置を参照
        Vector3 spawnPosition = playerObj.transform.position + Vector3.up * 0.5f;
        spawnPosition.z = 0f;
        playerBullet.transform.position = spawnPosition;
        playerBullet.transform.rotation = Quaternion.identity;

        // Pool に戻る方法を弾にセット
        playerBullet.Initialize(() => playerBulletPool.Release(playerBullet));

        playerBullet.gameObject.SetActive(true);
    }

    //Release(返すとき・退場時)
    private void OnReleasePlayerBullet(PlayerBullet playerBullet)
    {
        playerBullet.gameObject.SetActive(false);
    }

    //Destroy(完全に消す時)
    private void OnDestroyPlayerBullet(PlayerBullet playerBullet)
    {
        Destroy(playerBullet.gameObject);
    }

    //外部からPlayerBulletを取得して発射
    public void ShootBullet()
    {
        playerBulletPool.Get();
    }
}
