// HarmonicSineWave.cs - SexyCurves
// 
// Created at 13:58, on 14.06.2016
// 
// By Konstantin Rudolph
// 
// Last modified at 14:11, on 14.06.2016

using System;
using UnityEngine;

namespace SexyCurves.Utility
{
    /// <summary>
    ///     Class to epresents a harmonic sine wave.
    /// </summary>
    public class HarmonicSineWave
    {
        #region Variables

        /// <summary>
        ///     The amplitude of the sine wave.
        /// </summary>
        private float _amplitude = 1.0f;

        /// <summary>
        ///     The frequency defines the amount of oscillations per second.
        /// </summary>
        private float _frequency = 1.0f;

        /// <summary>
        ///     The displacement on the y-axis.
        /// </summary>
        private float _yDisplacement = 0.0f;

        #endregion

        #region Functions

        public float CalculateHeigthAtSecond(float second)
        {
            if (second < 0.0f)
            {
                throw new ArgumentOutOfRangeException("Second parameter cannot be smaller than 0.0f");
            }

            float value = 0.0f;

            value = _amplitude*Mathf.Sin(2*Mathf.PI*_frequency*second) + _yDisplacement;

            return value;
        }

        #endregion

        #region Setters

        /// <summary>
        ///     Sets the amplitude of the harmonic sine wave.
        /// </summary>
        /// <param name="amplitude">The amplitude of the wave.</param>
        public void SetAmplitude(float amplitude)
        {
            _amplitude = amplitude;
        }

        /// <summary>
        ///     Sets the frequency of the harmonic sine wave.
        /// </summary>
        /// <param name="frequency">The frequency of the wave.</param>
        public void SetFrequency(float frequency)
        {
            _frequency = frequency;
        }

        /// <summary>
        ///     Sets the displacement on the y-axis of the wave.
        /// </summary>
        /// <param name="displacement">The displacement.</param>
        public void SetYDisplacement(float displacement)
        {
            _yDisplacement = displacement;
        }

        #endregion

        #region Getters

        /// <summary>
        ///     Returns the current amplitude of the harmonic sine wave.
        /// </summary>
        /// <returns>The amplitude.</returns>
        public float GetAmplitude()
        {
            return _amplitude;
        }

        /// <summary>
        ///     Returns the current frequency of the harmonic sine wave.
        /// </summary>
        /// <returns>The frequency.</returns>
        public float GetFrequency()
        {
            return _frequency;
        }

        /// <summary>
        ///     Returns the current displacement on the y-axis.
        /// </summary>
        /// <returns>Y-axis displacment.</returns>
        public float GetYDisplacement()
        {
            return _yDisplacement;
        }

        #endregion
    }
}