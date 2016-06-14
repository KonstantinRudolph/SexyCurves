// SexyCurvesWindow.cs - SexyCurves
// 
// Created at 16:49, on 03.06.2016
// 
// By Konstantin Rudolph
// 
// Last modified at 13:46, on 14.06.2016

using JetBrains.Annotations;
using SexyCurves.Enumerators;
using SexyCurves.Utility;
using UnityEditor;
using UnityEngine;

namespace SexyCurves.CustomEditors
{
    /// <summary>
    ///     Custom Unity Editor Class.
    /// </summary>
    public class SexyCurvesWindow : EditorWindow
    {
        #region Variables

        /// <summary>
        ///     The manager object wich will modify the target particle system.
        /// </summary>
        private SexyCurvesManager _sexyCurvesManager = new SexyCurvesManager();

        #endregion

        #region privateFunctions

        private void CosineSettingsGui()
        {
            EditorGUILayout.LabelField("Cosine Function Settings:");
            //_amplitude = EditorGUILayout.FloatField("Amplitude:", _amplitude);
            //_frequency = EditorGUILayout.FloatField("Frequency:", _frequency);
            //y(t) = y_0 * cos(2*PI*f * t)
        }

        private void SineSettingsGui()
        {
            EditorGUILayout.LabelField("Sine Function Settings:");
            //_amplitude = EditorGUILayout.FloatField("Amplitude:", _amplitude);
            //_frequency = EditorGUILayout.FloatField("Frequency:", _frequency);
            //y(t) = y_0 * sin(2*PI*f * t)
        }

        private void HarmonicWaveGui()
        {
            EditorGUILayout.LabelField(_sexyCurvesManager.GetTargetFunction() == SexyCurvesFunctionTypeEnum.Sine
                ? "Harmonic Sine Wave Settings"
                : "Harmonic Cosine Wave");
            //_amplitude = EditorGUILayout.FloatField("Amplitude:", _amplitude);
            //_frequency = EditorGUILayout.FloatField("Frequency:", _frequency);
            //SinusWave: y(t) = y_0 * sin(2*PI*f * t)
        }

        private void ExponentialSettingsGui()
        {
            EditorGUILayout.LabelField("Exponential Function Settings:");
            //f(x) = c* e^(a*x) //a may be another function if not a constant
        }

        private void PolynomialSettingsGui()
        {
            EditorGUILayout.LabelField("Polynomial Function Settings:");
            //f(x) = a*x^n + b*x^(n-1) + ... + Y*x^0
        }

        #endregion

        #region ImplicitFunctions

        /// <summary>
        ///     Initialises the editor window, creates one if none exists, else uses existing one.
        /// </summary>
        [MenuItem("Sexy Curves/Sexy Curves Window")]
        [UsedImplicitly]
        static void Init()
        {
            var scWindow = GetWindow<SexyCurvesWindow>();
            scWindow.titleContent = new GUIContent("Sexy Curves");
            scWindow.Show();
        }

        /// <summary>
        ///     Updates and draws the window in the editor, is called by the unity framework.
        /// </summary>
        [UsedImplicitly]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once ArrangeTypeMemberModifiers
        void OnGUI()
        {
            _sexyCurvesManager.SetTargetParticleSystem(EditorGUILayout.ObjectField(
                new GUIContent("Target Particle System:",
                    "The target particle system on which one or more curve shall be modified."),
                _sexyCurvesManager.GetTargetParticleSystem(), typeof (ParticleSystem), true) as ParticleSystem);
            _sexyCurvesManager.SetTargetModule((SexyCurvesModuleEnum)
                EditorGUILayout.EnumPopup(
                    new GUIContent("Target Module:", "Which module of the particle system shall be modified."),
                    _sexyCurvesManager.GetTargetModule()));

            if (_sexyCurvesManager.GetTargetModule() == SexyCurvesModuleEnum.MainModule)
            {
                _sexyCurvesManager.SetTargetSubMainModule((SexyCurvesMainModuleEnum)
                    EditorGUILayout.EnumPopup(
                        new GUIContent("Target Sub-Main-Module:",
                            "Which sub-module of the particle systems main-module shall be modified."),
                        _sexyCurvesManager.GetTargetSubMainModule()));
            }
            _sexyCurvesManager.SetTargetCurves((SexyCurvesCurveEnum)
                EditorGUILayout.EnumPopup(new GUIContent("Target Axis:", "Which axis-curves shall be modified."),
                    _sexyCurvesManager.GetTargetCurves()));

            _sexyCurvesManager.SetTargetFunction((SexyCurvesFunctionTypeEnum)
                EditorGUILayout.EnumPopup(
                    new GUIContent("Target Function:",
                        "Which function-type shall be applied onto the selected curve(s)."),
                    _sexyCurvesManager.GetTargetFunction()));

            EditorGUILayout.Separator();
            switch (_sexyCurvesManager.GetTargetFunction())
            {
                case SexyCurvesFunctionTypeEnum.Cosine:
                    CosineSettingsGui();
                    break;
                case SexyCurvesFunctionTypeEnum.Sine:
                    SineSettingsGui();
                    break;
                case SexyCurvesFunctionTypeEnum.Exponential:
                    ExponentialSettingsGui();
                    break;
                case SexyCurvesFunctionTypeEnum.Polynomial:
                    PolynomialSettingsGui();
                    break;
            }

            if (GUILayout.Button("Apply Function"))
            {
                _sexyCurvesManager.ApplyFunctionToCurves();
            }
        }

        #endregion
    }
}