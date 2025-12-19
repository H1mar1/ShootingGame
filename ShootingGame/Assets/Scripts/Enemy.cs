using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("落下スピード")]
    private float downSpeed = 3f;

    [SerializeField, Header("削除Y座標")]
    private float destroyY = -6f;
    [SerializeField, Header("敵の得点")]
    private float enemyPoint;

    //Poolの戻るための処理
    private Action releaseAction;

    //Poolから渡される初期値
    public void Initialize(Action release)
    {
        releaseAction = release;
    }

   

    private void Update()
    {
        // 下に落ちる
        transform.position += Vector3.down * downSpeed * Time.deltaTime;

        // 画面外に出たら消す
        if (transform.position.y < destroyY)
        {
           // Release();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーに当たったら消える
        if (other.CompareTag("Player"))
        {
            Debug.Log("aaa");
            Destroy(gameObject);
          
        }
    }
}
