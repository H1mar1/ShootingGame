using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの設定")]
    private GameObject playerObj;
    [SerializeField, Header("得点を表示するテキストの設定")]
    private TextMeshProUGUI scoreText;
    
    public static GameManager Instance;

    private float score = 0;//最初のスコア設定

    private void Awake()
    {
        Instance= this;
    }

    //敵を倒したとき
    public void AddScore(float point)
    {
        score += point;
        Debug.Log("スコア:" + score);
       if(score != null)
        {
            scoreText.text = "Score:" + score.ToString();
        }
    }


    public async UniTask OnPlayerHitEnemy()
    {
        Debug.Log("プレイヤーに敵が当たりました");

        await UniTask.Delay(500);

        Debug.Log("ゲームオーバー");
    }
}
