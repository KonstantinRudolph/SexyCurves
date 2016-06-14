// SexyCurvesManager.cs - SexyCurves
// 
// Created at 11:23, on 14.06.2016
// 
// By Konstantin Rudolph
// 
// Last modified at 11:36, on 14.06.2016

using UnityEngine;

namespace SexyCurves.Utility
{
    /// <summary>
    ///     Manager class, which manages the objects of targeted functions and applies them to the specified curve(s).
    /// </summary>
    public class SexyCurvesManager
    {
        #region Variables

        /// <summary>
        ///     The particle system on which the functions shall be applied.
        /// </summary>
        private ParticleSystem _targetParticleReference;

        #endregion

        #region GetterAndSetter

        /// <summary>
        ///     Sets the target particle system on which functions shall be applied to.
        /// </summary>
        /// <param name="particleSystem">The target particle system.</param>
        public void SetTargetParticleSystem(ParticleSystem particleSystem)
        {
            _targetParticleReference = particleSystem;
        }
        /// <summary>
        ///     Getter returns target particle system.
        /// </summary>
        /// <returns>Target particle system.</returns>
        public ParticleSystem GetTargetParticleSystem()
        {
            return _targetParticleReference;
        }
        #endregion
    }
}