using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    public string enemyTag;
    // Start is called before the first frame update
    void Start()
    {

        ArrayList tags = new ArrayList();
        tags.Add("Team0");
        tags.Add("Team1");
        tags.Remove(gameObject.tag);
        foreach(string t in tags)
        {
            enemyTag = t;
            Debug.Log(t);
        }
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == enemyTag)
        {
            GetComponentInParent<Shoot>().canShoot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == enemyTag)
        {
            GetComponentInParent<Shoot>().canShoot = false;
        }
    }
}
