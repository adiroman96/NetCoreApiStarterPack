# NetCoreApiStarterPack
## About
This project is as the name implies just a starting point to help ease the creation of a new API developed using .NET Core

## DI
### Inside the same project:
In API/Startup.cs (or Program.cs in NET 6) the services that we want injected must be added as singleton/scoped/... . And then they can be used in the controllers or other services by assigning them in the constructor (check https://github.com/adiroman96/NetCoreApiStarterPack/blob/adbffb2daee89c1503f0aa80f452d1838d53efda/API/Controllers/MedicalInformationsController.cs ).

Mentions: All services must implement an Interface!

### Useful resources about DI between libraries:

https://stackoverflow.com/questions/61461799/dependency-injection-in-net-core-inside-a-class-library
https://stackoverflow.com/questions/41323580/using-dependency-injection-with-net-core-class-library-net-standard 
