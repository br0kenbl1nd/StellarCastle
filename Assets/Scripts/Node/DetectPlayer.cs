using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Renderer rend;

    public string PlayerTag = "Player";

    public Material playerOverNodeMat;

    private GameObject player;
    private PlayerStats playerStats;

    public NodeInventory nodeInventory;
    public Habitat habitat;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(PlayerTag);
        playerStats = player.GetComponent<PlayerStats>();
        
    } //start

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(PlayerTag))
        {
            if (nodeInventory.CurrentBuilding == null)
            {
                //if player is over the node, change the material of the node
                rend.material = playerOverNodeMat;
                playerStats.CurrentNode = nodeInventory;
            }
        }
    }

} //class
