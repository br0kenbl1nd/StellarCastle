using UnityEngine;

public class SummonAttackUnit : MonoBehaviour
{
    public PlayerStats playerStats;

    [Header("Dragon")]
    [SerializeField]
    private GameObject dragon;
    [SerializeField]
    private float dragonCost;

    [Header("Plague")]
    [SerializeField]
    private GameObject plague;
    [SerializeField]
    private float plagueCost;

    public string allyTag;

    private void Update()
    {
        //check for input before checking for army camp to reduce frame usage
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SelectDragon();
        }

        //input x is for plague
        if(Input.GetKeyDown(KeyCode.X))
        {
            SelectPlague();
        }

    } //update

    public void SelectDragon()
    {
        //check if there is an army camp in the board
        if (CheckForArmyCamp())
        {
            //if an army camp is available, check resources
            if (playerStats.Money >= dragonCost)
            {
                //if resources are available spawn dragon
                SpawnDragon();
                //reduce resources
                playerStats.Money -= dragonCost;
            }
            else
            {
                Debug.Log("no money");
            }
        }
        else
        {
            Debug.Log("No camp");
        }
    } //select dragon

    public void SelectPlague()
    {
        //check if there is an army camp in the board
        if (CheckForArmyCamp())
        {
            //if an army camp is available, check resources
            if (playerStats.Money >= plagueCost)
            {
                //if resources are available spawn dragon
                SpawnPlague();
                //reduce resources
                playerStats.Money -= plagueCost;
            }
            else
            {
                Debug.Log("no money");
            }
        }
        else
        {
            Debug.Log("No camp");
        }
    } //select plague

    bool CheckForArmyCamp()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag(allyTag);
        //initially set availablity to false
        bool campAvailable = false;

        foreach(GameObject building in buildings)
        {
            if(building.GetComponent<SpawnSoldier>() != null)
            {
                campAvailable = true;
            }
        }

        //if camp is found return true
        if(campAvailable == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    } // check for army camp

    void SpawnDragon()
    {
        Instantiate(dragon, transform.position, Quaternion.identity);
        
    } //spawn dragon

    void SpawnPlague()
    {
        Instantiate(plague, transform.position, Quaternion.identity);
    } //spawn plague


} //class
