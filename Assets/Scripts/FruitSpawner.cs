using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
   [SerializeField]
   private GameObject fruitPrefab1;
   [SerializeField]
   private GameObject fruitPrefab2;
private GameObject fruit1;
private GameObject fruit2;
[SerializeField]
private float fruitPosX = 0.3f;
[SerializeField]
private float fruitPosY = 0.3f;
private bool isFruitCreated =false ;
    void Start()
    {
        Invoke("spawnFruit",4);
      
    }
   
    void Update()
    {
        if(fruit1 == null && !isFruitCreated )
        {
             Invoke("spawnFruit",4);
             isFruitCreated = true ;
        }
    }
    private void spawnFruit()
    {
        fruit1=Instantiate(fruitPrefab1);
        Vector3 pos1= gameObject.transform.position ;
        pos1.x  += fruitPosX;
        pos1.y  += fruitPosY;
        fruit1.transform.position=pos1 ;

        fruit2=Instantiate(fruitPrefab2);
        Vector3 pos2= gameObject.transform.position ;
        pos2.x  -= fruitPosX;
        pos2.y  -= fruitPosY;
        fruit2.transform.position=pos2 ;

        isFruitCreated = false ;
    }
}
