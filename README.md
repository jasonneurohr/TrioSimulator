# TrioSimulator

A rudimentary Polycom Trio simulator written in ASP.NET Core.

## Setup

### Certificate
Create a selfsigned certificate using PowerShell or OpenSSL and then place the PFX file in the same directory as the TrioSimulator.dll. Example for PowerShell.

```powershell
New-SelfSignedCertificate -DnsName "triosimulator" -KeyLength 2048 -KeyExportPolicy Exportable -NotAfter (Get-Date).AddMonths(24)
```

Update the appsettings.json with the certificate name and password

```
          "Path": "self.pfx",
          "Password": "password"
```

### JSON TXT Response

Calls to /api/v1/mgmt/device/info will looks for **response.txt** in the same directory as the TrioSimulator.dll. Make sure this file exists and contains a valid JSON response. See the API section. There is an alternative return path which will return a hardcoded object commented out in the ValueController.cs, adjust this if desired.

### Run

From the command line start the simulator. Make sure you run the command from within the same directory as the TrioSimulator.dll, or otherwise, specific the full path.

```powershell
dotnet .\TrioSimulator.dll
```

# API

## api/v1/mgmt/device/info

Example JSON response:

```json
{"data": {"ModelNumber": "Trio 8800", "DeviceType": "hardwareEndpoint", "FirmwareRelease": "5.5.4.2255", "DeviceVendor": "Polycom", "MACAddress": "64167f1e4b8a", "UpTimeSinceLastReboot": "20 Days 16:11:42", "IPV4Address": "10.27.34.22", "IPV6Address": "::", "AttachedHardware": {}}, "Status": "2000"}
```

## api/v1/mgmt/lineinfo

Example JSON response:

```json
{"data": [{"LineNumber": "1", "UserID": "6000", "LineType": "private", "SIPAddress": "6000", "Protocol": "SIP", "RegistrationStatus": "unregistered", "Label": "6000", "ProxyAddress": "192.168.44.160", "Port": "5060"}], "Status": "2000"}
```