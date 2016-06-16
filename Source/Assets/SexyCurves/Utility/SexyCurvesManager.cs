// SexyCurvesManager.cs - SexyCurves
// 
// Created at 1:52 PM, on 14.06.2016
// 
// By Konstantin Rudolph
// 
// Last modified at 3:11 AM, on 16.06.2016

using SexyCurves.Enumerators;
using UnityEngine;

namespace SexyCurves.Utility
{
    /// <summary>
    ///     Manager class, which manages the objects of targeted functions and applies them to the specified curve(s).
    /// </summary>
    public class SexyCurvesManager
    {
        /// <summary>
        ///     The amount of keys which shall be used on the curve.
        /// </summary>
        private uint _keyAmount = 1;

        /// <summary>
        ///     The axis-curves which shall be modified.
        /// </summary>
        private SexyCurvesCurveEnum _targetCurves = SexyCurvesCurveEnum.XYZ;

        /// <summary>
        ///     The type of function which shall be applied to the particle curves.
        /// </summary>
        private SexyCurvesFunctionTypeEnum _targetFunctionType = SexyCurvesFunctionTypeEnum.Cosine;

        /// <summary>
        ///     The module in which one or more curve shall be modified.
        /// </summary>
        private SexyCurvesModuleEnum _targetModule = SexyCurvesModuleEnum.MainModule;


        /// <summary>
        ///     The particle system on which the functions shall be applied.
        /// </summary>
        private ParticleSystem _targetParticleReference;

        /// <summary>
        ///     The sub-module if 'MainModule' is chosen.
        /// </summary>
        private SexyCurvesMainModuleEnum _targetSubMainModule = SexyCurvesMainModuleEnum.StartLifetime;


        /// <summary>
        ///     Applies the chosen function to the chosen module and curves.
        /// </summary>
        public void ApplyFunctionToCurves()
        {
            if (!_targetParticleReference)
            {
                Debug.LogWarning("Couldn't apply function to curves particle system isn't set.");
                return;
            }

            Debug.LogWarning("Applying Function to Curves ... not yet!");
            switch (_targetModule)
            {
                case SexyCurvesModuleEnum.MainModule:
                    ApplyFunctionToMainModule();
                    break;
                case SexyCurvesModuleEnum.EmissionModule:
                    ApplyFunctionToEmissionModule();
                    break;
                case SexyCurvesModuleEnum.VelocityOverLifetimeModule:
                    ApplyFunctionToVelocityOverLifetimeModule();
                    break;
                case SexyCurvesModuleEnum.LimitVelocityOverLifetimeModule:
                    ApplyFunctionToLimitVelocityOverLifetimeModule();
                    break;
                case SexyCurvesModuleEnum.InheritVelocityModule:
                    ApplyFunctionToInheritVelocityModule();
                    break;
                case SexyCurvesModuleEnum.ForceOverLifetimeModule:
                    ApplyFunctionToForceOverLifetimeModule();
                    break;
                case SexyCurvesModuleEnum.SizeOverLifetimeModule:
                    ApplyFunctionToSizeOverLifetimeModule();
                    break;
                case SexyCurvesModuleEnum.SizeBySpeedModule:
                    ApplyFunctionToSizeBySpeedModule();
                    break;
                case SexyCurvesModuleEnum.RotationOverLifetimeModule:
                    ApplyFunctionToRotationOverLifetimeModule();
                    break;
                case SexyCurvesModuleEnum.RotationBySpeedModule:
                    ApplyFunctionToRotationBySpeedModule();
                    break;
                case SexyCurvesModuleEnum.TextureSheetAnimationModule:
                    ApplyFunctionToTextureSheetAnimationModule();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     Applies the chosen function to the chosen sub module.
        /// </summary>
        private void ApplyFunctionToMainModule()
        {
            switch (_targetSubMainModule)
            {
                case SexyCurvesMainModuleEnum.StartLifetime:
                    ApplyFunctionToStartLifetimeCurve();
                    break;
                case SexyCurvesMainModuleEnum.StartRotation:
                    ApplyFunctionToStartRotationCurve();
                    break;
                case SexyCurvesMainModuleEnum.StartSize:
                    ApplyFunctionToStartSizeCurve();
                    break;
                case SexyCurvesMainModuleEnum.StartSpeed:
                    ApplyFunctionToStartSpeedCurve();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     Applies the chosen function to the emission module
        /// </summary>
        private void ApplyFunctionToEmissionModule()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToEmissionModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the velocityOverLifetime module
        /// </summary>
        private void ApplyFunctionToVelocityOverLifetimeModule()
        {
            //TODO:
            Debug.LogWarning(
                "Unimplemented Method ApplyFunctionToVelocityOverLifetimeModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the limitVelocityOverLifetime module
        /// </summary>
        private void ApplyFunctionToLimitVelocityOverLifetimeModule()
        {
            //TODO:
            Debug.LogWarning(
                "Unimplemented Method ApplyFunctionToLimitVelocityOverLifetimeModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the inheritVelocityOverLifetime module
        /// </summary>
        private void ApplyFunctionToInheritVelocityModule()
        {
            //TODO: apply axis X and remove axis field in window class!
            Debug.LogWarning("Unimplemented Method ApplyFunctionToInheritVelocityModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the forceOverLifetime module
        /// </summary>
        private void ApplyFunctionToForceOverLifetimeModule()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToForceOverLifetimeModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the sizeOverLifetime module
        /// </summary>
        private void ApplyFunctionToSizeOverLifetimeModule()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToSizeOverLifetimeModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the sizeBySpeed module
        /// </summary>
        private void ApplyFunctionToSizeBySpeedModule()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToSizeBySpeedModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the rotationOverLifetime module
        /// </summary>
        private void ApplyFunctionToRotationOverLifetimeModule()
        {
            //TODO:
            Debug.LogWarning(
                "Unimplemented Method ApplyFunctionToRotationOverLifetimeModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the rotationBySpeed module
        /// </summary>
        private void ApplyFunctionToRotationBySpeedModule()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToRotationBySpeedModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the textureSheetAnimation module
        /// </summary>
        private void ApplyFunctionToTextureSheetAnimationModule()
        {
            //TODO:
            Debug.LogWarning(
                "Unimplemented Method ApplyFunctionToTextureSheetAnimationModule in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the startLifetimeCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartLifetimeCurve()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToStartLifetimeCurve in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the startRotationCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartRotationCurve()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToStartRotationCurve in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the startSizeCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartSizeCurve()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToStartSizeCurve in SexyCurvesManager called!");
        }

        /// <summary>
        ///     Applies the chosen function to the startSpeedCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartSpeedCurve()
        {
            //TODO:
            Debug.LogWarning("Unimplemented Method ApplyFunctionToStartSpeedCurve in SexyCurvesManager called!");
        }

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

        /// <summary>
        ///     Sets the amount of keys which shall be used on the curve.
        /// </summary>
        /// <param name="amount">The amount of keys</param>
        public void SetKeyAmount(uint amount)
        {
            _keyAmount = amount;
        }

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
        public SexyCurvesModuleEnum GetTargetModule()
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

        /// <summary>
        ///     Returns the type of the current chosen function.
        /// </summary>
        /// <returns>The targeted function</returns>
        public SexyCurvesFunctionTypeEnum GetTargetFunction()
        {
            return _targetFunctionType;
        }

        /// <summary>
        ///     Returns the current amount of keys which shall be applied to the curve.
        /// </summary>
        /// <returns>Amount of keys.</returns>
        public uint GetKeyAmount()
        {
            return _keyAmount;
        }
    }
}