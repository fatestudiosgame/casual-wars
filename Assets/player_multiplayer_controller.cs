using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class player_multiplayer_controller : NetworkBehaviour
{
    // Start is called before the first frame update
  Camera player_camera;

  
  public override void OnStartClient()
  { 
    base.OnStartClient();
  if(base.IsOwner)
  {
   player_camera=Camera.main;
   player_camera.transform.SetParent(transform);

  }
  }
   
  
  void Start()
  {

  }



    // Update is called once per frame
    void Update()
    {
        
    }
}
