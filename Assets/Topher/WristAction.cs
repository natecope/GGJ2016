using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Topher
{
    public class WristAction : MonoBehaviour
    {
        void OnTriggerStay(Collider other)
        {
            messageData data = new messageData();
           
            if(other.transform.parent !=null)
            {
                data.itemToBeHeld = other.transform.root.gameObject;
                this.gameObject.SendMessageUpwards("isGrabButtonPressed", data);
                if (data.isButtonPressed)
                {
                    Debug.Log("We're grabbing!!");
                    other.transform.root.SetParent(this.transform);
                    Rigidbody[] rootRigidbody = (Rigidbody[])data.itemToBeHeld.GetComponents<Rigidbody>();
                    if (rootRigidbody.Length > 0)
                    {
                        rootRigidbody[0].isKinematic = true;
                        rootRigidbody[0].useGravity = false;
                        
                    }
                }
            }
        }
    }
}
