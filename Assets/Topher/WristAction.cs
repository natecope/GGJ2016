using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Topher
{

    public class WristAction : MonoBehaviour
    {
        public bool colOn;
        public GameObject heldObj;
        //void Update()
        // {
        //added by Dan
        // messageData data = new messageData();
        //data.itemToBeHeld = other.transform.root.gameObject;
        // this.gameObject.SendMessageUpwards("isGrabButtonPressed", data);
        // if (data.isButtonPressed)
        // {
        // GetComponent<Collider>().enabled = true;
        // GetComponent<Collider>().enabled = false;
        //if (other.gameObject.GetComponent<Object>() == true)
        //{
        //    other.GetComponent<Rigidbody>().isKinematic = true;
        //}
        //  }


        //added by Dan

        //  }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "grab")
            {
                heldObj = this.gameObject;
            }
        }
        void OnTriggerStay(Collider other)
        {


            //added by Dan
            //    messageData data = new messageData();


            //data.itemToBeHeld = other.transform.root.gameObject;
            //this.gameObject.SendMessageUpwards("isGrabButtonPressed", data);
            //if (data.isButtonPressed)
            //{
            //    Debug.Log("We're grabbing!!");
            //    if(heldObj != null)
            //    {
            //        if (heldObj.GetComponent<Rigidbody>().isKinematic == false)
            //        {
            //            heldObj.GetComponent<Rigidbody>().isKinematic = true;
            //            heldObj.transform.parent = this.transform;
            //        }
            //        else {
            //            heldObj.GetComponent<Rigidbody>().isKinematic = false;
            //            heldObj.transform.parent = null;
            //            heldObj = null;
            //        }

            //colOn = true;
            //GetComponent<Collider>().enabled = true;




            //other.transform.root.SetParent(this.transform);
            //Rigidbody[] rootRigidbody = (Rigidbody[])data.itemToBeHeld.GetComponents<Rigidbody>();
            //if (rootRigidbody.Length > 0)
            // {
            //     rootRigidbody[0].isKinematic = true;
            //    rootRigidbody[0].useGravity = false;




            //added by Dan

            messageData data = new messageData();
            //other.transform.parent != null && 
            if (other.gameObject.tag == "grab")
            {
                data.itemToBeHeld = other.transform.gameObject;
                this.gameObject.SendMessageUpwards("isGrabButtonPressed", data);
                if (data.isButtonPressed)
                {
                    Debug.Log("We're grabbing!!");
                    other.transform.SetParent(this.transform);
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
