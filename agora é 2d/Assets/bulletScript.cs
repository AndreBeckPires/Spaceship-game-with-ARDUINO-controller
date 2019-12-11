using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    public int speed = 6;
    public int pontos =10;
    public int nBalas;
    // Use this for initialization
    private Rigidbody2D r2d;
	void Start () {
        //  r2d = GetComponent<Rigidbody2D>();
        nBalas++;
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = this.transform.position;
        position.y++;
        this.transform.position = position;

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
    public int GetBalas()
    {
        return nBalas;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "recharge")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "inimigo1")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "inimigo2")
        {
            Destroy(gameObject);
        }

    }
}
