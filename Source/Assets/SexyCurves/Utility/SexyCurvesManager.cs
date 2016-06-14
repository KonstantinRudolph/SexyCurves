// SexyCurvesManager.cs - SexyCurves
// 
// Created at 11:23, on 14.06.2016
// 
// By Konstantin Rudolph
// 
// Last modified at 13:19, on 14.06.2016

using SexyCurves.Enumerators;
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

        /// <summary>
        ///     The module in which one or more curve shall be modified.
        /// </summary>
        private SexyCurvesModuleEnum _targetModule = SexyCurvesModuleEnum.MainModule;

        /// <summary>
        ///     The sub-module if 'MainModule' is chosen.
        /// </summary>
        private SexyCurvesMainModuleEnum _targetSubMainModule = SexyCurvesMainModuleEnum.StartLifetime;

        /// <summary>
        ///     The axis-curves which shall be modified.
        /// </summary>
        private SexyCurvesCurveEnum _targetCurves = SexyCurvesCurveEnum.XYZ;

        /// <summary>
        ///     The type of function which shall be applied to the particle curves.
        /// </summary>
        private SexyCurvesFunctionTypeEnum _targetFunctionType = SexyCurvesFunctionTypeEnum.Cosine;

        #endregion

        #region Setter

        /// <summary>
        ///     Sets the target particle system on which functions shall be applied to.
        /// </summary>
        /// <param name="particleSystem">The target particle system.</param>
        public void SetTargetParticleSystem(ParticleSystem particleSystem)
        {
            _targetParticleReference = particleSystem;
        }

        /// <summary>
        ///     Sets the target module which has one or more curve(s), which shall be modified.
        /// </summary>
        /// <param name="moduleEnum">The enum value of the module.</param>
        public void SetTargetModule(SexyCurvesModuleEnum moduleEnum)
        {
            _targetModule = moduleEnum;
        }

        /// <summary>
        ///     Sets the target sub module.
        /// </summary>
        /// <param name="mainSubModuleEnum"></param>
        public void SetTargetSubMainModule(SexyCurvesMainModuleEnum mainSubModuleEnum)
        {
            _targetSubMainModule = mainSubModuleEnum;
        }

        /// <summary>
        ///     Sets the target curves, which shall be modified.
        /// </summary>
        /// <param name="curveEnum">The curve enumerator.</param>
        public void SetTargetCurves(SexyCurvesCurveEnum curveEnum)
        {
            _targetCurves = curveEnum;
        }

        /// <summary>
        ///     Sets the target function, which shall be applied to the target curve(s).
        /// </summary>
        /// <param name="functionTypeEnum">Function type enumerator.</param>
        public void SetTargetFunction(SexyCurvesFunctionTypeEnum functionTypeEnum)
        {
            _targetFunctionType = functionTypeEnum;
        }
        #endregion

        #region Getter
        /// <summary>
        ///     Getter returns target particle system.
        /// </summary>
        /// <returns>Target particle system.</returns>
        public ParticleSystem GetTargetParticleSystem()
        {
            return _targetParticleReference;
        }

        /// <summary>
        ///     Returns the current module target.
        /// </summary>
        /// <returns>Target module</returns>
        public SexyCurvesModuleEnum GetTargetCurvesModule()
        {
            return _targetModule;
        }

        /// <summary>
        ///     Returns the current sub module target.
        /// </summary>
        /// <returns>Target sub module</returns>
        public SexyCurvesMainModuleEnum GetTargetSubMainModule()
        {
            return _targetSubMainModule;
        }

        /// <summary>
        ///     Returns the current curve targets.
        /// </summary>
        /// <returns>Target curve.</returns>
        public SexyCurvesCurveEnum GetTargetCurves()
        {
            return _targetCurves;
        }

        public SexyCurvesFunctionTypeEnum GetTargetFunction()
        {
            return _targetFunctionType;
        }
        #endregion
    }
}