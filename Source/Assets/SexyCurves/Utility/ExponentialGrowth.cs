// ExponentialGrowth.cs - SexyCurves
// 
// Created at 16:06, on 25.07.2016
// By Konstantin Rudolph
// 
// Last modified at 17:02, on 25.07.2016
// By Konstantin Rudolph

using UnityEngine;

namespace SexyCurves.Utility
{
    /// <summary>
    ///     Utility class for the natural exponential function growth
    /// </summary>
    public class ExponentialGrowth
    {
        /// <summary>
        ///     The rate of decay or growth over time.
        /// </summary>
        private float _rate = 1.0f;

        /// <summary>
        ///     The quantity at the time of zero.
        /// </summary>
        private float _startQuantity = 1.0f;

        /// <summary>
        ///     Function returns the value of the class-represented natural e-function at a given time in seconds.
        /// </summary>
        /// <param name="seconds">The time in seconds</param>
        /// <returns>Value of Function at seconds</returns>
        public float CalculateHeightAtSecond(float seconds)
        {
            var value = 0.0f;

            value = _startQuantity*Mathf.Exp(_rate*seconds);

            return value;
        }

        /// <summary>
        ///     Sets the quantity at the time of zero seconds.
        /// </summary>
        /// <param name="quantity">starting quantity</param>
        public void SetStartQuantity(float quantity)
        {
            _startQuantity = quantity;
        }

        /// <summary>
        ///     Sets the decay or growth rate of the function.
        /// </summary>
        /// <param name="rate">growth-/decay rate</param>
        public void SetRate(float rate)
        {
            _rate = rate;
        }

        /// <summary>
        ///     Returns the current start-quantity of the function-instance.
        /// </summary>
        /// <returns>currentStartQuantity</returns>
        public float GetStartQuantity()
        {
            return _startQuantity;
        }

        /// <summary>
        ///     Returns the current rate of the function-instance.
        /// </summary>
        /// <returns>currentRate</returns>
        public float GetRate()
        {
            return _rate;
        }
    }
}