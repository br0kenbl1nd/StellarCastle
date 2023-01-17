using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    private float startMoney;

    private float money;
    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    private NodeInventory currentNode;
    public NodeInventory CurrentNode
    {
        get { return currentNode; }
        set { currentNode = value; }
    }

    private void Awake()
    {
        money = startMoney;
        
    } //start

} //class
