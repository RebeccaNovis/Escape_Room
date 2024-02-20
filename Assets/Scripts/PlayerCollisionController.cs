using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCollisionController : MonoBehaviour
{
    public UnityEvent onEntering;
    public UnityEvent OnExiting;

    private XRBaseInteractable interactable;
    
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(EnterNextLevelDoor);
    }

    public void EnterNextLevelDoor(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRDirectInteractor)
        {
            onEntering.Invoke();
        }
    }
}
