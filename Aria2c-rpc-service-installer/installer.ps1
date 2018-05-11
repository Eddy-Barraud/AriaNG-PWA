#COPY FILES TO THE PROGRAM DIR
New-Item -ItemType Directory -Force -Path "${env:programfiles(x86)}\Aria2\"
Copy-Item aria2c.exe "${env:programfiles(x86)}\Aria2\"
Copy-Item installer.ps1 "${env:programfiles(x86)}\Aria2\"
Copy-Item nssm.exe "${env:programfiles(x86)}\Aria2\"
#Install the service
##Verify that it's not already installed
sc.exe stop aria2c-rpc
sc.exe delete aria2c-rpc
sleep 2
cd "${env:programfiles(x86)}\Aria2"
.\nssm.exe install aria2c-rpc "${env:programfiles(x86)}\Aria2\aria2c.exe" --enable-rpc -x5 -j3
##Start the service
sc.exe start aria2c-rpc

#Allow appx to access local network and loop localhost
checknetisolation.exe loopbackexempt -a -n="44050trevalim.Aria2crpc_ds8qmrpgzd7fg"