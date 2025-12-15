using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの設定")]
    private GameObject playerObj;
    [SerializeField, Header("敵のプレハブの設定")]
    private GameObject enemyPrefab;

    public async UniTask OnPlayerHitEnemy()
    {
        Debug.Log("プレイヤーに敵が当たりました");

        await UniTask.Delay(500);

        Debug.Log("ゲームオーバー");
    }
}
