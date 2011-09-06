Google Analytics iOS SDK
========================

This folder contains the bindings for the Google Analytics iOS SDK.
This is currently bound to version [1.2 of the SDK](http://code.google.com/mobile/analytics/download.html)

Please help and fix any bugs/issues that you see. Accepting pull requests 24/7.

Build
===== 
Navigate to this directory in terminal and run the following command
	/Developer/MonoTouch/usr/bin/btouch GoogleAnalytics.cs
This will produce you a GoogleAnalytics.dll assembly, which you can use in your MonoTouch projects.

You will also need to make sure you have the libGoogleAnalytics_NoThumb.a in your project (this can be found in the downloaded SDK download) and the following extra arguments set in your iPhone Build section as
	-gcc_flags "-L${ProjectDir} -lGoogleAnalytics_NoThumb -framework CFNetwork -lsqlite3.0 -ObjC -all_load"

Known Issues
============

The DryRun property being set causes an Objective-C, need more investigation on this issue.

License
=======

Copyright (c) 2011 Xamarin Inc.

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
Miguel De Icaza
