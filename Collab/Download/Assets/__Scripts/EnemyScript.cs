using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyScript : MonoBehaviour
{
    public float speed; // variable for the speed 
    public Text countText;//get the counter text

    private Transform _target;
    public float health;

    // Start is called before the first frame update
    void Awake()
    {
        //get the count text and set it to countText
        countText = GameObject.Find("Count").GetComponent<Text>();
        //initialize the text to the number of enemies
        countText.text = "Geese Remaining: " + GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform targetPos {
        get {
            return _target;
        }
        set {
            _target = value;
        }
    }


    //call function when collider is triggered
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collision is triggered by hero weapon then destroy the enemy gameobject
        if (collision.gameObject.CompareTag("Weapon"))
        {

            //update counter based on the number of Enemies left
            countText.text = "Geese Remaining: " + (GameObject.FindGameObjectsWithTag("Enemy").Length - 1).ToString();

            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Mine"))
        {

            //update counter based on the number of Enemies left
            countText.text = "Geese Remaining: " + (GameObject.FindGameObjectsWithTag("Enemy").Length - 1).ToString();

            collision.GetComponentInChildren<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = collision.GetComponentInChildren<ParticleSystem>().emission;
            em.enabled = true;

            Destroy(collision.gameObject, 1);
            Destroy(gameObject);

        }
    }
    public void TakeDamage(int damage)
    {
        //health -= damage;
    }

    public void setScore(int score) {
        //update counter based on the number of Enemies left
        countText.text = "Geese Remaining: " + (GameObject.FindGameObjectsWithTag("Enemy").Length - 1).ToString();
    }

    public void setScore()
    {
        //update counter based on the number of Enemies left
        countText.text = "Geese Remaining: " + (GameObject.FindGameObjectsWithTag("Enemy").Length - 1).ToString();
    }

}
