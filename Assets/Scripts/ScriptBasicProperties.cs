using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarkNameSpace

{
	public class ScriptBasicProperties : MonoBehaviour {

        public bool perfectMagnet;

        // Use this for initialization
        void Start () {
            
        }
	
		// Update is called once per frame
		void Update () {
            
		}

		void OnEnable()
		{

		}

		void OnDisable()
		{

		}

		void SetInitialReferences()
		{

		}

        static int collideCount = 0;

        void OnCollisionEnter(Collision hit)
        {

            
            if (hit.collider.tag != "Floor" && hit.collider.tag != "Player")
            {

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

            //foreach (ContactPoint contact in hit.contacts)
            //{
            //    if(contact.otherCollider.tag != "Floor" && contact.otherCollider.tag != "Player")
            //    {
            //        //this.transform.position =  new Vector3 contact.otherCollider.transform.position;

            //        this.transform.rotation = hit.transform.rotation;
            //        this.transform.position = hit.transform.position + new Vector3 (0,0,1);

            //        //if (otherCube != null)
            //        //{
            //        //    this.transform.rotation = otherCube.transform.rotation;
            //        //    this.transform.position = otherCube.transform.position + new Vector3(0, 0, 1);
            //        //}

            //        FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
            //        fixedJoint.anchor = contact.point;
            //        fixedJoint.connectedBody = hit.rigidbody;




            //        //this.transform.parent = contact.otherCollider.gameObject.transform;
            //        //transform.SetParent(contact.otherCollider.gameObject.transform);
            //        //Debug.Log("My parent is now " + contact.otherCollider.gameObject.transform);
                    
            //    }          
            //}
        }


        void TOnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag != "Floor" && collision.collider.tag != "Player")
            {
                Debug.Log(ReturnDirection(collision.gameObject, this.gameObject));
            }
                
        }

        private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
        private HitDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
        {

            HitDirection hitDirection = HitDirection.None;
            RaycastHit MyRayHit;
            //Vector3 direction = (Object.transform.position - ObjectHit.transform.position).normalized;
            Vector3 direction = (ObjectHit.transform.position - Object.transform.position).normalized;
            Ray MyRay = new Ray(ObjectHit.transform.position, direction);

            if (Physics.Raycast(MyRay, out MyRayHit))
            {

                if (MyRayHit.collider != null)
                {

                    Vector3 MyNormal = MyRayHit.normal;
                    MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                    if (MyNormal == MyRayHit.transform.up) { hitDirection = HitDirection.Top; }
                    if (MyNormal == -MyRayHit.transform.up) { hitDirection = HitDirection.Bottom; }
                    if (MyNormal == MyRayHit.transform.forward) { hitDirection = HitDirection.Forward; }
                    if (MyNormal == -MyRayHit.transform.forward) { hitDirection = HitDirection.Back; }
                    if (MyNormal == MyRayHit.transform.right) { hitDirection = HitDirection.Right; }
                    if (MyNormal == -MyRayHit.transform.right) { hitDirection = HitDirection.Left; }
                }
            }
            return hitDirection;
        }

    }
}


