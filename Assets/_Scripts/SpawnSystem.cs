using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

    public static SpawnSystem instance;
    public GameObject block;
    public int count = 0;
    public int NumColor;
    public Color32 []poolColors=new Color32[3];
    public SpriteRenderer bg;

    private float propusk=7f;
    private float k;
    private List<int> array=new List<int>();
    private int n = 3;
    
    
   
   
    void Awake () {
        bg.color = RandomColor();
        for (int i = 0; i < 3; i++)
        {
            poolColors[i] = RandomColor();
            array.Add(i);
        }
        instance = this;
        k = 5000/3;
        
        Spawn();
	}

    public Color32 RandomColor()
    {
        Color32 randColor = new Color32();
        randColor.r = (byte)Random.Range(0, 255);
        randColor.g = (byte)Random.Range(0, 255);
        randColor.b = (byte)Random.Range(0, 255);
        randColor.a = 255;
        return randColor;
    }

    public void Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            poolColors[i] = RandomColor();
            array.Add(i);
        }
        for (int j = 0; j < 2; j++)
        {
            n = 3;
            for (int i = 0; i < 3; i++)
                array.Add(i);
            for (int i = 0; i < 3; i++)
            {
                GameObject buf = Instantiate(block);
                buf.transform.localScale = new Vector3(1, k, 1);
                buf.transform.position = new Vector2(buf.transform.position.x+propusk, (buf.transform.position.y+3.33f*i)-3.33f);
                int bufIndex = Random.Range(0, n--);
                buf.GetComponent<SpriteRenderer>().color = poolColors[array[bufIndex]];
                array.RemoveAt(bufIndex);
            }
            propusk += 7.5f;
            count++;
        }

    }
}
