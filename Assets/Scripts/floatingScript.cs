using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nS1

{
	public class floatingScript : MonoBehaviour {

        //public GameObject player;
        public bool fly;
        float high;
        float speed;
        //float dist;

        void Start()
        {

            // max height is here
            high = transform.position.y + 8f;

            //this is the trigger distance. change it how you like
            //dist = 2.5f;
            // this is the speed
            speed = 0.1f;

            //player = GameObject.Find("name of player object");

        }


        void Update()
        {

            //if (Vector3.Distance(player.transform.position, transform.position) < dist)
            //{
            //    fly = true;
            //}




            if (fly)
            {


                if (transform.position.y < high)
                {


                    //Vector3 v = new Vector3(0, speed * Time.deltaTime, 0);

                    // you could also use the v variable to add to
                    // the velocity instead of this next line
                    // but i just did this to get you moving

                    //transform.position = transform.position + v;
                    transform.position += new Vector3(0, speed * Time.deltaTime, 0);

                }
            }


        }

    }
}


