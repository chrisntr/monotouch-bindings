Bing Maps iOS SDK
=================

This folder contains the bindings for the Bing Maps iOS SDK.
This is currently bound to version [1.1 of the SDK](http://www.microsoft.com/downloads/en/details.aspx?FamilyID=6e01a102-49ed-409e-b384-0b67521fb612)

Please help and fix any bugs/issues that you see. Accepting pull requests 24/7.

Build
===== 
Navigate to this directory in terminal and run the following command
	/Developer/MonoTouch/usr/bin/btouch BingMaps.cs EnumAndStructs.cs
This will produce you a BingMaps.dll assembly, which you can use in your MonoTouch projects.

You will also need to make sure you have the libBingMaps.a in your project (this can be found in the download .dmg file that was download), copy the BingMaps.Resources.bundle into your project, set the API key as "BingMapsKey" in the Info.plist file and the following extra arguments set in your iPhone Build section as
	-gcc_flags "-L${ProjectDir} -lBingMaps -framework QuartzCore -framework CoreData -framework CoreLocation -framework OpenGLES -framework SystemConfiguration -lxml2 -lz -ObjC -all_load" 

License
=======

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

Authors
=======
Chris Hardy
