using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recharge : MonoBehaviour {
    AudioSource audioData;
    public GameObject player;
    // Use this for initialization
    void Start() {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }
    private void OnBecameInvisible()
    {
        changePos();
    }
    public void changePos()
    {
        float numberx = Random.Range(-6.7f, 5.5f);
        float numbery = Random.Range(24.0f, 180.0f);
        this.transform.position = new Vector3(numberx, numbery, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bala")
        {
            playSound();
            player.GetComponent<controller>().SetBalas();
            changePos();
        }
    }
    public void playSound()
    {
        audioData.Play(0);
    }
}
