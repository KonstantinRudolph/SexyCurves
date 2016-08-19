# SexyCurves

SexyCurves is a small, free open-source Unity-Editor Extension for the generation of curves in the Unity3D-Engines particle system "Shuriken".

## Features

* Generation of harmonic sine wave curves
* Generation of harmonic cosine wave curves
* Generation of natural exponential function curves

## Getting SexyCurves

You can:

* Download the UnityPackage from the [Releases](https://github.com/KonstantinRudolph/SexyCurves/releases) page
* Checkout SOURCES from this repository

## Usage

Import the UnityPackage into your Unity-Project.

In the menubar will be a new tab named 'Sexy Curves', you can open the SexyCurves Editor Extension by opening the menu entry and clicking on 'Sexy Curves Window'.
The created window can be dragged around and docked, just like any other Unity editor window.

In the newly created window you can drag and drop an existing particle system onto the 'Target Particle System' field.
Also you are able to choose the targeted particle system module, as well as the axis(or axes) of the chosen module(notice that currently no functions can be applied to main-module curves, due to restrictions of the Shuriken API).
After choosing a function type, you may modify the function parameters to your needs.
If you're happy with your changes apply them to the targeted curves by pressing the 'Apply Function' Button (notice that you have to click into the Unity Hierarchy Editor to force Unity to update the curves view-port).

## Remarks

* Notice that currently the Polynomial Function is not implemented yet.
* Notice that due to restrictions on the Shuriken API it's not possible to set the curves of the main particle system module via custom scripts.
* Notice that you have to trigger the update of the curves viewport by clicking inside of Unitys Hierarchy and reselecting the particle system.

## Versioning

* Version numbers are specified as MAJOR.MINOR.MISC
* MAJOR version increases indicate new features.
* MINOR version increases indicate new bugfixes.
* MISC version increases indicate minor changes like comments.

## Contributors

* [Konstantin Rudolph](https://github.com/KonstantinRudolph)

## License

SexyCurves is released under the [MIT license](https://github.com/KonstantinRudolph/SexyCurves/blob/master/LICENSE)