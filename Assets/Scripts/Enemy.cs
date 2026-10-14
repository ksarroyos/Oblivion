using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float attackDistance = 1.5f;
    public float attackCooldown = 1f;

    private Animator animator;
    private float nextAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackDistance)
        {
            // Caminar hacia el jugador
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );

            animator.SetBool("Walking", true);

            // Girar sprite
            if (player.position.x > transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool("Walking", false);

            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

}
