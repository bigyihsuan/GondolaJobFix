#/bin/bash
if [ ! -d ./GondolaJobFix/ ]; then
	mkdir GondolaJobFix
fi

cp "./bin/Release/GondolaJobFix.dll" "./info.json" "./GondolaJobFix/"

version=$(grep 'Version:*' "info.json" | cut -d':' -f2 | python3 build.py)

zip -r GondolaJobFix_$version.zip ./GondolaJobFix

rm -r GondolaJobFix/