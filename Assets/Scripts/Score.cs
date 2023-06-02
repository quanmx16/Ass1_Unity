using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int whiteEggScore = 3;
    public int rottenEggScore = 1;
    public int shitScore = -2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "White_Egg")
        {
            GameController.instance.AddWhiteEgg(whiteEggScore);
        } else if(collision.gameObject.tag == "Rotten_Egg")
        {
            GameController.instance.AddRottenEgg(rottenEggScore);

        } else if(collision.gameObject.tag == "Shit")
        {
            GameController.instance.AddShit(shitScore);
        }
    }

}
