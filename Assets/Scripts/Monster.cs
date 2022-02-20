using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Player Target;

    public string monsterName;
    public SpriteRenderer renderer;

    public Rigidbody2D rigidBody;
    public float speed = 3f;

    private void Start()
    {
        if (Target == null) 
            Target = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (Target.transform.position - this.transform.position).normalized;
        rigidBody.velocity = dir * speed;
    }


    public void SetData(MonsterData data)
    {
        monsterName = data.name;
        renderer.sprite = data.image;
        speed = data.speed;
    }
}
