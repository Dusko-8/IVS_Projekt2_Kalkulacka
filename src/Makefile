# path to root folder
ROOT:=$(shell cd)\..

# path to Visual Studio
VS_PATH=C:\Program Files\Microsoft Visual Studio\2022
# path to vstest
VSTEST=Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe
# path to devenv 
DEVENV=Community\Common7\IDE\devenv.com

# path to calculator
SLN_NAME=Calculator
SLN_DIR=$(ROOT)\src\$(SLN_NAME)
APP=$(SLN_DIR)\bin\Release\$(SLN_NAME).exe
SLN_FILE=$(SLN_DIR)\$(SLN_NAME).sln

# path to tests
TEST_NAME=Math_Library.UnitTests
TEST_DIR=$(ROOT)\src\$(TEST_NAME)
TEST_FILE=$(TEST_DIR)\bin\Release\$(TEST_NAME).dll

# path to standard deviation
STDDIV_NAME=StandardDeviation
STDDIV_DIR=$(ROOT)\src\$(STDDIV_NAME)
STDDIV_FILE=$(STDDIV_DIR)\bin\Release\$(STDDIV_NAME).exe
INPUT_FOLDER=$(STDDIV_DIR)\Input

all: build

# error in Visual Studio 2022, fix: C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\VSI\DisableOutOfProcBuild\README.txt
build: clean
# building the solution
	cd "$(VS_PATH)" & $(DEVENV) "$(SLN_FILE)" /build Release

# starting the app
run:
	$(APP)

# removing unnecessary files and folders
clean:
# removing all .vs folders
	if exist .vs rmdir .vs /s /q
	if exist .\Calculator\.vs rmdir .\Calculator\.vs /s /q
	if exist ..\.vs rmdir ..\.vs /s /q
# removing debug and release folders from Setup project folder
	if exist .\Setup\Debug\ rmdir .\Setup\Debug\ /s /q
	if exist .\Setup\Release\ rmdir .\Setup\Release\ /s /q
# removing bin and obj folders from Standard Deviation project folder
	if exist .\StandardDeviation\bin rmdir .\StandardDeviation\bin /s /q
	if exist .\StandardDeviation\obj rmdir .\StandardDeviation\obj /s /q
# removing bin and obj folders from Calculator project folder
	if exist .\Calculator\bin rmdir .\Calculator\bin /s /q
	if exist .\Calculator\obj rmdir .\Calculator\obj /s /q
# removing bin and obj folders from Mathematical Library project folder
	if exist .\MathematicaLibraryIVS\bin rmdir .\MathematicaLibraryIVS\bin /s /q
	if exist .\MathematicaLibraryIVS\obj rmdir .\MathematicaLibraryIVS\obj /s /q
# removing bin and obj folders from Mathematical Library Unit Tests project folder
	if exist .\Math_Library.UnitTests\bin rmdir .\Math_Library.UnitTests\bin /s /q
	if exist .\Math_Library.UnitTests\obj rmdir .\Math_Library.UnitTests\obj /s /q
# removing html folder containing doxygen documentation
	if exist ..\html rmdir ..\html /s /q
# removing TestResults folder
	if exist .\Math_Library.UnitTests\TestResults rmdir .\Math_Library.UnitTests\TestResults /s /q

pack: build doc
# creating files for setup, repo and doc
	if not exist ..\..\xduric06_xpagan00_xsluka00_xmahut01 mkdir ..\..\xduric06_xpagan00_xsluka00_xmahut01
	if not exist ..\..\xduric06_xpagan00_xsluka00_xmahut01\install mkdir ..\..\xduric06_xpagan00_xsluka00_xmahut01\install
	if not exist ..\..\xduric06_xpagan00_xsluka00_xmahut01\repo mkdir ..\..\xduric06_xpagan00_xsluka00_xmahut01\repo
	if not exist ..\..\xduric06_xpagan00_xsluka00_xmahut01\doc mkdir ..\..\xduric06_xpagan00_xsluka00_xmahut01\doc
# copying setup files 
	if exist .\Setup\Release xcopy .\Setup\Release\* ..\..\xduric06_xpagan00_xsluka00_xmahut01\install /Y
# copying doxygen documentation files
	if exist ..\html xcopy ..\html\* ..\..\xduric06_xpagan00_xsluka00_xmahut01\doc /E /H /C /I /Y
# cleaning all unnecessary files
	make clean
# copying the whole repo
	if exist ..\..\IVS_Projekt2_Kalkulacka\ xcopy ..\..\IVS_Projekt2_Kalkulacka\* ..\..\xduric06_xpagan00_xsluka00_xmahut01\repo /E /H /C /I /Y
# if zip already exists it will be deleted
	if exist xduric06_xpagan00_xsluka00_xmahut01.zip del xduric06_xpagan00_xsluka00_xmahut01.zip /s /q
# ziping the folder
	if exist ..\..\xduric06_xpagan00_xsluka00_xmahut01 powershell Compress-Archive -Path ..\..\xduric06_xpagan00_xsluka00_xmahut01 -DestinationPath xduric06_xpagan00_xsluka00_xmahut01.zip
# removing temporary folder
	rmdir ..\..\xduric06_xpagan00_xsluka00_xmahut01 /s /q

doc:
# generating doxygen documentation
	doxygen Doxyfile

test: build
# creating TestResults folder only if it doesnt exist
	if not exist .\Math_Library.UnitTests\TestResults mkdir .\Math_Library.UnitTests\TestResults
# starting Unit Tests
	cd "$(VS_PATH)" & $(VSTEST) "$(TEST_FILE)" /ResultsDirectory:\Math_Library.UnitTests\TestResults

profile:
# building standard deviation executable file
	cd "$(VS_PATH)" & $(DEVENV) $(ROOT)\src\StandardDeviation\StandardDeviation.csproj /build Release
# profiling for 10 numbers
#	$(STDDIV_FILE) < $(INPUT_FOLDER)\10.txt
# profiling for 100 numbers
#	$(STDDIV_FILE) < $(INPUT_FOLDER)\100.txt
# profiling for 1000 numbers
#	$(STDDIV_FILE) < $(INPUT_FOLDER)\1000.txt