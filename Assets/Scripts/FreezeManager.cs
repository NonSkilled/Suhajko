using UnityEngine;
using UnityEngine.UI;

public class FreezeManager : MonoBehaviour
{   
    public Slider slider;
    public float freeze = 0f;

    public void SetMaxFreeze()
    {
        slider.maxValue = 100;
    }
    
    public void SetFreeze(float freeze)
    {
        slider.value = freeze;
    }
    void Start()
    {
        SetMaxFreeze();
    }

    
    void Update()
    {
        
    }
}
