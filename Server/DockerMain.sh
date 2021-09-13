#!/bin/bash

echo "Entered main script."

ServerDir=/var/www/Tess
TessData=/Tess-data

AppSettingsVolume=/Tess-data/appsettings.json
AppSettingsWww=/var/www/Tess/appsettings.json

if [ ! -f "$AppSettingsVolume" ]; then
	echo "Copying appsettings.json to volume."
	cp "$AppSettingsWww" "$AppSettingsVolume"
fi

if [ -f "$AppSettingsWww" ]; then
	rm "$AppSettingsWww"
fi

ln -s "$AppSettingsVolume" "$AppSettingsWww"

echo "Starting Tess server."
exec /usr/bin/dotnet /var/www/Tess/Tess_Server.dll