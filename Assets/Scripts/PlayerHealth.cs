using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Slider  healthSlider;
    [SerializeField]
    private Slider  stomacSlider;

    private Image stomachFillImage;
private Color MainStomacColor;
    
    private Image healthFillImage;
private Color MainHealthColor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     stomachFillImage=stomacSlider.fillRect.GetComponent<Image>();   
     MainStomacColor=stomachFillImage.color;

      healthFillImage=healthSlider.fillRect.GetComponent<Image>();   
     MainHealthColor=healthFillImage.color;
    }

    
    
    
    // Update is called once per frame
    void Update()
    {
         UpdateStomac();
        UpdateHealth(); 
    }

    private void UpdateHealth()
    {
       if(stomacSlider.value ==0)
        {
        healthSlider.value = healthSlider.value -  (0.5f * Time.deltaTime); 
           ChangeColor(healthSlider,healthFillImage ,MainHealthColor);   
        } 
    }
private void UpdateStomac()
    {
       if(stomacSlider.value !=0)
        {
        stomacSlider.value = stomacSlider.value -  (0.8f * Time.deltaTime);  
        ChangeColor(stomacSlider,stomachFillImage ,MainStomacColor); 
        } 
    }
    private void ChangeColor(Slider slider, Image image, Color MainColor)
    {
        if(slider.value < 15 && image.color != Color.red )
        {
            image.color=Color.red ;
        } else if (slider.value > 50 &&  image.color != MainColor)
        {
            image.color=MainColor;
        } else if (slider.value < 50 && slider.value >= 15)
        {
            image.color=Color.yellow;
        }
    }
    public void addCalories(float calories)
    {
        stomacSlider.value =Mathf.Min(100,stomacSlider .value +calories );
        
    }
}
