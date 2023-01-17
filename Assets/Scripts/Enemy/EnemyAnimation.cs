using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    EnemyMovement enemyMovement;

    Animator enemyAnimator;

    MeleeAttack meleeAttack;
    RangedAttack rangedAttack;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimator = GetComponent<Animator>();
        meleeAttack = GetComponent<MeleeAttack>();
        rangedAttack = GetComponent<RangedAttack>();
        
    } //start

    private void Update()
    {
        if(enemyMovement.CanMove == true)
        {
            enemyAnimator.SetBool("isWalking", true);
        }
        else
        {
            enemyAnimator.SetBool("isWalking", false);
        }

        if (meleeAttack != null)
        {
            if (meleeAttack.CanAttack == true)
            {
                enemyAnimator.SetBool("isAttacking", true);
            }
            else
            {
                enemyAnimator.SetBool("isAttacking", false);
            }
        }
        
        if(rangedAttack != null)
        {
            if (rangedAttack.CanAttack == true)
            {
                enemyAnimator.SetBool("isAttacking", true);
            }
            else
            {
                enemyAnimator.SetBool("isAttacking", false);
            }
        }

    } //update


} //class
