//////////////////////////////////////////////////////////////////////////
//																		//
// Title: Mobile Collaboration App										//
//																		//
// Developers: Christian B. Sax, Fabian Ochsner							//
// Project: HFU Diploma Thesis											//
// Date: 2015/11/25														//
//																		//
//////////////////////////////////////////////////////////////////////////

Manager
This solution contains all manager and help classes used in this project.

Components
- ComHub => The ComHub implements the IComMsg interface and serves as a central command hub, through with each component communicated
- Dispatcher => The Dispatcher class implements the IComMsg interface and dispatches any messages or interactions
- IComMsg => The interface defining command and communication messages the system is using internally
- Notifier => A central notification server that also implements the IComMsg interface

Support
If you are having issues let us know.

License
The project is licensed under the Lesser GPL 3.0 license.
Source code found within assembles the diploma thesis project for HFU in Uster. Owner and author of the code is Christian B. Sax and Fabian Ochsner