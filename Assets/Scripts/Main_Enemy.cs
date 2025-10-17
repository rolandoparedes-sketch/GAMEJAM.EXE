using UnityEngine;

public class Main_Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 100;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected GameObject player;
    [SerializeField] protected float Vision;
    [SerializeField] protected float AttackRange;
    [SerializeField] protected float range;
}
