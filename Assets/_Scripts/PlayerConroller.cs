using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConroller : MonoBehaviour {

    public static PlayerConroller instance;
    public float jumpForce;
    public SpriteRenderer MyColor;
    public Partical partical;

    private Color32 StartColor;
    private Rigidbody2D rb;
    private bool flag = false;
    private Animation anim;
    private bool isDead;
    

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
    }

    void Start() {
        StartColor = SpawnSystem.instance.poolColors[Random.Range(0, 2)];
        MyColor = GetComponent<SpriteRenderer>();
        MyColor.color = StartColor;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Jump")||Input.GetMouseButtonDown(0)&&!isDead)
        {
            flag = true;
            Time.timeScale = 1;
        }
            
    }

    void FixedUpdate () {
        if(rb.velocity.x<5)
            rb.AddForce(new Vector2(5, 0));
        if(flag)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0.1f, jumpForce), ForceMode2D.Impulse);
            flag = false;
            anim.Play();
        }   
    }

    public void GameOver()
    {
        partical.EnableParcal();
        rb.simulated=false;
        Invoke("LoadScene", 1f);
        isDead = true;
        ShermanLibr.ScoreSystem.Save();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
