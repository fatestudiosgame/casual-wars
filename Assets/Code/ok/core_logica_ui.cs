using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core_logica_ui : MonoBehaviour
{
    public static core_logica_ui core_logica_ui_instance;
    private void Awake() {

      if(core_logica_ui_instance==null)
     {
        core_logica_ui_instance=this;
     }
     else {Destroy(gameObject);}

    }
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
