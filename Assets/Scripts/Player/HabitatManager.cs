using UnityEngine;
using System.Collections.Generic;

public class HabitatManager : MonoBehaviour
{
    [SerializeField]
    private Transform baseBuilding;

    [SerializeField]
    private float spreadRange;

    [SerializeField]
    private HabitatBluePrint habitat;

    private List<Transform> buildings= new List<Transform>();

    public string nodeTag = "Node";

    private void Start()
    {
        buildings.Add(baseBuilding);
        SpreadHabitat();
    } //start

    public void BuildingBuilt(Transform _building)
    {
        //a new building is built
        buildings.Add(_building);

        //spread habitat with the new list of buildings
        SpreadHabitat();

    } //building built

    public void BuildingDestroyed(Transform _building)
    {
        //remove the destroyed building
        buildings.Remove(_building);

        //spread habitat with the new list of buildings
        SpreadHabitat();

    } //building destroyed

    void SpreadHabitat()
    {
        
        for(int i = 0; i < buildings.Count; i++)
        {           
            GameObject[] nodes = GameObject.FindGameObjectsWithTag(nodeTag);
            foreach (GameObject node in nodes)
            {
                float distanceToNode = Vector3.Distance(buildings[i].transform.position, node.transform.position);
                if (distanceToNode <= spreadRange)
                {
                    Habitat _habitat = node.GetComponent<Habitat>();
                    _habitat.SetHabitat(habitat);
                    Debug.Log(buildings[i]);
                }
            }
        }
    } //spread habitat

} //class
