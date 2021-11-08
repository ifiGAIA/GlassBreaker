using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HammerManager : MonoBehaviour
{
    private Interactable interactable;
    public GameObject sign;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        sign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Openlight();
    }
    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
        Debug.Log("4");
    }
    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
        Debug.Log("5");
    }
    void Openlight()
    {
        if(interactable.attachedToHand != null)
        {
            sign.SetActive(true);
        }
        else
        {
            sign.SetActive(false);
        }
    }
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabTypes = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if(interactable.attachedToHand == null && grabTypes != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabTypes);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
            Debug.Log("1");
        }
        else if(isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
            Debug.Log("2");
        }
         Debug.Log("3");
    }
}
