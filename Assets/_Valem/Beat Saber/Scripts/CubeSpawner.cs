using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private float timeToIncreaseDifficulty = 5f;
    [SerializeField]
    private float timeDecreaser = 0.15f;
    [SerializeField]
    private float timeToSpawnCube = 1f;
    [SerializeField]
    private float cubeVelocity = 5f;
    
    private float timeCounter;
   
    [SerializeField]
    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = timeToIncreaseDifficulty;
        StartCoroutine(SpawnCubes());
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;

        if(timeCounter < 0f)
        {
            if(timeToIncreaseDifficulty > 1f)
            {
                timeToIncreaseDifficulty -= timeDecreaser;
                cubeVelocity += Time.deltaTime;
            }

            timeCounter = timeToIncreaseDifficulty;
        }
    }

    public IEnumerator SpawnCubes()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeToSpawnCube);

            Instantiate(cube);
            float x = Random.Range(-3f, 3f);
            float y = Random.Range(0.3f, 2f);
            cube.transform.position = new Vector3(x, y, transform.position.z);
            cube.transform.rotation = transform.rotation;

            CubeMovement cubeMovement = cube.GetComponent<CubeMovement>();
            cubeMovement.SetVelocity(cubeVelocity);
        }
      
    }
}
