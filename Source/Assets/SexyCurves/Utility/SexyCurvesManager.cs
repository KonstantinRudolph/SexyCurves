// SexyCurvesManager.cs - SexyCurves
// 
// Created at 13:52, on 14.06.2016
// By Konstantin Rudolph
// 
// Last modified at 15:42, on 25.07.2016
// By Konstantin Rudolph

using System;
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
        ///     The single instance of the SexyCurvesManager.
        /// </summary>
        private static SexyCurvesManager _instance;

        /// <summary>
        ///     The instance property.
        /// </summary>
        public static SexyCurvesManager Instance
        {
            get { return _instance ?? (_instance = new SexyCurvesManager()); }
        }

        /// <summary>
        ///     The amount of keys which shall be used on the curve.
        /// </summary>
        private uint _keyAmount = 1;

        /// <summary>
        ///     The Scale of the Curve System.
        /// </summary>
        [Range(0.1f, float.MaxValue)]
        private float _scalar = 1.0f;

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
        private SexyCurvesModuleEnum _targetModule = SexyCurvesModuleEnum.EmissionModule;


        /// <summary>
        ///     The particle system on which the functions shall be applied.
        /// </summary>
        private ParticleSystem _targetParticleReference;

        /// <summary>
        ///     The sub-module if 'MainModule' is chosen.
        /// </summary>
        private SexyCurvesMainModuleEnum _targetSubMainModule = SexyCurvesMainModuleEnum.StartLifetime;

        /// <summary>
        ///     The functions displacement on the x-axis.
        /// </summary>
        private float _xDisplacement;

        /// <summary>
        ///     Constructor.
        /// </summary>
        private SexyCurvesManager()
        {
            HarmonicSineWave = new HarmonicSineWave();
            ExponentialGrowthFunction = new ExponentialGrowth();
        }

        /// <summary>
        ///     HarmonicSineWave Property.
        /// </summary>
        public HarmonicSineWave HarmonicSineWave { get; private set; }

        /// <summary>
        ///     ExponentialGrowth Property.
        /// </summary>
        public ExponentialGrowth ExponentialGrowthFunction { get; private set; }

        /// <summary>
        ///     Applies the chosen function to the chosen module and curves.
        /// </summary>
        public void ApplyFunctionToCurves()
        {
            if (!_targetParticleReference)
            {
                Debug.LogError("Couldn't apply function to curves particle system isn't set.");
                return;
            }

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
            }
        }

        /// <summary>
        ///     Applies the chosen function to the emission module
        /// </summary>
        private void ApplyFunctionToEmissionModule()
        {
            var module = _targetParticleReference.emission;
            var c = MakeSexyCurve();
            module.rate = c;
        }

        /// <summary>
        ///     Applies the chosen function to the velocityOverLifetime module
        /// </summary>
        private void ApplyFunctionToVelocityOverLifetimeModule()
        {
            var module = _targetParticleReference.velocityOverLifetime;
            switch (_targetCurves)
            {
                case SexyCurvesCurveEnum.XYZ:
                    module.x = module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XY:
                    module.x = module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XZ:
                    module.x = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.YZ:
                    module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.X:
                    module.x = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Y:
                    module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Z:
                    module.z = MakeSexyCurve();
                    break;
            }
        }

        /// <summary>
        ///     Applies the chosen function to the limitVelocityOverLifetime module
        /// </summary>
        private void ApplyFunctionToLimitVelocityOverLifetimeModule()
        {
            var module = _targetParticleReference.limitVelocityOverLifetime;
            switch (_targetCurves)
            {
                case SexyCurvesCurveEnum.XYZ:
                    module.limitX = module.limitY = module.limitZ = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XY:
                    module.limitX = module.limitY = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XZ:
                    module.limitX = module.limitZ = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.YZ:
                    module.limitY = module.limitZ = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.X:
                    module.limitX = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Y:
                    module.limitY = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Z:
                    module.limitZ = MakeSexyCurve();
                    break;
            }
        }

        /// <summary>
        ///     Applies the chosen function to the inheritVelocityOverLifetime module
        /// </summary>
        private void ApplyFunctionToInheritVelocityModule()
        {
            var module = _targetParticleReference.inheritVelocity;
            module.curve = MakeSexyCurve();
        }

        /// <summary>
        ///     Applies the chosen function to the forceOverLifetime module
        /// </summary>
        private void ApplyFunctionToForceOverLifetimeModule()
        {
            var module = _targetParticleReference.forceOverLifetime;
            switch (_targetCurves)
            {
                case SexyCurvesCurveEnum.XYZ:
                    module.x = module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XY:
                    module.x = module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XZ:
                    module.x = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.YZ:
                    module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.X:
                    module.x = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Y:
                    module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Z:
                    module.z = MakeSexyCurve();
                    break;
            }
        }

        /// <summary>
        ///     Applies the chosen function to the sizeOverLifetime module
        /// </summary>
        private void ApplyFunctionToSizeOverLifetimeModule()
        {
            var module = _targetParticleReference.sizeOverLifetime;
            module.size = MakeSexyCurve();
        }

        /// <summary>
        ///     Applies the chosen function to the sizeBySpeed module
        /// </summary>
        private void ApplyFunctionToSizeBySpeedModule()
        {
            var module = _targetParticleReference.sizeBySpeed;
            module.size = MakeSexyCurve();
        }

        /// <summary>
        ///     Applies the chosen function to the rotationOverLifetime module
        /// </summary>
        private void ApplyFunctionToRotationOverLifetimeModule()
        {
            var module = _targetParticleReference.rotationOverLifetime;
            switch (_targetCurves)
            {
                case SexyCurvesCurveEnum.XYZ:
                    module.x = module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XY:
                    module.x = module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XZ:
                    module.x = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.YZ:
                    module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.X:
                    module.x = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Y:
                    module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Z:
                    module.z = MakeSexyCurve();
                    break;
            }
        }

        /// <summary>
        ///     Applies the chosen function to the rotationBySpeed module
        /// </summary>
        private void ApplyFunctionToRotationBySpeedModule()
        {
            var module = _targetParticleReference.rotationBySpeed;
            switch (_targetCurves)
            {
                case SexyCurvesCurveEnum.XYZ:
                    module.x = module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XY:
                    module.x = module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.XZ:
                    module.x = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.YZ:
                    module.y = module.z = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.X:
                    module.x = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Y:
                    module.y = MakeSexyCurve();
                    break;
                case SexyCurvesCurveEnum.Z:
                    module.z = MakeSexyCurve();
                    break;
            }
        }

        /// <summary>
        ///     Applies the chosen function to the textureSheetAnimation module
        /// </summary>
        private void ApplyFunctionToTextureSheetAnimationModule()
        {
            var module = _targetParticleReference.sizeBySpeed;
            module.size = MakeSexyCurve();
        }

        /// <summary>
        ///     NOT YET POSSIBLE | Applies the chosen function to the startLifetimeCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartLifetimeCurve()
        {
            //NOT_YET_POSSIBLE:
            Debug.LogWarning(
                "The Function 'ApplyFunctionToStartLifetimeCurve' doesn't have functionality yet, due to the lack of property exposure on the Unity Shuriken API part");
        }

        /// <summary>
        ///     NOT YET POSSIBLE | Applies the chosen function to the startRotationCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartRotationCurve()
        {
            //NOT_YET_POSSIBLE:
            Debug.LogWarning(
                "The Function 'ApplyFunctionToStartRotationCurve' doesn't have functionality yet, due to the lack of property exposure on the Unity Shuriken API part");
        }

        /// <summary>
        ///     NOT YET POSSIBLE | Applies the chosen function to the startSizeCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartSizeCurve()
        {
            //NOT_YET_POSSIBLE:
            Debug.LogWarning(
                "The Function 'ApplyFunctionToStartSizeCurve' doesn't have functionality yet, due to the lack of property exposure on the Unity Shuriken API part");
        }

        /// <summary>
        ///     NOT YET POSSIBLE | Applies the chosen function to the startSpeedCurve in the main module.
        /// </summary>
        private void ApplyFunctionToStartSpeedCurve()
        {
            //NOT_YET_POSSIBLE:
            Debug.LogWarning(
                "The Function 'ApplyFunctionToStartSpeedCurve' doesn't have functionality yet, due to the lack of property exposure on the Unity Shuriken API part");
        }

        /// <summary>
        ///     Returns the curve created by the chosen settings.
        /// </summary>
        /// <returns>ParticleSystem.MinMaxCurve</returns>
        private ParticleSystem.MinMaxCurve MakeSexyCurve()
        {
            var animCurve = new AnimationCurve();
            // TODO: Add Smart KeyAmount if _keyAmount == 0
            // -> calculate minimal amount of keys and best positions based on function-behavior
            if (_keyAmount == 1)
            {
                animCurve.AddKey(0.0f, GetFunctionDelegate()(0.0f));
            }
            else if (_keyAmount == 2)
            {
                animCurve.AddKey(0.0f, GetFunctionDelegate()(0.0f));
                animCurve.AddKey(1.0f, GetFunctionDelegate()(1.0f));
            }
            else
            {
                var stride = 1.0f/(_keyAmount - 1);
                for (var i = 0; i < _keyAmount; ++i)
                {
                    var val = 0.0f;
                    if (i == _keyAmount - 1)
                    {
                        // Endpoint should always be at the maximal x value.
                        val = 1.0f;
                    }
                    else
                    {
                        val = i*stride;
                    }
                    animCurve.AddKey(val, GetFunctionDelegate()(val + _xDisplacement));
                }
            }
            var curve = new ParticleSystem.MinMaxCurve(_scalar, animCurve);
            return curve;
        }

        /// <summary>
        ///     Returns the Delegate of the targeted function.
        /// </summary>
        /// <returns>target function delegate</returns>
        private Func<float, float> GetFunctionDelegate()
        {
            if (_targetFunctionType == SexyCurvesFunctionTypeEnum.Cosine)
            {
                return HarmonicSineWave.CalculateHeightAtSecondAndConvertToCosine;
            }
            if (_targetFunctionType == SexyCurvesFunctionTypeEnum.Exponential)
            {
                return ExponentialGrowthFunction.CalculateHeightAtSecond;
            }
            return HarmonicSineWave.CalculateHeightAtSecond;
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
        /// <param name="amount">The amount of keys.</param>
        public void SetKeyAmount(uint amount)
        {
            _keyAmount = amount;
        }

        /// <summary>
        ///     Sets the scalar of the curve.
        /// </summary>
        /// <param name="scalar">the new scalar value.</param>
        public void SetScalar(float scalar)
        {
            _scalar = scalar;
        }

        /// <summary>
        ///     Sets the selected curves displacement on the x-axis.
        /// </summary>
        /// <param name="displacementValue">the displacement on the x-axis</param>
        public void SetXDisplacement(float displacementValue)
        {
            _xDisplacement = displacementValue;
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

        /// <summary>
        ///     Returns the current scalar of the curve.
        /// </summary>
        /// <returns></returns>
        public float GetScalar()
        {
            return _scalar;
        }

        /// <summary>
        ///     Returns the current function displacement on the x-axis
        /// </summary>
        /// <returns>the current functions displacement</returns>
        public float GetXDisplacement()
        {
            return _xDisplacement;
        }
    }
}