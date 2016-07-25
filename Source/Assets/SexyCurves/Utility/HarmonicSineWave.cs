// HarmonicSineWave.cs - SexyCurves
// 
// Created at 13:19, on 27.06.2016
// By Konstantin Rudolph
// 
// Last modified at 16:52, on 25.07.2016
// By Konstantin Rudolph

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
        [Range(0.0f, 1.0f)] private float _amplitude = 0.5f;

        /// <summary>
        ///     The frequency defines the amount of oscillations per second.
        /// </summary>
        private float _frequency = 1.0f;

        /// <summary>
        ///     The displacement on the y-axis.
        /// </summary>
        [Range(0.0f, 1.0f)] private float _yDisplacement = 0.5f;

        #endregion

        #region Functions

        /// <summary>
        ///     Function returns the value of the sine wave (represented by the class) at a given time in seconds.
        /// </summary>
        /// <param name="seconds">The time in seconds</param>
        /// <returns>Value of Function at seconds</returns>
        public float CalculateHeightAtSecond(float seconds)
        {
            var value = 0.0f;

            value = _amplitude*Mathf.Sin(2*Mathf.PI*_frequency*seconds) + _yDisplacement;

            return value;
        }

        /// <summary>
        ///     Since the cos(x) = sin(x-90) we can use the harmonic sine wave class.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns>Value of Function at seconds</returns>
        public float CalculateHeightAtSecondAndConvertToCosine(float seconds)
        {
            if (seconds < 0.0f)
            {
                throw new ArgumentOutOfRangeException("The seconds parameter cannot be smaller than 0.0f");
            }

            var value = 0.0f;

            value = _amplitude*Mathf.Sin(Mathf.PI/2.0f - 2*Mathf.PI*_frequency*seconds) + _yDisplacement;

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