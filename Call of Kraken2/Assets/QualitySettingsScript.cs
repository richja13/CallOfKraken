using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class QualitySettingsScript : MonoBehaviour
{
    public RenderPipelineAsset Ultra;
    static bool UltraGFX;
  
    void Start()
    {
        UltraGFX = false;
        UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset = null;
    }

    public void QualitySettingsz()
    {
        Application.targetFrameRate = 35;

        Screen.SetResolution(1200,600, true);
        //Screen.SetResolution(850, 425, true);
        
        if (UltraGFX == false)
        {
            UltraGFX = true;
            QualitySettings.renderPipeline = Ultra;
            UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset = Ultra;
        }
        else if(UltraGFX == true)
        {
            QualitySettings.renderPipeline = null;
            UltraGFX = false;    
            UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset = null;
         
        }
    }
}
