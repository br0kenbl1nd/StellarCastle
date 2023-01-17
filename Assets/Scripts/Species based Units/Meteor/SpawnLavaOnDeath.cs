using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class SpawnLavaOnDeath : MonoBehaviour
{
    [Header("Lava prefab")]
    [SerializeField]
    private GameObject lava;

    private void OnDestroy()
    {
        Vector3 newPos = new Vector3(transform.position.x, 0.2f, transform.position.z);

        Instantiate(lava, newPos, Quaternion.identity);

    }

} //class
