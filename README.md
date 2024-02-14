# Lynox
### Super robust community operating system with Cosmos and affection 💖.

Lynox is an OS that aims to be linux but is written in C#, it follows quite a bit of a unique approach than going 1:1 linux copycat, which is that it has a different style of code, it is supporrted via the CosmosOS framework that allows OS'es to be built in C# or dotnet-based languages.

### Progress Done so far
- BLTS is now somewhat functional (Basic Lynox Testing Shell)
- Crash Handling (to some extent)

### Building

##### - Windows<br>

On windows, it's fairly simple being that you have the Cosmos DevKit (specifically from here [https://github.com/PratyushKing/Cosmos] for support reasons) and you have visual studio for windows, that should be enough to build it and test it with your preferrable VM option (mostly VMWare Player).
<br>Alternatively you can use the vmrunner.ps1 file available in the source directory and run that to setup once and for all.
<br>
##### Disclaimer: PLEASE NOTE TO USE RIDER WITH THE PROJECT YOU MUST HAVE POWERSHELL RESTRICTIONS DISABLED, TO DO SO, OPEN AN ELEVATED POWERSHELL PROMPT AND RUN `Set-ExecutionPolicy RemoteSigned` AND INSIDE RIDER YOU CAN PICK THE `Run` or `Run (Show Output)`.
Alternatively you could use the PDM run options for Rider which means Policy Disabled Mode or that it will just run the script as a terminal script. Highlighted as `Run [PDM]` and `Run [PDM] (Show Output)`. This means that you cannot stop the process from Rider and it will behave just like a regular script and no different than a make file would.

##### - Linux<br>

Linux does have a few limitations in this regard with the fact that it only has 1 proper way to run it being QEMU, installing part is very simple now with the help of my [PratyushKing] project, the CosmosCLI (https://github.com/PratyushKing/CosmosCLI) but if you still want to do it the manual way then you can follow the official cosmos wiki online. Now for installation follow:
  - Install the CosmosCLI as mentioned above.
  - Check if it installed by running `cosmos` in your terminal. If it didn't, further proceed with troubleshooting or open a github issue in the repository also linked above.
  - Then, if it worked with the above steps, run the `cosmos-install` command from your terminal and it should automatically install cosmos for you in the Home directory of your user.
  - Now you can proceed with `git clone`'ing the repository of Lynox (this current one) via SSH or HTTPS, and if that's all done correctly you should just simply be able to run `make iso` (inside the project source directory where the Makefile is present) and that should build the iso and put it in the ISO/ folder, alternative to all the make stuff, you can instead just use `cosmos -b` and it will build too, just make the directory you are in contains the CosmosBuildFile.
  - Now to run you can either `cosmos -r` to run it with the default picked option which is QEMU for the default x86_64 architecture booted with 512 MB of RAM, which will boot the OS in safe mode as the OS will not be able to find a disk file.
PLEASE NOTE: if you do not use CosmosCLI then you can still just install cosmos manually, git clone this repository and run `make iso` for the Makefile build.
