using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public Animator animator;

    private void Update()
    {
        //whenever the movement vector in player movement script is not zero we animate the player
        if(playerMovement.Move != Vector3.zero)
        {
            //set the isWalking as true
            animator.SetBool("isWalking", true);
        }
        else
        {
            //set the isWalking as false
            animator.SetBool("isWalking", false);
        }

    } //update


} //class
