using System;
using UnityEngine;

namespace Ducktastic
{
    public class AirParticle : MonoBehaviour
    {
        public ParticleSystem speedParticle;
        public ParticleSystem[] trailParticle;

        private PlayerInput _ınput;

        private void Start()
        {
            speedParticle.Stop();
            
            _ınput = GetComponent<PlayerInput>();

            _ınput.OnSprint += Sprint;
        }

        void Sprint(bool sprint)
        {
            if (sprint)
            {
                speedParticle.Play();
                for (int i = 0; i < 2; i++)
                {
                    trailParticle[i].startSize = 10;
                }
            }
            else
            {
                speedParticle.Stop();
                for (int i = 0; i < 2; i++)
                {
                    trailParticle[i].startSize = 2;
                }
            }
        }
    }
}