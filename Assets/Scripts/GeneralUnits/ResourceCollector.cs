using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    private PlayerStats playerStats;

    public string PlayerTag = "Player";

    [SerializeField]
    private float rpm;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<PlayerStats>(); 
        
    } //start

    private void Update()
    {
        playerStats.Money += (rpm/60f) * Time.deltaTime;
        
    } //update

} //class
