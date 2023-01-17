using UnityEngine;

public class Habitat : MonoBehaviour
{
    //the class is responsible for managing the habitat of the node
    //variable to keep track of current node
    [Header("Fill this if the level wants a specific node be some habitat without any building nearby")]
    [SerializeField]
    private HabitatBluePrint currentHabitat;
    public HabitatBluePrint CurrentHabitat
    {
        get { return currentHabitat; }
        private set { currentHabitat = value; }
    }

    [SerializeField]
    private HabitatBluePrint defaultHabitat;

    //need reference to renderer to change material
    public Renderer rend;
    private Material startMat;

    //player tag
    public string PlayerTag = "Player";
    //bool to track if the player is over the node
    private bool isPlayerOverNode;

    private void Awake()
    {
        startMat = rend.material;
        isPlayerOverNode = false;
        currentHabitat = defaultHabitat;
    } //start

    private void Update()
    {
        //if the player is not on the node we need to tint the color back to its habitat
        if(isPlayerOverNode == false)
        {
            rend.material = CurrentHabitat.material;
        }
        
    } //update

    public void SetHabitat(HabitatBluePrint _habitat)
    {
        if (currentHabitat == defaultHabitat)
        {
            CurrentHabitat = _habitat;
            if (_habitat != null)
            {
                rend.material = CurrentHabitat.material;
            }
        }
    } //set habitat

    public void RefreshHabitat()
    {
        currentHabitat = defaultHabitat;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            isPlayerOverNode = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            isPlayerOverNode = false;
        }
    }

} //class
