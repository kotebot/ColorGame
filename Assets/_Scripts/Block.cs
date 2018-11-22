using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShermanLibr;

public class Block : MonoBehaviour {

    public SpriteRenderer colorBlock;

    private int n;
    private PlayerConroller pc;
    private new Collider2D collider;

    private void Start()
    {
        n = Random.Range(0, 2);
        colorBlock=GetComponent<SpriteRenderer>();
        pc = FindObjectOfType<PlayerConroller>();
        collider = GetComponent<Collider2D>();
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if (pc.MyColor.color.Equals(colorBlock.color))
            {
                SpawnSystem.instance.count++;

                ShermanLibr.ScoreSystem.PlusScore();
                ShermanLibr.ScoreSystem.UpdateMaxScore();
                pc.MyColor.color = SpawnSystem.instance.poolColors[n];
                if (SpawnSystem.instance.count % 2 != 0)
                    SpawnSystem.instance.Spawn();
            }
            else
                PlayerConroller.instance.GameOver();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!pc.MyColor.color.Equals(colorBlock.color))
                PlayerConroller.instance.GameOver();


        }
    }
}
