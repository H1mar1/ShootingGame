using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataBase", menuName = "Enemy/EnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
    [SerializeField, Header("“G‚ÌHP")]
    public float maxHP;
    [SerializeField,Header("“G‚ÌƒXƒs[ƒh")]
    public float moveSpeed;
    [SerializeField,Header("“G‚ÌUŒ‚—Í")]
    public float attackPower;
    [SerializeField, Header("“G‚Ìƒ|ƒCƒ“ƒg")]
    public float enemyPoint;
}
