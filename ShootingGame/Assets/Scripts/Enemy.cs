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

    //Poolの戻るための処理
    private Action _releaseAction;

    private bool isReleased;

    //Poolから渡される初期値
    public void Initialize(Action releaseAction)
    {
        _releaseAction = releaseAction;
        isReleased = false;
    }

   

    private void Update()
    {
        // 下に落ちる
        transform.position += Vector3.down * downSpeed * Time.deltaTime;

        // 画面外に出たら消す
        if (transform.position.y < destroyY)
        {
            Release();
        }

    }

    private void Release()
    {

        if (isReleased) return;
        isReleased = true;
        gameObject.SetActive(false);
        _releaseAction?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isReleased) return;
        //弾に当たったら消える
        if (other.CompareTag("PlayerBullet"))
        {
          isReleased = true;

            Debug.Log("弾が当たりました！");
            GameManager.Instance.AddScore(enemyPoint);

            Release();
        }
    }
}
