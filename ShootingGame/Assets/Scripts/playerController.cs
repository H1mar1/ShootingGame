using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの移動スピード")]
    private float playerSpeed;

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("右のボタンが押されました");
            transform.position += playerSpeed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("左のボタンが押されました");
            transform.position -= playerSpeed * transform.right * Time.deltaTime;
        }
    }

}
