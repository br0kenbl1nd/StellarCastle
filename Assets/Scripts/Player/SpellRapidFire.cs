using UnityEngine;

public class SpellRapidFire : MonoBehaviour
{

    public string allyTag = "Good";

    [SerializeField]
    private float cooldown;
    public float Cooldown
    {
        get { return cooldown; }
    }

    private float count;
    public float Count
    {
        get { return count; }
    }

    [SerializeField]
    private float duration;

    [SerializeField]
    private float rapidIncreaseAmount;

    private void Start()
    {
        count = 0f;
        
    } //start

    private void Update()
    {
        if(count <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RapidFire();
                count = cooldown;
            }
        }
        count -= Time.deltaTime;

    } //update

    public void RapidFire()
    {
        //Find all the allied units and buildings
        GameObject[] units = GameObject.FindGameObjectsWithTag(allyTag);
        //loop through them
        foreach(GameObject unit in units)
        {
            //get their unitstats component
            UnitStats unitStats = unit.GetComponent<UnitStats>();
            
            if(unitStats != null)
            {
                //set the attack speed to rapid amount
                unitStats.AttackSpeed += rapidIncreaseAmount;
                //set the movement speed to rapid amount
                unitStats.Speed += rapidIncreaseAmount;
            }
        }
        //invoke the exhaust function after duration seconds
        Invoke("ExhaustRapidFire", duration);

    } //rapid fire

    void ExhaustRapidFire()
    {
        //Find all the allied units and buildings
        GameObject[] units = GameObject.FindGameObjectsWithTag(allyTag);
        //loop through them
        foreach (GameObject unit in units)
        {
            //get their unitstats component
            UnitStats unitStats = unit.GetComponent<UnitStats>();

            if (unitStats != null)
            {
                //set the attack speed to original amount
                unitStats.AttackSpeed = unitStats.StartAttackSpeed;
                //set the movement speed to original amount
                unitStats.Speed -= unitStats.StartSpeed;
            }
        }

    } //exhaust rapid fire

} //class
