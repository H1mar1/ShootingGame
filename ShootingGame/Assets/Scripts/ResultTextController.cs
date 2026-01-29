using UnityEngine;
using TMPro;

public class ResultTextController : MonoBehaviour
{
    [SerializeField, Header("ResultText")]
    private TextMeshProUGUI resultText;

    private void Start()
    {
        resultText.text = "Score : " + GameManager.Instance.score.ToString();
    }
}
