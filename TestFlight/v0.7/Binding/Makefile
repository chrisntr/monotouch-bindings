all: testflight.dll

testflight.dll: Makefile testflight.cs
	/Developer/MonoTouch/usr/bin/btouch testflight.cs --out=MonoTouch.TestFlight.dll --ns=MonoTouch.TestFlight
	cp MonoTouch.TestFlight.dll ../Sample/TestFlightSample/MonoTouch.TestFlight.dll
clean:
	-rm *dll
