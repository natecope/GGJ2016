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
        Debug.Log("Collide! " + other.gameObject.tag);

            this.gameObject.SendMessageUpwards("isGrabButtonPressed", data);
            if(data.isButtonPressed)
            {
                Debug.Log("We're grabbing!!");
                if (other.attachedRigidbody)
                    other.attachedRigidbody.transform.SetParent(this.transform);

            }
        }
    }
}
