using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSound : BaseButton
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void TriggerButton()
    {
        Debug.Log("triggering trigger");
        sub.ToggleSoundServerRpc();
    }
}
