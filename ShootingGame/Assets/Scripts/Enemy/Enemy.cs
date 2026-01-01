using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField, Header("落下スピード")]
    //private float downSpeed = 3f;

    [SerializeField, Header("削除Y座標")]
    private float destroyY = -6f;

    //[SerializeField, Header("敵のポイント")]
    //private float enemyPoint;

    [SerializeField, Header("敵のデータベース参照")]
    private EnemyDataBase enemyDataBase;

    // Poolに戻す処理
    private Action _releaseAction;

    private bool isReleased = false;

    private float currentHP;

    // Poolから初期化される
    public void Initialize(Action releaseAction)
    {
        isReleased = false;
        _releaseAction = releaseAction;

        currentHP = enemyDataBase.maxHP;
    }

    private void Update()
    {
        if (isReleased) return;

        transform.position += Vector3.down * enemyDataBase.moveSpeed * Time.deltaTime;

        if (transform.position.y < destroyY)
        {
            // _releaseAction?.Invoke();
            Release();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Debug.Log("弾が当たりました！");
            Release();
            GameManager.Instance.AddScore(enemyDataBase.enemyPoint);

            //_releaseAction?.Invoke();
           
        }
    }

    private void Release()
    {
        if (isReleased) return;
        isReleased = true;

        if (_releaseAction != null)
        {
            _releaseAction.Invoke();
        }
        else
        {
            Debug.LogWarning("Release called but _releaseAction is null");
            gameObject.SetActive(false); // 安全策として非アクティブ化
        }
    }
}
