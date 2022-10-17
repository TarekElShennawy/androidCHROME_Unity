using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss_Sneer : StateMachineBehaviour
{

    UnityEngine.Rendering.Universal.Light2D sceneLight;

    UnityEngine.Rendering.Universal.Light2D bossBloom;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       sceneLight = GameObject.Find("SceneLight").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
       bossBloom = GameObject.Find("Bloom").GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        while(sceneLight.intensity > 0.2f)
        {
            sceneLight.intensity -= 0.1f;
            bossBloom.intensity += 0.2f;
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //sceneLight.intensity = 0.3f;
        //bossBloom.intensity = 1.5f;
    }

}
