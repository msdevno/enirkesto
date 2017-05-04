# enirkesto


## Soft / Symbolic Links


### Linux / Mac

```terminal
cd ./Source/Inbox
ln -s ../Kernel/Concepts Concepts
ln -s ../Kernel/Events Events
cd ../TextAnalytics.dotnet
ln -s ../Kernel/Concepts Concepts
ln -s ../Kernel/Events Events
```

### Windows

```terminal
mklink /D Source\Kernel\Concepts Source\Inbox\Concepts
mklink /D Source\Kernel\Events Source\Inbox\Events

mklink /D Source\Kernel\Concepts Source\TextAnalytics.dotnet\Concepts
mklink /D Source\Kernel\Events Source\TextAnalytics.dotnet\Events
```