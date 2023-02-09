using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed;
    private float scale;
    private void Awake()
    {
        scale = Random.Range(0.1f, 0.9f);
        speed = Random.Range(3, 10);
    }
    private void Update()
    {
        this.transform.localScale=new Vector3( scale, scale, scale);
        this.transform.Translate(0, 0, -speed * Time.deltaTime);
        if (this.transform.position.z <= -Camera.main.orthographicSize*5)
        {
            Destroy(this.gameObject);
        }
    }
}
