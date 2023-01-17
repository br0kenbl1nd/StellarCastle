using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform graphics;
    public PlayerStats playerStats;

    public string habitatRqd = "MeteorGood";

    public CharacterController controller;

    public float speed = 12f;

    public float rotationSpeed = 720f;

    [Header("Disable list when going off habitat")]
    public SpellRapidFire rapidFire;
    public SummonAttackUnit summonAttackUnit;

    Vector3 move;
    public Vector3 Move
    {
        get { return move; }
        private set { move = value; }
    }

    private void Update()
    {
        //get input on x axis
        float x = Input.GetAxis("Horizontal");
        //get input on z axis
        float z = Input.GetAxis("Vertical");

        //set the movement to the vector
        move = transform.right * x + transform.forward * z;

        //impliment movement
        controller.Move(move * speed * Time.deltaTime);

        if(move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(-move, Vector3.up);
            graphics.transform.rotation = Quaternion.RotateTowards(graphics.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //keep player on the ground
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        
        //detect the movement off habitat
        DisableAbilitiesOffHabitat();
        
    } //update

    private void DisableAbilitiesOffHabitat()
    {
        //for the characters in the level phase some of these components maybe null

        if (playerStats.CurrentNode.habitat.CurrentHabitat.name != habitatRqd)
        {
            if (summonAttackUnit != null)
            {
                //disabling the player powerups
                if (summonAttackUnit.enabled == true)
                {
                    summonAttackUnit.enabled = false;
                }
            }

            if (rapidFire != null)
            {
                if (rapidFire.enabled == true)
                {
                    rapidFire.enabled = false;
                }
            }

        }
        else
        {
            if (summonAttackUnit != null)
            {
                //enable the player powerups when the player is in the habitat
                if (summonAttackUnit.enabled == false)
                {
                    summonAttackUnit.enabled = true;
                }
            }

            if (rapidFire != null)
            {
                if (rapidFire.enabled == false)
                {
                    rapidFire.enabled = true;
                }
            }
        }
    } //disable abilities off habitat

} //class
