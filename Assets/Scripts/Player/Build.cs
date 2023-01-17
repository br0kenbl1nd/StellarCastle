using UnityEngine;

public class Build : MonoBehaviour
{
    public PlayerStats playerStats;

    [SerializeField]
    private Buildings goldMine;

    [SerializeField]
    private Buildings meteorShooter;

    [SerializeField]
    private Buildings lavaSpitter;

    [SerializeField]
    private Buildings volcano;

    [SerializeField]
    private Buildings meteorSoldierCamp;

    public GameObject toolTip;

    private void Update()
    {
        //input key 1 is for resource building
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuildGoldMine();
        }

        //input key 2 is for defense building
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuildMeteorShooter();
        }

        //input key 3 is for lava spitter
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuildLavaSpitter();
        }

        //input key 4 is for volcano
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            BuildVolcano();
        }

        //input key 5 is for soldier camp
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            BuildMeteorSoldierCamp();
        }

    } //update

    public void BuildGoldMine()
    {
        if (goldMine.buildingPrefab != null)
        {
            BuildBuilding(goldMine.buildingPrefab, goldMine.cost);
        }
    }

    public void BuildMeteorShooter()
    {
        if (meteorShooter.buildingPrefab != null)
        {
            BuildBuilding(meteorShooter.buildingPrefab, meteorShooter.cost);
        }
    }

    public void BuildMeteorSoldierCamp()
    {
        if (meteorSoldierCamp.buildingPrefab != null)
        {
            BuildBuilding(meteorSoldierCamp.buildingPrefab, meteorSoldierCamp.cost);
        }
    }

    public void BuildLavaSpitter()
    {
        if (lavaSpitter.buildingPrefab != null)
        {
            BuildBuilding(lavaSpitter.buildingPrefab, lavaSpitter.cost);
        }
    }

    public void BuildVolcano()
    {
        if (volcano.buildingPrefab != null)
        {
            BuildBuilding(volcano.buildingPrefab, volcano.cost);
        }
    }

    public void BuildBuilding(GameObject _building, float _cost)
    {
        //check if the node has the correct habitat
        if (playerStats.CurrentNode.habitat.CurrentHabitat != null)
        {
            if (playerStats.CurrentNode.habitat.CurrentHabitat.name == meteorShooter.requiredHabitatName)
            {
                //check if there is a building on the node already
                if (playerStats.CurrentNode.CurrentBuilding == null)
                {
                    //if node is free, check for money
                    if (_cost <= playerStats.Money)
                    {
                        //if we have money build
                        playerStats.CurrentNode.BuildBuildingOnNode(_building);
                        playerStats.Money -= _cost;
                    }
                    else
                    {
                        if (toolTip != null)
                        {
                            //if we dont have money, print no money
                            toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Not enough gold";
                            Invoke("ExpireText", 0.5f);
                        }
                    }


                }
                else
                {
                    if (toolTip != null)
                    {
                        //if node is full, print node is full
                        toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Cant build here!";
                        Invoke("ExpireText", 0.5f);
                    }
                }
            }
            else
            {
                if (toolTip != null)
                {
                    toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Wrong habitat!";
                    Invoke("ExpireText", 0.5f);
                }
            }
        }
        else
        {
            if (toolTip != null)
            {
                toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "Wrong habitat!";
                Invoke("ExpireText", 0.5f);
            }
        }



    } //build meteor shooter

    void ExpireText()
    {
        toolTip.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }


} //class
