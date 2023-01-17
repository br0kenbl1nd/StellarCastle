using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnitStats))]
public class HealthBar : MonoBehaviour
{
    [Header("Good Health bar Image")]
    [SerializeField]
    private Sprite healthBar_Green;
    [Header("Bad Health bar Image")]
    [SerializeField]
    private Sprite healthBar_Red;

    //set the health bar color based on the tag of the unit
    [Header("Health bar image attached to the unit")]
    [SerializeField]
    private Image healthBar;

    [Header("Health bar gameobject")]
    [SerializeField]
    private GameObject healthBarPrefab;

    //access the health script of the unit
    [SerializeField]
    private UnitStats unitStats;

    //variable that decides the fade duration for the health bar
    [SerializeField]
    private float displayDuration;

    //variable to keep track of change in health
    private float health;

    private void Start()
    {
        health = unitStats.StartHealth;

        if (gameObject.tag == "Good")
        {
            healthBar.sprite = healthBar_Green;
        }
        else
        {
            healthBar.sprite = healthBar_Red;
        }

    } //start

    private void Update()
    {
        //check if health reduced
        if(health > unitStats.Health)
        {
            //display the health bar
            healthBarPrefab.SetActive(true);

            //update the health bar
            healthBar.fillAmount = unitStats.Health / unitStats.StartHealth;

            //hide the health bar after specified seconds
            Invoke("DisableHealthBar", displayDuration);

            //update the current health variable 
            health = unitStats.Health;
        }

    } //update


    void DisableHealthBar()
    {
        healthBarPrefab.SetActive(false);
    } //disable health bar

} //class
