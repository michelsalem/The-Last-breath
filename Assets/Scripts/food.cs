using System;
using UnityEngine;

public class food : InteractiveObject
{
    [SerializeField]
    private  float calories=10;
    private PlayerHealth playerHealth;
    private Vector3 originScale;
[SerializeField]
    private  float growspeed = 0.003f;

    public override void action()
    {
       playerHealth.addCalories(calories); 
       Destroy(gameObject);
    }
    void Start()
    {
        playerHealth= GameObject.Find ("Player").GetComponent<PlayerHealth>();
        originScale = transform .lossyScale ;
        transform .localScale = Vector3 .zero ;

    }
  
    void Update()
    {
        grow();
    }

    private void grow()
    {
        if(originScale .x > transform .lossyScale .x)
        {
            Vector3 newScale = transform.localScale ;
            newScale.x += growspeed * Time.deltaTime ;
            newScale.y += growspeed * Time.deltaTime ;
            transform.localScale = newScale; 

        }
    }
}
