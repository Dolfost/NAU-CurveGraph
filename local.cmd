rem SET R=/r:Logger.cs.dll
rem SET R=/r:ClassLibrary1.dll 
rem     public enum IMPORTANCELEVEL { Spam, Debug, Warning, Stats, Error, FatalError, Info,  Ignore };
SET NAMEZIP=curveGraph
SET R=/r:curveGraph.dll /r:args.dll 
SET R=/r:Logger.cs.dll /r:args.dll /r:curveGraph.dll 
set DBG=/debug
echo off