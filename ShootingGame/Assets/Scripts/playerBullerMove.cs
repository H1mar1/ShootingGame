using UnityEngine;

public class playerBullerMove : MonoBehaviour
{
    [SerializeField, Header("’e‚ÌƒXƒs[ƒh")]
    private float playerBullerSpead;

    private float playerBullerBreakY = 5.6f;
    private void Update()
    {
        //transform.Translate(0, playerBullerSpead, 0);
        transform.Translate(Vector3.up * playerBullerSpead * Time.deltaTime);
        //ˆê’è‚ÌˆÊ’u‚æ‚èã‚É’e‚ªs‚Á‚½‚ç
        if (transform.position.y> playerBullerBreakY)
        {
            Destroy(gameObject);//’e‚ð”j‰ó‚·‚é
        }
    }
}
