using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partical : MonoBehaviour {

    public GameObject []particals;
    private bool flag=true;

    public void EnableParcal()
    {
        if(flag)
        {
            flag = false;
            for (int i = 0; i < particals.Length; i++)
            {
                particals[i].SetActive(true);
                particals[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 3), Random.Range(0, 3)), ForceMode2D.Impulse);
                particals[i].GetComponent<SpriteRenderer>().color = SpawnSystem.instance.RandomColor();
                Destroy(particals[i], 0.7f);
            }
        }
    }
}
