using UnityEngine;

public class SpreadHabitat : MonoBehaviour
{
    //habitats for good and bad factions
    [SerializeField]
    private HabitatBluePrint goodHabitat;
    [SerializeField]
    private HabitatBluePrint badHabitat;

    //habitat for the specific units based on the tag
    private HabitatBluePrint habitat;

    [SerializeField]
    private float habitatSpreadRange;

    public string nodeTag = "Node";
    private string friendlyBuildingTag;

    private void Start()
    {
        if(gameObject.CompareTag("Good"))
        {
            habitat = goodHabitat;
        }
        else
        {
            habitat = badHabitat;
        }

        Spread();
        friendlyBuildingTag = gameObject.tag;
        InvokeRepeating("Spread", 0f, 2f);
     
    } //start

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, habitatSpreadRange);
        Gizmos.color = Color.red;
    }

    public void Spread()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag(nodeTag);
        foreach (GameObject node in nodes)
        {
            float distanceToNode = Vector3.Distance(transform.position, node.transform.position);
            if (distanceToNode <= habitatSpreadRange)
            {
                Habitat _habitat = node.GetComponent<Habitat>();
                _habitat.SetHabitat(habitat);
            }
        }
    } //spread

    void DeSpread()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag(nodeTag);
        foreach (GameObject node in nodes)
        {
            float distanceToNode = Vector3.Distance(transform.position, node.transform.position);
            if (distanceToNode <= habitatSpreadRange)
            {
                Habitat _habitat = node.GetComponent<Habitat>();
                _habitat.RefreshHabitat();
            }
        }
    } //de spread

    //respread habitat from all allied buildings
    void ReSpread()
    {      
        GameObject[] buildings = GameObject.FindGameObjectsWithTag(friendlyBuildingTag);
        foreach(GameObject building in buildings)
        {
            SpreadHabitat spreadHabitat = building.GetComponent<SpreadHabitat>();
            if(spreadHabitat != null)
            {
                spreadHabitat.Spread();
            }

        }
    } //respread

    //de spread creep on destroy
    private void OnDestroy()
    {
        DeSpread();
        ReSpread();
    }

} //class
