using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    public int pointsHearth = 55;
    public int actualPoints;
    public int hearths;

    public GemInteraction gemInteraction;


    // Start is called before the first frame update
    void Start()
    {
        resetPoints();
    }


    public void resetPoints()
    {
        actualPoints = pointsHearth;
        hearths = gemInteraction.inventory.Count;
    }


    public void takeDamage(int damage)
    {
        actualPoints -= damage;
        if (actualPoints < 0)
        {
            if(hearths > 0)
            {
                gemInteraction.loseAGem();
                resetPoints();
            }
        }
        
    }
}
