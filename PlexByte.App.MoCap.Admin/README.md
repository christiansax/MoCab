//////////////////////////////////////////////////////////////////////////
//																		//
// Title: Mobile Collaboration App										//
//																		//
// Developers: Christian B. Sax, Fabian Ochsner							//
// Project: HFU Diploma Thesis											//
// Date: 2015/11/25														//
//																		//
//////////////////////////////////////////////////////////////////////////

Admin
This solution contains the administratove components of the project. Such as user, contact etc

Components
- Contact => The contact class, implementing the IPerson interface. A contact is a user that has not signed up for MoCap, but is to some extent participating
- IAddress => The interface to define any postal address
- IDirectory => The interface to define director components
- IPerson => The interface to define any type of user
- ProjectDirectory => The project directory class, consists of project members only
- User => The user class, implementing the IPerson interface. A user has signup with moCap and thus has a login
- UserDirectory => The userDirectory class, implementing the IDirectory interface

Support
If you are having issues let us know.

License
The project is licensed under the Lesser GPL 3.0 license.
Source code found within assembles the diploma thesis project for HFU in Uster. Owner and author of the code is Christian B. Sax and Fabian Ochsner