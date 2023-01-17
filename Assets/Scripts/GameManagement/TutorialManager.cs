using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public GameObject player;

    public GameObject welcomeText;

    public GameObject baseIntro;

    public GameObject habitatIntro;

    public GameObject movement;

    public GameObject build;

    public GameObject buildTutorial;

    public GameObject summon;

    public GameObject spell;

    private bool built = false;

    public GameObject enemyPrefab;
    private GameObject enemy;
    public Transform spawnPoint;
    private bool enemySpawned = false;

    private void Start()
    {
        DisablePlayer();
        welcomeText.SetActive(true);

    } //start

    private void Update()
    {

        if(NumberOfBuildings() == 6)
        {
            if (built == false)
            {
                Spell();
                built = true;
            }
        }

        if(enemySpawned == true)
        {
            if(enemy == null)
            {
                Summon();
            }
        }
        
    } //update

    public void BaseIntro()
    {
        welcomeText.SetActive(false);
        baseIntro.SetActive(true);

    } //base intro

    public void HabitatIntro()
    {
        baseIntro.SetActive(false);
        habitatIntro.SetActive(true);
    }

    public void Movement()
    {
        EnablePlayer();
        habitatIntro.SetActive(false);
        movement.SetActive(true);

    } //movement

    public void Build()
    {
        movement.SetActive(false);
        DisablePlayer();
        build.SetActive(true);

    } //build

    public void BuildTutorial()
    {
        EnablePlayer();
        build.SetActive(false);
        buildTutorial.SetActive(true);

    } //build tutorial

    public void Spell()
    {
        buildTutorial.SetActive(false);
        spell.SetActive(true);
        SpawnEnemy();
    }

    void Summon()
    {
        spell.SetActive(false);
        summon.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");

    } //start game

    public int NumberOfBuildings()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Good");
        int count = 0;
        foreach(GameObject building in buildings)
        {
            count += 1;
        }
        return count;

    } //number of buildings counter

    void DisablePlayer()
    {
        player.GetComponent<PlayerMovement>().enabled = false;

    } //disable player

    void EnablePlayer()
    {
        player.GetComponent<PlayerMovement>().enabled = true;

    } //enable player

    void SpawnEnemy()
    {
        enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.GetComponent<EnemySpawner>().enabled = false;
        enemySpawned = true;

    } //spawnenemy

} //class
