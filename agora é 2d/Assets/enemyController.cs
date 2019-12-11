using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    public GameObject inimigo;
    public int nInimigos = 0;
    public bool colidiu = false;
    public GameObject player;
    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
       
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;

    }
    private void OnBecameInvisible()
    {
        changePos();
        //if(nInimigos <= 9)
        //{
         float number1x = Random.Range(-6.7f, 5.5f);
         float number1y = Random.Range(24.0f, 180.0f);
         Instantiate(inimigo, new Vector3(number1x, number1y, 0f), Quaternion.identity);
          //  nInimigos++; 
        //}
        

    }
   public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bala")
        {
            changePos();


        }
    }
    public void changePos()
    {
        float numberx = Random.Range(-6.7f, 5.5f);
        float numbery = Random.Range(24.0f, 180.0f);
        this.transform.position = new Vector3(numberx, numbery, 0f);
    }
}
