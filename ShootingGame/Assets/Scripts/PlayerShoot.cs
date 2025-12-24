using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField, Header("弾のプレハブ設定")]
    private GameObject playerBuller;
    [SerializeField, Header("発射間隔")]
    private float shootInterval;

    private float shootTimer = 0f;

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Return) && shootTimer >= shootInterval)
        {
            bullerGeneration();
        }
    }

    private void bullerGeneration()
    {
        // Instantiate を使わず ObjectPool から取得
        PlayerBullerPool.instance.ShootBullet();
        shootTimer = 0f;//タイマーリセット
    }
}
