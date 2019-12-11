using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class controller : MonoBehaviour
{
    public int bullets;
    public GameObject bullet;
    public GameObject recharge;
    public GameObject inimigo1;
    public GameObject inimigo2;
    public float v;
    public float h;
    public int colidiu;
    SerialPort seri = new SerialPort("COM5", 9600);
    AudioSource audioData;
    int nBalas = 8;
    // Use this for initialization
    void Start()
    {
        seri.Open();
        audioData = GetComponent<AudioSource>();
       
    }
    // Update is called once per frame
    void Update()
    {
        string[] values = seri.ReadLine().Split(',');
        v = (float.Parse(values[0]));
        h = (float.Parse(values[1]));

        // Debug.Log(v + "#" + h);
        Debug.Log(nBalas);


        if (h <= 300)
        {
            if (this.transform.position.x > -7.5f)
            {
                Vector3 position = this.transform.position;
                position.x--;
                this.transform.position = position;
            }
        }
        if (h > 300)
        {
            if (this.transform.position.x < 7.5f)
            {
                Vector3 position = this.transform.position;
                position.x++;
                this.transform.position = position;
            }
        }
       if(Input.GetKeyDown("space"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
        if(v == 1)
        {
            if (nBalas > 0)
            {
                Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
                audioData.Play(0);
                nBalas--;
            }
        }
        if(colidiu == 3)
        {
            Destroy(gameObject);
        }
        if(nBalas >= 25)
        {
            nBalas = 25;
        }
        
    }

    public void OnCollisionEnter2D(Collision2D col)
     {
        if (col.gameObject.tag == "inimigo1")
         {

         inimigo1.GetComponent<enemyController>().changePos();
            colidiu++;

        }
        if (col.gameObject.tag == "inimigo2")
        {
           Destroy(col.gameObject);
          //inimigo2.GetComponent<clone>().changePos();
            colidiu++;

        }
        if (col.gameObject.tag == "recharge")
        {
            SetBalas();
            recharge.GetComponent<recharge>().playSound();
            recharge.GetComponent<recharge>().changePos();

        }
    }

    public void SetBalas()
    {
        nBalas += 5;
    }
    

}
