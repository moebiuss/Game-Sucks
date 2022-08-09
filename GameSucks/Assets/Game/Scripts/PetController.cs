using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FluffyUnderware.Curvy.Controllers
{
    public class PetController : MonoBehaviour
    {
        Animator animator;
        [SerializeField] SplineController splineController;
        float delay;
        [SerializeField] GameObject Furr;
        bool behind;
        void Start()
        {
            PlaySequence();
            animator = GetComponent<Animator>();
        }
        public void SlowMotionEffect(float timePass)
        {
            Time.timeScale = timePass;
        }
        public void LookBack()
        {
            splineController.enabled = false;
            Invoke("TurnBack", 0.2f);
        }
        void TurnBack()
        {
            animator.SetTrigger("Turn Left");
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y - 90, transform.rotation.z), 2.083f / 2);
        }
        public void ContinuePath()
        {
            splineController.enabled = true;
            print("Continue Path");
        }
        void PlaySequence()
        {
            Sequence sequence = DOTween.Sequence().AppendInterval(2).OnComplete(() => StopSpline());
        }
        void StopSpline()
        {
            Instantiate(Furr, transform.position, Quaternion.identity, null);
            PlaySequence();
        }
        void Update()
        {

        }
    }
}