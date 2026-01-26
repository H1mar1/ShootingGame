using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの設定")]
    private GameObject playerObj;
    [SerializeField, Header("得点を表示するテキストの設定")]
    private TextMeshProUGUI scoreText;
    [SerializeField, Header("MaxHP1")]
    private GameObject maxHP1;
    [SerializeField, Header("MaxHP2")]
    private GameObject maxHP2;
    [SerializeField, Header("MaxHP3")]
    private GameObject maxHP3;
    [SerializeField, Header("HalfHP1")]
    private GameObject halfHP1;
    [SerializeField, Header("HalfHP2")]
    private GameObject halfHP2;
    [SerializeField, Header("HalfHP3")]
    private GameObject halfHP3;
    [SerializeField, Header("NullHP1")]
    private GameObject nullHP1;
    [SerializeField, Header("NullHP2")]
    private GameObject nullHP2;
    [SerializeField, Header("NullHP3")]
    private GameObject nullHP3;


    public static GameManager Instance;

    public float score = 0;//最初のスコア設定
    private int hpCounts = 0;//最初のHP設定

    private void Start()
    {
        maxHP1.SetActive(true);
        maxHP2.SetActive(true);
        maxHP3.SetActive(true);
        halfHP1.SetActive(false);
        halfHP2.SetActive(false);
        halfHP3.SetActive(false);
        nullHP1.SetActive(false);   
        nullHP2.SetActive(false);
        nullHP3.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }

    //敵を倒したとき
    public void AddScore(float point)
    {
        score += point;
        Debug.Log("スコア:" + score);

        scoreText.text = "Score:" + score.ToString();
    }

    public async UniTask OnPlayerHitEnemy()
    {
        Debug.Log("プレイヤーに敵が当たりました");

        await UniTask.Delay(500);

        hpCounts++;
        hPCounter();

       
       // Debug.Log("ゲームオーバー");
    }

    private void hPCounter()
    {
        switch (hpCounts)
        {
            case 1:
                maxHP1.SetActive(false);
                halfHP1.SetActive(true);
                break;

            case 2:
                halfHP1.SetActive(false);
                nullHP1.SetActive(true);
                break;

            case 3:
                maxHP2.SetActive(false);
                halfHP2.SetActive(true);
                break;

            case 4:
                halfHP2.SetActive(false);
                nullHP2.SetActive(true);
                break;

            case 5:
                maxHP3.SetActive(false);
                halfHP3.SetActive(true);
                break;

            case 6:
                halfHP3.SetActive(false);
                nullHP3.SetActive(true);
                Debug.Log("HPが0になりました！ゲームオーバー");
                break;
        }
    }

}
