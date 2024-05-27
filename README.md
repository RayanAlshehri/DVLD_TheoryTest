# Driving and Vehicle License Department Theory Test

## Overview
This project enables users to take the theory test (scheduled via [DVLD](https://github.com/RayanAlshehri/DVLD_WF/tree/master)) for the local license application. The business and data access layers can be found in the [backend repository](https://github.com/RayanAlshehri/DVLD_Backend).

### Technologies Used:
- .NET Framework
- C#
- Windows Forms
- ADO.NET
- SQL Server
  
## Setup Instructions
To download the DVLD project with all of its extensions, click [here](https://drive.google.com/drive/folders/1q0XTn3HVTAz0D0yIsY1Lasm0nrvzmRYm?usp=drive_link). Please follow the instructions in the `README.txt` file for correct setup.

## Troubleshooting
If you encounter the error "Couldn't process .resx file due to its being in the Internet or Restricted zone or having the mark of the web on the file" while attempting to run the project, 
run the following command:
```powershell
   Get-ChildItem -Path "Path to the project folder" -Recurse | Unblock-File
```

## Note
Please note that this is a personal, non-real-world project developed for learning purposes.

