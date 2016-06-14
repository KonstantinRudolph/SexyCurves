// SexyCurvesModuleEnum.cs - SexyCurves
// 
// Created at 15:39, on 03.06.2016
// 
// By Konstantin Rudolph
// 
// Last modified at 10:54, on 14.06.2016

namespace SexyCurves.Enumerators
{
    /// <summary>
    ///     Describes which module or submodules curves shall be modified.
    /// </summary>
    public enum SexyCurvesModuleEnum
    {
        MainModule,
        EmissionModule,
        VelocityOverLifetimeModule,
        LimitVelocityOverLifetime,
        InheritVelocityModule,
        ForceOverLifetimeModule,
        SizeOverLifetimeModule,
        SizeBySpeedModule,
        RotationOverLifetimeModule,
        RotationBySpeedModule,
        TextureSheetAnimationModule
    }
}