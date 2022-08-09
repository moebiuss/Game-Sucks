using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Controllers
{
    public class Player : MonoBehaviour
    {
        [SerializeField] SplineController splineController;
        Slider slider;
        private int hairAmount;

        public int HairAmount
        {
            get { return hairAmount; }
            set { hairAmount = value;print(hairAmount); }
        }


        void Start()
        {
            splineController = GetComponent<SplineController>();
            slider = FindObjectOfType<Slider>();

        }

        void Update()
        {
            splineController.OffsetRadius = slider.value;
        }
        private void OnCollisionEnter(Collision collision)
        {
            print("T");
            collision.gameObject.GetComponent<Interactable>()?.Interact();
        }
    }
}
