using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : MonoBehaviour {

    private float timer = 2f;
    [SerializeField] float speed = 3f;
    [SerializeField] bool startTimer = false;

    private void Update()
    {
        /*if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                
                if (transform.rotation.z == 0f && transform.rotation.z < 3f && transform.rotation.z > -3f)
                {
                    //StopAllCoroutines();
                }

                if (transform.rotation.z < 0f && transform.rotation.z > -180f)
                {
                    Debug.Log(transform.rotation.z);
                    StartCoroutine(RotateForSeconds(100));

                }
                else if (transform.rotation.z > 0f && transform.rotation.z < 180f)
                {
                    Debug.Log(transform.rotation.z);
                    StartCoroutine(RotateForSeconds(-100));
                }
            }

        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            startTimer = true;
            Debug.Log("Contact");
        }
            
    }

    IEnumerator RotateForSeconds(float angle) //вызов StartCoroutine(RotateForSeconds());
    {
        float time = 3f; 

        while (time > 0)  
        {
            transform.Rotate(new Vector3(0, 0, angle), Time.deltaTime * speed);
            //...rotate the object.
            time -= Time.deltaTime;
            yield return null;    

            
        }

    }


}
