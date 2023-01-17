using UnityEngine;

public class NodeInventory : MonoBehaviour
{
    public Habitat habitat;

    [SerializeField]
    private GameObject currentBuilding;
    public GameObject CurrentBuilding
    {
        get { return currentBuilding; }
        set { currentBuilding = value; }
    }

    public Vector3 buildPositionOffset;

    private void Update()
    {
        //if the current building is destroyed, set current building to null to avoid errors
        if(currentBuilding == null)
        {
            currentBuilding = null;
        }
        
    } //update

    public void BuildBuildingOnNode(GameObject _building)
    {
        GameObject building = (GameObject)Instantiate(_building, transform.position + buildPositionOffset, transform.rotation);
        currentBuilding = building;

    } //build building on node

} //class
