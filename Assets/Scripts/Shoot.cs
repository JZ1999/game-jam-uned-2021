using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool canShoot;
    public GameObject enemy;
    public int cd = 200;
    public Life lifeScript;
    public int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        lifeScript = GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (cd == 0)
            {
                enemy.GetComponent<Movement>().HeartBroke.Play();
                enemy.GetComponent<Movement>().HearthBrokeSound.Play();

                GetComponent<Movement>().Shoot.Play();
                GetComponent<Movement>().Shoot.Play();

                lifeScript.takeDamage(damage);

                
                cd = 200;
            }
            else
            {
                cd--;
            }
        }
    }
}
