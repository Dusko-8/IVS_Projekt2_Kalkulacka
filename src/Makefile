ROOT:=$(shell cd)\..

VS_PATH=C:\Program Files\Microsoft Visual Studio\2022\Community
MSTEST=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\MSTest.exe
DEVENV=Common7\IDE\devenv.com

SLN_NAME=Calculator
SLN_DIR=$(ROOT)\src\$(SLN_NAME)
APP=$(SLN_DIR)\bin\Release\$(SLN_NAME).exe
SLN_FILE=$(SLN_DIR)\$(SLN_NAME).sln

all: build run

# Error in Visual Studio 2022, fix: C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\VSI\DisableOutOfProcBuild\README.txt
build:
	cd "$(VS_PATH)" & $(DEVENV) "$(SLN_FILE)" /build Release

run:
	$(APP)

clean:
	if exist .vs rmdir .vs /s /q
	if exist .\Calculator\.vs rmdir .\Calculator\.vs /s /q
	if exist ..\.vs rmdir ..\.vs /s /q
	if exist .\Setup\Debug\ rmdir .\Setup\Debug\ /s /q
	if exist .\StandardDeviation\bin\ rmdir .\StandardDeviation\bin\ /s /q
	if exist .\StandardDeviation\obj\ rmdir .\StandardDeviation\obj\ /s /q
	if exist .\Calculator\bin\ rmdir .\Calculator\bin\ /s /q
	if exist .\Calculator\obj\ rmdir .\Calculator\obj\ /s /q
	if exist .\MathematicaLibraryIVS\bin\ rmdir .\MathematicaLibraryIVS\bin\ /s /q
	if exist .\MathematicaLibraryIVS\obj\ rmdir .\MathematicaLibraryIVS\obj\ /s /q
	if exist .\Math_Library.UnitTests\bin\ rmdir .\Math_Library.UnitTests\bin\ /s /q
	if exist .\Math_Library.UnitTests\obj\ rmdir .\Math_Library.UnitTests\obj\ /s /q
