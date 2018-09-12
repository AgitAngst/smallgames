using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{

    [SerializeField] GameObject Hedgehog;
    [SerializeField] float timeToLive = 15f;

    [SerializeField] [Range(0.1f, 1.5f)] float randomSizeMin = 0.31f;
    [SerializeField] [Range(0.1f, 1.5f)] float randomSizeMax = 5f;
    [SerializeField] float randomJumpMin = 2f;
    [SerializeField] float randomJumpMax = 10f;
    [SerializeField] int thrust = 15;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            RaycastAndSpawn();
        }

    }


 

    void RaycastAndSpawn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            //hit.rigidbody.AddForce(new Vector2(0f, Random.Range(randomJumpMin, randomJumpMax)), ForceMode2D.Impulse);
            // hit.rigidbody.AddForceAtPosition(new Vector2(0f,20f), hit.transform.position);

            //hit.collider.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * thrust);
            //можно добавить Random.onUnitSphere * thrust в force, для полного рандома

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Vector2 dir =  hit.transform.position - mousePos;
            dir.x = 0f;
            Debug.Log(dir);
            hit.rigidbody.AddForce(dir * thrust, ForceMode2D.Impulse);


        }
        else SpawnHedgehog();
    }

    private void SpawnHedgehog()
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0f;

        float randomFloat = UnityEngine.Random.Range(randomSizeMin, randomSizeMax);
        Vector2 randomSize = new Vector2(randomFloat, randomFloat);

        GameObject objectInstance = Instantiate(Hedgehog, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        objectInstance.transform.localScale = randomSize;

        Destroy(objectInstance, timeToLive);

    }

}
