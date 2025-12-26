using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.LookDev;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの設定")]
    private GameObject playerObj;
    
    public static GameManager Instance;

    private int score = 0;//最初のスコア設定

    private void Awake()
    {
        Instance= this;
    }

    //敵を倒したとき
    public void AddScore(int value)
    {
        score += value;
        Debug.Log("スコア:" + score);
    }


    public async UniTask OnPlayerHitEnemy()
    {
        Debug.Log("プレイヤーに敵が当たりました");

        await UniTask.Delay(500);

        Debug.Log("ゲームオーバー");
    }
}
