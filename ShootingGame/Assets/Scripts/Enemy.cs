using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("落下スピード")]
    private float downSpeed = 3f;

    [SerializeField, Header("削除Y座標")]
    private float destroyY = -6f;

    private void Update()
    {
        // 下に落ちる
        transform.position += Vector3.down * downSpeed * Time.deltaTime;

        // 画面外に出たら消す
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
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
