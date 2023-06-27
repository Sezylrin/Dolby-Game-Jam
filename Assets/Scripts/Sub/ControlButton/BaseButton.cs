using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public MoveSub sub;
    public virtual void TriggerButton()
    {

    }

    private void Start()
    {
        sub = GameObject.FindWithTag("Submarine").GetComponent<MoveSub>();
    }
}
