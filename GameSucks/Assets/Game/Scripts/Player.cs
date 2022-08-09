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
        public static Player Instance;
        private int hairAmount;
        [SerializeField] private float _movementClampNegative;
        [SerializeField] private float _movementClampPositive;
        [SerializeField] private int horizontalSpeed;
        float movement;

        private void Awake()
        {
            Instance = this;
        }
        public int HairAmount
        {
            get { return hairAmount; }
            set { hairAmount = value; }
        }


        void Start()
        {
            splineController = GetComponent<SplineController>();
            slider = FindObjectOfType<Slider>();

        }

        void Update()
        {
            //if (Input.touchCount > 0)
            //{
            //    Touch _theTouch = Input.GetTouch(0);

            //    if (_theTouch.phase == TouchPhase.Moved)
            //    {
            //        Vector2 touchPos = _theTouch.deltaPosition;
            //        if (touchPos != Vector2.zero)
            //        {
            //            //splineController.OffsetRadius = Mathf.Clamp(touchPos.x, -2f, 2f);
            //            //transform.Translate(touchPos.x * (horizontalSpeed / 100) * Time.deltaTime, 0, 0);
            //            // float x = Mathf.Clamp(touchPos.x, _movementClampNegative, _movementClampPositive);
            //            movement = (touchPos.x * horizontalSpeed) * Time.deltaTime;
            //            splineController.OffsetRadius = movement;
            //            print(movement);
            //        }
            //    }
            //    else if (_theTouch.phase == TouchPhase.Ended)
            //    {
            //        movement = 0;
            //    }
            //}
            splineController.OffsetRadius = slider.value;

        }
        private void OnCollisionEnter(Collision collision)
        {
            print("T");
            collision.gameObject.GetComponent<Interactable>()?.Interact();
        }
    }
}
