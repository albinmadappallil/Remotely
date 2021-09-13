#!/bin/bash
HostName=
Organization=
GUID=$(cat /proc/sys/kernel/random/uuid)
UpdatePackagePath=""


Args=( "$@" )
ArgLength=${#Args[@]}

for (( i=0; i<${ArgLength}; i+=2 ));
do
    if [ "${Args[$i]}" = "--uninstall" ]; then
        systemctl stop Tess-agent
        rm -r -f /usr/local/bin/Tess
        rm -f /etc/systemd/system/Tess-agent.service
        systemctl daemon-reload
        exit
    elif [ "${Args[$i]}" = "--path" ]; then
        UpdatePackagePath="${Args[$i+1}"
    fi
done

pacman -Sy
pacman -S dotnet-runtime-5.0 --noconfirm
pacman -S libx11 --noconfirm
pacman -S unzip --noconfirm
pacman -S libc6 --noconfirm
pacman -S libgdiplus --noconfirm
pacman -S libxtst --noconfirm
pacman -S xclip --noconfirm
pacman -S jq --noconfirm
pacman -S curl --noconfirm

if [ -f "/usr/local/bin/Tess/ConnectionInfo.json" ]; then
    SavedGUID=`cat "/usr/local/bin/Tess/ConnectionInfo.json" | jq -r '.DeviceID'`
    if [[ "$SavedGUID" != "null" && -n "$SavedGUID" ]]; then
        GUID="$SavedGUID"
    fi
fi

rm -r -f /usr/local/bin/Tess
rm -f /etc/systemd/system/Tess-agent.service

mkdir -p /usr/local/bin/Tess/
cd /usr/local/bin/Tess/

if [ -z "$UpdatePackagePath" ]; then
    echo  "Downloading client..." >> /tmp/Tess_Install.log
    wget $HostName/Content/Tess-Linux.zip
else
    echo  "Copying install files..." >> /tmp/Tess_Install.log
    cp "$UpdatePackagePath" /usr/local/bin/Tess/Tess-Linux.zip
    rm -f "$UpdatePackagePath"
fi

unzip ./Tess-Linux.zip
rm -f ./Tess-Linux.zip
chmod +x ./Tess_Agent
chmod +x ./Desktop/Tess_Desktop


connectionInfo="{
    \"DeviceID\":\"$GUID\", 
    \"Host\":\"$HostName\",
    \"OrganizationID\": \"$Organization\",
    \"ServerVerificationToken\":\"\"
}"

echo "$connectionInfo" > ./ConnectionInfo.json

curl --head $HostName/Content/Tess-Linux.zip | grep -i "etag" | cut -d' ' -f 2 > ./etag.txt

echo Creating service... >> /tmp/Tess_Install.log

serviceConfig="[Unit]
Description=The Tess agent used for remote access.

[Service]
WorkingDirectory=/usr/local/bin/Tess/
ExecStart=/usr/local/bin/Tess/Tess_Agent
Restart=always
StartLimitIntervalSec=0
RestartSec=10

[Install]
WantedBy=graphical.target"

echo "$serviceConfig" > /etc/systemd/system/Tess-agent.service

systemctl enable Tess-agent
systemctl restart Tess-agent

echo Install complete. >> /tmp/Tess_Install.log