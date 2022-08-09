using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FluffyUnderware.Curvy.Controllers
{
    public class Hair : MonoBehaviour, Interactable
    {
        public void Interact()
        {
            FindObjectOfType<Player>().HairAmount++;
            Destroy(gameObject);
        }
        void Start()
        {

        }
        void Update()
        {

        }
    }
}