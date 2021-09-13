#!/bin/bash
echo "Thanks for trying Tess!"
echo

Args=( "$@" )
ArgLength=${#Args[@]}

for (( i=0; i<${ArgLength}; i+=2 ));
do
    if [ "${Args[$i]}" = "--host" ]; then
        HostName="${Args[$i+1]}"
    elif [ "${Args[$i]}" = "--approot" ]; then
        AppRoot="${Args[$i+1]}"
    fi
done

if [ -z "$AppRoot" ]; then
    read -p "Enter path where the Tess server files should be installed (typically /var/www/Tess): " AppRoot
    if [ -z "$AppRoot" ]; then
        AppRoot="/var/www/Tess"
    fi
fi

if [ -z "$HostName" ]; then
    read -p "Enter server host (e.g. Tess.yourdomainname.com): " HostName
fi

chmod +x "$AppRoot/Tess_Server"

echo "Using $AppRoot as the Tess website's content directory."

UbuntuVersion=$(lsb_release -r -s)

apt-get -y install curl
apt-get -y install software-properties-common
apt-get -y install gnupg

# Install .NET Core Runtime.
wget -q https://packages.microsoft.com/config/ubuntu/$UbuntuVersion/packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
add-apt-repository universe
apt-get update
apt-get -y install apt-transport-https
apt-get -y install aspnetcore-runtime-5.0
rm packages-microsoft-prod.deb


 # Install other prerequisites.
apt-get -y install unzip
apt-get -y install acl
apt-get -y install libc6-dev
apt-get -y install libgdiplus


# Install Caddy
apt install -y debian-keyring debian-archive-keyring apt-transport-https
curl -1sLf 'https://dl.cloudsmith.io/public/caddy/stable/gpg.key' | sudo apt-key add -
curl -1sLf 'https://dl.cloudsmith.io/public/caddy/stable/debian.deb.txt' | sudo tee -a /etc/apt/sources.list.d/caddy-stable.list
apt update
apt install caddy


# Configure Caddy
caddyConfig="
$HostName {
    reverse_proxy 127.0.0.1:5000
}
"

echo "$caddyConfig" > /etc/caddy/Caddyfile


# Create Tess service.

serviceConfig="[Unit]
Description=Tess Server

[Service]
WorkingDirectory=$AppRoot
ExecStart=/usr/bin/dotnet $AppRoot/Tess_Server.dll
Restart=always
# Restart service after 10 seconds if the dotnet service crashes:
RestartSec=10
SyslogIdentifier=Tess
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target"

echo "$serviceConfig" > /etc/systemd/system/Tess.service


# Enable service.
systemctl enable Tess.service
# Start service.
systemctl restart Tess.service


# Restart caddy
systemctl restart caddy