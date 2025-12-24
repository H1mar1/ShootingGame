using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField, Header("弾のスピード")]
    private float playerBullerSpead;

    [SerializeField, Header("削除Y座標")]
    private float destroyY = 5.6f;

    //Poolに戻るための処理
    private Action _releaseAction;

    //Poolから渡される初期値
    public void Initialize(Action releaseAction)
    {
        _releaseAction = releaseAction;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * playerBullerSpead * Time.deltaTime);
        //一定の位置より上に弾が行ったら
        if (transform.position.y > destroyY)
        {
            Release();
        }
    }

    private void Release()
    {
        gameObject.SetActive(false);
        _releaseAction?.Invoke();
    }
}
