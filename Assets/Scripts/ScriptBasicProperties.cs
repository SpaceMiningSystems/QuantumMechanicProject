using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarkNameSpace

{
	public class ScriptBasicProperties : MonoBehaviour {

        public bool perfectMagnet;

        void OnCollisionEnter(Collision hit)
        {
            

            if (hit.collider.tag != "Floor" && hit.collider.tag != "Player")
            {

                GetComponent<Rigidbody>().detectCollisions = false;
                hit.collider.GetComponent<Rigidbody>().detectCollisions = false;
                StartCoroutine(DelayedKinematic());
                this.transform.rotation = hit.transform.rotation;

                if(perfectMagnet)
                {
                    this.transform.parent = hit.transform;
                    this.transform.localPosition= new Vector3(Mathf.Round(hit.contacts[0].normal.x), Mathf.Round(hit.contacts[0].normal.y), Mathf.Round(hit.contacts[0].normal.z));
                    //this.transform.position = hit.transform.position.x + Mathf.Round(hit.contacts[0].normal.x);
                    

                }
                
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.anchor = hit.contacts[0].point;
                fixedJoint.connectedBody = hit.rigidbody;


            }

            
        }

        IEnumerator DelayedKinematic()
        {
            yield return new WaitForSeconds(0.1f);


        }

    }
}


