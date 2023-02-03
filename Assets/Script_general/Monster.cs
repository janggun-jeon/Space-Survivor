using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected string name;
    float hp;
    float damage;
    protected static float itemDropProb;

    protected float xInput;
    protected float yInput;

    protected float speed;
    protected float xSpeed;
    protected float ySpeed;

    protected Vector2 monsterVelocity;
    protected Rigidbody2D monsterRigidbody;

    public GameObject capsule;

    protected void Start()
    {
        hp = 100f;
        damage = 1f;
        itemDropProb = 0.1f * 10;
        monsterRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        Die();
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Skill")
        {
            hp -= collision.collider.GetComponent<Skill>().damage;
        }
    }

    protected void Die()
    {
        if (hp < 0f) { 
            Drop();
            Destroy(gameObject); 
        }
    }

   static void ChangeProb(float prob)
   {
        itemDropProb = prob;
   }

    void Drop()
    {
        if (Random.Range(0f, 1f) <= itemDropProb)
        {
            GameObject instance = Instantiate(capsule);
        }
    }
}
