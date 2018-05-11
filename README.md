# AriaNG-PWA
Using the ariang modern web frontend inside a PWA app with a background aria2c-rpc service.

## Features

1. Pure Html & Javascript, no runtime required
2. Responsive design, supporting desktop and mobile devices
3. User-friendly interface
    * Sort tasks (by name, size, progress, remain time, download speed, etc.), files, peers
    * Search tasks
    * Adjust download order by dragging task
    * More information of tasks (health percentage, client infomation of bt peers, etc.)
    * Filter files of tasks in file types (by videos, audios, pictures, documents, applications, archives, etc.)
    * Download/upload history chart of global or task
    * Full support of aria2 settings
4. Url command line api support
5. Download finished notification
6. Multi-languages support
7. Multi aria2 RPC host support
8. Less bandwidth usage, only requesting incremental data

More details here : [https://github.com/mayswind/AriaNg/](https://github.com/mayswind/AriaNg/)

## Installation

Directly install the application in the windows store.
After that, it will ask you to download an executable to install the aria2c-rpc service and allow the application to access the localnetwork loopback (localhost).

You can also build the UWP PWA app with Visual Studio. I used Windows Template to build it.

## ScreenShots

![Ariang-PWA](https://raw.githubusercontent.com/eddydu44/ariang-PWA/master/ScreenShots/Capture1.PNG)
![Ariang-PWA](https://raw.githubusercontent.com/eddydu44/ariang-PWA/master/ScreenShots/Capture2.PNG)
![Ariang-PWA](https://raw.githubusercontent.com/eddydu44/ariang-PWA/master/ScreenShots/Capture3.PNG)

## TO-DO

It would be best to integrate aria2c-rpc service as a background task to the UWP app.
Find
