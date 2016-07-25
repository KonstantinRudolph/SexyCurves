# SexyCurves

SexyCurves is a small, free open-source Unity-Editor Extension for the generation of curves in the Unity3D-Engines particle system "Shuriken".

## Features

* Generation of harmonic sine wave curves
* Generation of harmonic cosine wave curves
* Generation of natural exponential function curves

## Getting SexyCurves

You can:

* Download BINARIES or the UnityPackage from the [Releases](https://github.com/KonstantinRudolph/SexyCurves/releases) page
* checkout SOURCES from this repository

## Usage

Import the UnityPackage into your Unity-Project.

In the menubar be created a new tab named 'Sexy Curves', you can open the SexyCurves Editor Extension by opening the menu entry and clicking on 'Sexy Curves Window'.
The created window can be dragged around and docked, just like any other Unity editor window.

In the newly created window you can drag and drop an existing particle system onto the 'Target Particle System' field.
Also you are able to choose the targeted particle system module, as well as the axis(or axes) of the chosen module(notice that currently no functions can be applied to main-module curves, due to restrictions of the Shuriken API).
After choosing a function type, you may modify the function parameters to your needs.
If you're happy with your changes apply them to the targeted curves by pressing the 'Apply Function' Button (notice that you have to click on the particle system in the Unity Hierarchy to force Unity to update the curves view-port).

## Remarks

* Notice that currently the Polynomial Function is not implemented yet.
* Notice that due to restrictions on the Shuriken API it's not possible to set the curves via custom scripts.
* Notice that you have to trigger the update of the curves viewport by re-selecting the particle system in Unitys Hierarchy.

## Versioning

* Version numbers are specified as MAJOR.MINOR.PATCH
* MAJOR version increases indicate incompatible changes with respect to the public GameMath API.
* MINOR version increases indicate new functionality that are backwards-compatible.
* PATCH version increases indicate backwards-compatible bug fixes.

## Contributors

* [Konstantin Rudolph](https://github.com/KonstantinRudolph)

## License

SexyCurves is released under the [MIT license](https://github.com/KonstantinRudolph/SexyCurves/blob/master/LICENSE)