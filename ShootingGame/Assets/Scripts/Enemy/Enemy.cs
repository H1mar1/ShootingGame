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

    //HPの変数
    private float currentHP;

    public event Action OnReleased;

    // Poolから初期化される
    public void Initialize(Action releaseAction)
    {
        isReleased = false;
        _releaseAction = releaseAction;

        //最初のMaxHPの設定
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
        if (isReleased) return;

        if (other.CompareTag("PlayerBullet"))
        {

            TakeDamage(1);//1発分のダメージ
           
        }
    }

    private void Release()
    {
        if (isReleased) return;
        isReleased = true;

        OnReleased?.Invoke();
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

    private void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Debug.Log("弾が当たりました！");
            GameManager.Instance.AddScore(enemyDataBase.enemyPoint);
            Release();
        }
        else
        {
            Debug.Log("敵はまだ生きています！残りHP：" + currentHP);
        }

    }
}
