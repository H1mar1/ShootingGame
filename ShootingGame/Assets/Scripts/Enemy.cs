using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("落下スピード")]
    private float downSpeed = 3f;

    [SerializeField, Header("削除Y座標")]
    private float destroyY = -6f;

    [SerializeField, Header("敵のポイント")]
    private float enemyPoint;

    // Poolに戻す処理
    private Action _releaseAction;

    // Poolから初期化される
    public void Initialize(Action releaseAction)
    {
        _releaseAction = releaseAction;
    }

    private void Update()
    {
        transform.position += Vector3.down * downSpeed * Time.deltaTime;

        if (transform.position.y < destroyY)
        {
            _releaseAction?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Debug.Log("弾が当たりました！");
            GameManager.Instance.AddScore(enemyPoint);

            _releaseAction?.Invoke();
        }
    }
}
