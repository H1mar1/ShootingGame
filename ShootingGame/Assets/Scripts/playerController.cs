using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの移動スピード")]
    private float playerSpeed;
    [SerializeField, Header("GameManagerの設定")]
    private GameManager gameManager; 


    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("右のボタンが押されました");
            transform.position += playerSpeed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("左のボタンが押されました");
            transform.position -= playerSpeed * transform.right * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.OnPlayerHitEnemy().Forget();
        }
    }

}
