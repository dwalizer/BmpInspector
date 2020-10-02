# BmpInspector
A simple tool for viewing the hex data of a monochrome bitmap

# Building
This will vary based on your environment.  I wanted to build a self contained executable for Windows 10.  So the command I used was:

```bash
dotnet publish -c Release -r win10-x64 -p:PublishSingleFile=true --self-contained true
```

This will result in the BmpInspector.exe being created in the Release folder within the bin folder.
This does result in a pretty large executable file considering how little this tool actually does, though.

# Usage

BmpInspector.exe bmp_file.bmp

# Note

Right now this only works on Monochrome Bitmap images, and it's not well tested.  More of a novelty than anything.
