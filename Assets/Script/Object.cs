using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;
    public Transform spawnPoint;

    public float speed = 1f;
    public float distanceBetweenObstacles = 10f;
    public float obstacleHeightVariation = 3f;
    public float timeBetweenObstacles = 2f;
private float timer;



    // Start is called before the first frame update
    void Start()
    {
        GenerateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
          timer += Time.deltaTime;
    if (timer >= timeBetweenObstacles)
    {
        GenerateObstacle();
        timer = 0f; // Réinitialise le timer
    }

    transform.position += Vector3.left * speed * Time.deltaTime;
    }


    void GenerateObstacle()
{
    // Génère une position de spawn avec une variation sur l'axe horizontal
    Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(-obstacleHeightVariation, obstacleHeightVariation), 0, 0);

    // Sélectionne un préfabriqué d'obstacle aléatoire
    GameObject selectedPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

    // Instancie l'obstacle à cette position
    GameObject spawnedObstacle = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

    // Applique une vélocité au Rigidbody2D de l'obstacle instancié pour le déplacer vers la gauche
    Rigidbody2D rb = spawnedObstacle.GetComponent<Rigidbody2D>();
    if (rb != null) // Vérifie si l'obstacle a un Rigidbody2D
    {
        rb.velocity = Vector2.left * speed;
    }
    else
    {
        Debug.LogError("L'obstacle instancié ne contient pas de Rigidbody2D.");
    }

    // Décale le spawnPoint vers la droite pour la prochaine génération d'obstacle
    spawnPoint.position += Vector3.right * (distanceBetweenObstacles + 10);
}
}
